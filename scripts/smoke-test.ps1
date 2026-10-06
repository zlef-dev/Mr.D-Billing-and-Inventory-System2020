[CmdletBinding()]
param(
    [string]$ApplicationPath,
    [string]$DatabasePath,
    [switch]$FirstSale,
    [switch]$SkipSale,
    [switch]$SkipImages
)

# Run in a fresh Windows PowerShell 5.1 process with the application's architecture:
# powershell.exe -NoProfile -STA -ExecutionPolicy Bypass -File scripts\smoke-test.ps1
# For an x86 build on 64-bit Windows, use SysWOW64\WindowsPowerShell\v1.0\powershell.exe.
# Only the unique database copy below is opened by the application. Credentials
# stay inside this process and are never included in output or screenshots.
$ErrorActionPreference = 'Stop'
Set-StrictMode -Version 2.0
if ($PSVersionTable.PSEdition -ne 'Desktop') {
    throw 'Run this test with Windows PowerShell 5.1, which uses .NET Framework.'
}
if ([Threading.Thread]::CurrentThread.ApartmentState -ne 'STA') {
    throw 'Run Windows PowerShell with -STA for this Windows Forms integration test.'
}

$projectRoot = [IO.Path]::GetFullPath((Join-Path $PSScriptRoot '..'))
if (-not $ApplicationPath) { $ApplicationPath = Join-Path $projectRoot 'MrDbillinventory\bin\Debug\MrDbillinventory.exe' }
if (-not $DatabasePath) { $DatabasePath = Join-Path $projectRoot 'MrDbillinventory\bin\MrDbase.accdb' }
$applicationSource = (Resolve-Path -LiteralPath $ApplicationPath).Path
$databaseSource = (Resolve-Path -LiteralPath $DatabasePath).Path
$sourceHash = (Get-FileHash -LiteralPath $databaseSource -Algorithm SHA256).Hash
$runDirectory = Join-Path $projectRoot ('.smoke-test\' + [Guid]::NewGuid().ToString('N'))
New-Item -ItemType Directory -Path $runDirectory -Force | Out-Null
$applicationDirectory = Split-Path -Parent $applicationSource
foreach ($file in Get-ChildItem -LiteralPath $applicationDirectory -File) {
    if ($file.Extension -in '.exe', '.dll', '.config') {
        Copy-Item -LiteralPath $file.FullName -Destination $runDirectory
    }
}
$databaseCopy = Join-Path $runDirectory 'MrDbase.accdb'
Copy-Item -LiteralPath $databaseSource -Destination $databaseCopy
$applicationCopy = Join-Path $runDirectory ([IO.Path]::GetFileName($applicationSource))
$originalDatabaseSetting = [Environment]::GetEnvironmentVariable('MRD_DATABASE_PATH', 'Process')
[Environment]::SetEnvironmentVariable('MRD_DATABASE_PATH', $databaseCopy, 'Process')

Add-Type -AssemblyName System.Windows.Forms, System.Drawing

# The timer runs on this test's UI thread, including nested MessageBox loops.
# It closes only dialogs belonging to this thread; it never operates a printer.
Add-Type -ReferencedAssemblies System.Windows.Forms -TypeDefinition @'
using System;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
public sealed class MrDSmokeDialogs : IDisposable
{
    private readonly Timer timer = new Timer();
    private readonly uint threadId = GetCurrentThreadId();
    public int DismissedCount { get; private set; }
    public MrDSmokeDialogs()
    {
        timer.Interval = 100;
        timer.Tick += delegate { EnumThreadWindows(threadId, CloseDialog, IntPtr.Zero); };
        timer.Start();
    }
    private bool CloseDialog(IntPtr window, IntPtr unused)
    {
        var className = new StringBuilder(64);
        GetClassName(window, className, className.Capacity);
        if (className.ToString() == "#32770" && IsWindowVisible(window))
        {
            int command = GetDlgItem(window, 1) != IntPtr.Zero ? 1 : 2;
            PostMessage(window, 0x0111, new IntPtr(command), IntPtr.Zero);
            DismissedCount++;
        }
        return true;
    }
    public void Dispose() { timer.Stop(); timer.Dispose(); }
    private delegate bool WindowCallback(IntPtr window, IntPtr unused);
    [DllImport("kernel32.dll")] private static extern uint GetCurrentThreadId();
    [DllImport("user32.dll")] private static extern bool EnumThreadWindows(uint threadId, WindowCallback callback, IntPtr unused);
    [DllImport("user32.dll", CharSet = CharSet.Unicode)] private static extern int GetClassName(IntPtr window, StringBuilder text, int capacity);
    [DllImport("user32.dll")] private static extern bool IsWindowVisible(IntPtr window);
    [DllImport("user32.dll")] private static extern IntPtr GetDlgItem(IntPtr window, int id);
    [DllImport("user32.dll")] private static extern bool PostMessage(IntPtr window, uint message, IntPtr wParam, IntPtr lParam);
}
'@

$instanceFlags = [Reflection.BindingFlags]'Instance,Public,NonPublic'
$staticFlags = [Reflection.BindingFlags]'Static,Public,NonPublic'
$script:applicationAssembly = $null
$script:defaultForms = $null
$databaseManager = $null
$dialogCloser = $null
$formsToDispose = New-Object 'Collections.Generic.List[System.Windows.Forms.Form]'
$script:checks = New-Object 'Collections.Generic.List[string]'

function Assert-Condition([bool]$Condition, [string]$Description) {
    if (-not $Condition) { throw ('Smoke check failed: ' + $Description) }
    $script:checks.Add($Description)
    Write-Output ('PASS ' + $Description)
}

function Get-DefaultForm([string]$Name) {
    $property = $script:defaultForms.GetType().GetProperty($Name, $instanceFlags)
    if ($null -eq $property) { throw ('Default form not found: ' + $Name) }
    $form = $property.GetValue($script:defaultForms, $null)
    if (-not $formsToDispose.Contains($form)) { $formsToDispose.Add($form) }
    return $form
}

function Get-FormMember($Form, [string]$Name) {
    $property = $Form.GetType().GetProperty($Name, $instanceFlags)
    if ($null -ne $property) { return $property.GetValue($Form, $null) }
    $field = $Form.GetType().GetField($Name, $instanceFlags)
    if ($null -eq $field) { throw ('Form member not found: ' + $Name) }
    return $field.GetValue($Form)
}

function Invoke-FormHandler($Form, [string]$Name) {
    $method = $Form.GetType().GetMethod($Name, $instanceFlags)
    if ($null -eq $method) { throw ('Form handler not found: ' + $Name) }
    try {
        $null = $method.Invoke($Form, [object[]]@($Form, [EventArgs]::Empty))
    }
    catch [Reflection.TargetInvocationException] {
        throw $_.Exception.InnerException
    }
}

function Get-ModuleValue([string]$Name) {
    return $script:applicationAssembly.GetType('MrDbillinventory.Module1', $true).GetField($Name, $staticFlags).GetValue($null)
}

function Get-DatabaseNumber([string]$Sql) {
    $connection = Get-ModuleValue 'con'
    $rows = $connection.Execute($Sql)
    try { return [double]$rows.Fields.Item(0).Value }
    finally { if ($rows.State -ne 0) { $rows.Close() } }
}

function Save-FormImage($Form, [string]$Filename) {
    $Form.StartPosition = [Windows.Forms.FormStartPosition]::Manual
    $Form.Location = New-Object Drawing.Point(-10000, -10000)
    $Form.ShowInTaskbar = $false
    $Form.Show()
    if ($Form.GetType().Name -eq 'Inventory') { Invoke-FormHandler $Form 'Button1_Click' }
    [Windows.Forms.Application]::DoEvents()
    $null = $Form.Handle
    $Form.PerformLayout()
    $bitmap = New-Object Drawing.Bitmap($Form.Width, $Form.Height)
    try {
        $bounds = New-Object Drawing.Rectangle(0, 0, $Form.Width, $Form.Height)
        $Form.DrawToBitmap($bitmap, $bounds)
        $bitmap.Save((Join-Path $runDirectory $Filename), [Drawing.Imaging.ImageFormat]::Png)
    }
    finally { $bitmap.Dispose(); $Form.Hide() }
}

try {
    # Preload copied dependencies so legacy GAC references resolve on this machine.
    foreach ($library in Get-ChildItem -LiteralPath $runDirectory -Filter '*.dll' -File) {
        $null = [Reflection.Assembly]::LoadFrom($library.FullName)
    }
    $script:applicationAssembly = [Reflection.Assembly]::LoadFrom($applicationCopy)
    $myProjectType = $script:applicationAssembly.GetType('MrDbillinventory.My.MyProject', $true)
    $script:defaultForms = $myProjectType.GetProperty('Forms', $staticFlags).GetValue($null, $null)
    $databaseManager = [Activator]::CreateInstance($script:applicationAssembly.GetType('MrDbillinventory.Class1', $true))
    $databaseManager.main()
    foreach ($name in 'con', 'invent', 'account', 'tranOut', 'taborn', 'po', 'poitm') {
        Assert-Condition ((Get-ModuleValue $name).State -eq 1) ('Database connection open: ' + $name)
    }
    if ($FirstSale) {
        # Clear only the disposable test copy to exercise a shop's first sale.
        $copiedConnection = Get-ModuleValue 'con'
        $null = $copiedConnection.Execute('DELETE FROM [tranOut]')
        $null = $copiedConnection.Execute('DELETE FROM [taborn]')
        $databaseManager.main()
    }

    $dialogCloser = New-Object MrDSmokeDialogs
    $cashier = Get-DefaultForm 'Form1'
    Invoke-FormHandler $cashier 'Form1_Load'
    $login = Get-DefaultForm 'Login'
    Invoke-FormHandler $login 'Login_Load'
    $inventoryForm = Get-DefaultForm 'Inventory'
    Invoke-FormHandler $inventoryForm 'Inventory_Load'
    Assert-Condition ($cashier.Controls.Count -gt 0 -and $login.Controls.Count -gt 0 -and $inventoryForm.Controls.Count -gt 0) 'Cashier, login, and inventory forms initialize'

    Invoke-FormHandler $inventoryForm 'Button1_Click'
    $stockList = Get-FormMember $inventoryForm 'ListView1'
    Assert-Condition ($stockList.Items.Count -eq (Get-ModuleValue 'invent').RecordCount) 'Stocks tab loads inventory rows'
    if ($stockList.Items.Count -gt 0) {
        $null = $stockList.Handle
        $stockList.Items[0].Selected = $true
        $stockList.Items[0].Focused = $true
        Invoke-FormHandler $inventoryForm 'ListView1_SelectedIndexChanged_1'
        $stockList.Items.Clear()
    }
    Invoke-FormHandler $inventoryForm 'ListView1_SelectedIndexChanged_1'
    Invoke-FormHandler $inventoryForm 'Button1_Click'
    Assert-Condition ($stockList.Items.Count -eq (Get-ModuleValue 'invent').RecordCount) 'Stocks can be selected, cleared, and reloaded'

    Invoke-FormHandler $inventoryForm 'ItemsButt_Click'
    $salesList = Get-FormMember $inventoryForm 'ListView2'
    Assert-Condition ($salesList.Items.Count -eq (Get-ModuleValue 'taborn').RecordCount) 'Sales tab loads receipt rows'
    if ($salesList.Items.Count -gt 0) {
        $null = $salesList.Handle
        $salesList.Items[0].Selected = $true
        $salesList.Items[0].Focused = $true
        Invoke-FormHandler $inventoryForm 'ListView2_SelectedIndexChanged'
        $salesList.Items.Clear()
    }
    Invoke-FormHandler $inventoryForm 'ListView2_SelectedIndexChanged'
    Invoke-FormHandler $inventoryForm 'ItemsButt_Click'

    Invoke-FormHandler $inventoryForm 'SettingsButt_Click'
    $purchaseList = Get-FormMember $inventoryForm 'ListView8'
    Assert-Condition ($purchaseList.Items.Count -eq (Get-ModuleValue 'po').RecordCount) 'Purchase orders tab loads order rows'
    if ($purchaseList.Items.Count -gt 0) {
        $null = $purchaseList.Handle
        $purchaseList.Items[0].Selected = $true
        $purchaseList.Items[0].Focused = $true
        Invoke-FormHandler $inventoryForm 'ListView8_SelectedIndexChanged'
        $purchaseList.Items.Clear()
    }
    Invoke-FormHandler $inventoryForm 'ListView8_SelectedIndexChanged'
    Invoke-FormHandler $inventoryForm 'SettingsButt_Click'
    Assert-Condition ($purchaseList.Items.Count -eq (Get-ModuleValue 'po').RecordCount) 'Purchase orders can be selected, cleared, and reloaded'
    Invoke-FormHandler $inventoryForm 'Button9_Click'
    Assert-Condition ((Get-FormMember $inventoryForm 'ListView5').Items.Count -eq 0) 'Blank purchase input is rejected safely'

    # Reconnection clears any recordset filters used by the tabs.
    $databaseManager.main()
    Assert-Condition ((Get-ModuleValue 'con').State -eq 1) 'Database can reconnect after navigating tabs'
    $inventoryRows = Get-ModuleValue 'invent'
    $barcode = $null
    $stockRowId = 0
    $quantityBefore = 0.0
    if ($inventoryRows.RecordCount -gt 0) {
        $inventoryRows.MoveFirst()
        while (-not $inventoryRows.EOF) {
            $stockQuantity = $inventoryRows.Fields.Item('Quantity').Value
            $sellingPrice = $inventoryRows.Fields.Item('SellingPrice').Value
            $candidateBarcode = [string]$inventoryRows.Fields.Item('UPSno').Value
            if (-not [string]::IsNullOrWhiteSpace($candidateBarcode) -and $stockQuantity -isnot [DBNull] -and $sellingPrice -isnot [DBNull] -and [double]$stockQuantity -ge 1 -and [double]$sellingPrice -ge 0) {
                $barcode = $candidateBarcode
                $stockRowId = [int]$inventoryRows.Fields.Item('ID').Value
                $quantityBefore = [double]$stockQuantity
                break
            }
            $inventoryRows.MoveNext()
        }
    }
    if ($null -ne $barcode) {
        $basket = Get-FormMember $cashier 'ListView2'
        $barcodeBox = Get-FormMember $cashier 'TextBox1'
        $quantityBox = Get-FormMember $cashier 'TextBox2'
        $cashBox = Get-FormMember $cashier 'CashTextbox'
        $quantityBox.Text = '1'
        $barcodeBox.Text = $barcode
        Assert-Condition ($basket.Items.Count -eq 1) 'Barcode adds an in-stock item to the cart'
        $cashBox.Text = 'invalid'
        Assert-Condition ((Get-FormMember $cashier 'ChangeLabel').Text -eq '-') 'Pasted invalid cash is handled safely'
        $cashBox.Text = '0'

        $accountRows = Get-ModuleValue 'account'
        if ($accountRows.RecordCount -gt 0) {
            $accountRows.MoveFirst()
            $pinValue = [string]$accountRows.Fields.Item('PIN').Value
            $clearForm = Get-DefaultForm 'validation2'
            (Get-FormMember $clearForm 'TextBox1').Text = $pinValue
            Invoke-FormHandler $clearForm 'Button1_Click'
            $pinValue = $null
            Assert-Condition ($basket.Items.Count -eq 0 -and (Get-FormMember $cashier 'TotalLabel').Text -eq '0') 'PIN clear empties the cart and keeps a numeric total'
            $quantityBox.Text = '1'
            $barcodeBox.Text = $barcode
            Assert-Condition ($basket.Items.Count -eq 1) 'An item can be added again after clearing the cart'
        }
        else { Write-Output 'SKIP PIN cart clear: no configured account in the copied database.' }

        if (-not $SkipSale) {
            $receipt = Get-DefaultForm 'Resibo'
            $receiptTimer = Get-FormMember $receipt 'Timer1'
            $receiptTimer.Stop()
            # A second barrier ensures that even an unexpected timer tick could
            # only open a preview, never submit a job to the default printer.
            (Get-FormMember $receipt 'PrintForm1').PrintAction = [Drawing.Printing.PrintAction]::PrintToPreview
            $receipt.StartPosition = [Windows.Forms.FormStartPosition]::Manual
            $receipt.Location = New-Object Drawing.Point(-10000, -10000)
            $headersBefore = Get-DatabaseNumber 'SELECT COUNT(*) FROM taborn'
            $linesBefore = Get-DatabaseNumber 'SELECT COUNT(*) FROM tranOut'
            $cashBox.Text = (Get-FormMember $cashier 'TotalLabel').Text
            try { Invoke-FormHandler $cashier 'Button3_Click' }
            finally { $receiptTimer.Stop(); $receipt.Hide() }
            Assert-Condition ((Get-DatabaseNumber 'SELECT COUNT(*) FROM taborn') -eq $headersBefore + 1) 'Checkout saves one receipt in the database copy'
            Assert-Condition ((Get-DatabaseNumber 'SELECT COUNT(*) FROM tranOut') -eq $linesBefore + 1) 'Checkout saves one sale line in the database copy'
            $quantityAfter = Get-DatabaseNumber ('SELECT Quantity FROM Inventory WHERE ID = ' + $stockRowId)
            Assert-Condition ([Math]::Abs($quantityAfter - ($quantityBefore - 1)) -lt 0.000001) 'Checkout decrements the copied stock by one'
            $receiptNumber = 0
            Assert-Condition ([int]::TryParse((Get-FormMember $receipt 'Label11').Text, [ref]$receiptNumber) -and $receiptNumber -gt 0) 'Receipt displays a positive receipt number'
            if ($FirstSale) { Assert-Condition ($receiptNumber -eq 1) 'The first sale displays receipt number one' }
            Assert-Condition (-not $receiptTimer.Enabled) 'Receipt timer is stopped without sending a print job'
        }
    }
    else { Write-Output 'SKIP cart and checkout: no saleable in-stock item in the copied database.' }

    if (-not $SkipImages) {
        Invoke-FormHandler $inventoryForm 'Button1_Click'
        Save-FormImage $cashier 'cashier.png'
        Save-FormImage $inventoryForm 'inventory.png'
        Assert-Condition ((Test-Path -LiteralPath (Join-Path $runDirectory 'cashier.png')) -and (Test-Path -LiteralPath (Join-Path $runDirectory 'inventory.png'))) 'Cashier and inventory screenshots are saved'
    }
    Write-Output ('Smoke checks completed: ' + $script:checks.Count)
    Write-Output ('Local test artifacts: ' + $runDirectory)
}
finally {
    try {
        foreach ($form in $formsToDispose) {
            if ($form.GetType().Name -eq 'Resibo') {
                (Get-FormMember $form 'Timer1').Stop()
            }
        }
        if ($null -ne $databaseManager) { $databaseManager.CloseDatabase() }
    }
    finally {
        try {
            foreach ($form in $formsToDispose) { $form.Dispose() }
            if ($null -ne $dialogCloser) { $dialogCloser.Dispose() }
        }
        finally {
            [Environment]::SetEnvironmentVariable('MRD_DATABASE_PATH', $originalDatabaseSetting, 'Process')
            $finalSourceHash = (Get-FileHash -LiteralPath $databaseSource -Algorithm SHA256).Hash
            if ($sourceHash -ne $finalSourceHash) { throw 'The source database changed during the smoke test.' }
            Write-Output 'PASS Source database SHA256 is unchanged'
        }
    }
}
