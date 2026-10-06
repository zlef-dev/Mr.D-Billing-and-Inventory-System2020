[CmdletBinding()]
param(
    [ValidateSet('Debug', 'Release')][string]$Configuration = 'Debug',
    [ValidateSet('Auto', 'AnyCPU', 'x86', 'x64')][string]$Platform = 'Auto',
    [switch]$Run
)

$ErrorActionPreference = 'Stop'
$solutionRoot = $PSScriptRoot
$packageRoot = Join-Path $solutionRoot 'packages'
$packageDirectory = Join-Path $packageRoot 'VisualBasic.PowerPacks.Vs.1.0.0'
$powerPacksAssembly = Join-Path $packageDirectory 'lib/Microsoft.VisualBasic.PowerPacks.Vs.dll'
$expectedPackageHash = '7F178F0049E1E8719251566003758136002E62A0A1E28B11AC4BF57DFB2FFE65'

# Restore the exact original Power Packs assembly; no machine-wide installation is needed.
if (-not (Test-Path -LiteralPath $powerPacksAssembly)) {
    New-Item -ItemType Directory -Path $packageRoot -Force | Out-Null
    $packageArchive = Join-Path $packageRoot 'visualbasic.powerpacks.vs.1.0.0.nupkg'
    if (-not (Test-Path -LiteralPath $packageArchive)) {
        Write-Host 'Restoring Visual Basic Power Packs 10...'
        [Net.ServicePointManager]::SecurityProtocol = [Net.SecurityProtocolType]::Tls12
        Invoke-WebRequest -UseBasicParsing -Uri 'https://api.nuget.org/v3-flatcontainer/visualbasic.powerpacks.vs/1.0.0/visualbasic.powerpacks.vs.1.0.0.nupkg' -OutFile $packageArchive -TimeoutSec 60
    }
    if ((Get-FileHash -LiteralPath $packageArchive -Algorithm SHA256).Hash -ne $expectedPackageHash) {
        throw 'Power Packs package checksum does not match. Remove the package archive and run this script again.'
    }
    Add-Type -AssemblyName System.IO.Compression.FileSystem
    $packageZip = [IO.Compression.ZipFile]::OpenRead($packageArchive)
    try {
        $assemblyEntry = $packageZip.GetEntry('lib/Microsoft.VisualBasic.PowerPacks.Vs.dll')
        if ($null -eq $assemblyEntry) { throw 'The Power Packs package does not contain the expected assembly.' }
        New-Item -ItemType Directory -Path (Split-Path $powerPacksAssembly) -Force | Out-Null
        [IO.Compression.ZipFileExtensions]::ExtractToFile($assemblyEntry, $powerPacksAssembly, $true)
    } finally {
        $packageZip.Dispose()
    }
}
$assemblyIdentity = [Reflection.AssemblyName]::GetAssemblyName($powerPacksAssembly).FullName
if ($assemblyIdentity -ne 'Microsoft.VisualBasic.PowerPacks.Vs, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a') {
    throw 'The restored Power Packs assembly has the wrong identity.'
}
$expectedAssemblyHash = 'C62E53BF7E941A262B5B18211683BD045B70959F59DDCCB4E454DB18EE380833'
if ((Get-FileHash -LiteralPath $powerPacksAssembly -Algorithm SHA256).Hash -ne $expectedAssemblyHash) {
    throw 'The restored Power Packs assembly checksum does not match.'
}

$programFiles32 = ${env:ProgramFiles(x86)}
if (-not $programFiles32) { $programFiles32 = $env:ProgramFiles }
$msbuildPath = $null
$vswherePath = Join-Path $programFiles32 'Microsoft Visual Studio/Installer/vswhere.exe'
if (Test-Path -LiteralPath $vswherePath) {
    $msbuildPath = & $vswherePath -latest -products '*' -requires Microsoft.Component.MSBuild -find 'MSBuild\**\Bin\MSBuild.exe' | Select-Object -First 1
}
if (-not $msbuildPath) {
    $msbuildCommand = Get-Command MSBuild.exe -ErrorAction SilentlyContinue
    if ($msbuildCommand) { $msbuildPath = $msbuildCommand.Source }
}
if (-not $msbuildPath) {
    throw 'Install Visual Studio or Build Tools with .NET desktop development and the .NET Framework 4.8 targeting pack, then run this script again.'
}
$frameworkReferences = Join-Path $programFiles32 'Reference Assemblies/Microsoft/Framework/.NETFramework/v4.8'
if (-not (Test-Path -LiteralPath $frameworkReferences)) {
    throw 'The .NET Framework 4.8 targeting pack is missing. Add it using the Visual Studio Installer.'
}

# Match the process architecture to the installed Access driver.
if ($Platform -eq 'Auto') {
    [xml]$sourceConfiguration = Get-Content -LiteralPath (Join-Path $solutionRoot 'MrDbillinventory/App.config')
    $configuredProvider = @($sourceConfiguration.configuration.appSettings.add | Where-Object { $_.key -eq 'DatabaseProvider' } | Select-Object -First 1)
    $providerName = 'Microsoft.ACE.OLEDB.12.0'
    if ($configuredProvider.Count -gt 0 -and $configuredProvider[0].value) { $providerName = [string]$configuredProvider[0].value }
    $provider64 = [Microsoft.Win32.RegistryKey]::OpenBaseKey([Microsoft.Win32.RegistryHive]::ClassesRoot, [Microsoft.Win32.RegistryView]::Registry64)
    $provider32 = [Microsoft.Win32.RegistryKey]::OpenBaseKey([Microsoft.Win32.RegistryHive]::ClassesRoot, [Microsoft.Win32.RegistryView]::Registry32)
    $ace64 = $null
    $ace32 = $null
    try {
        $ace64 = $provider64.OpenSubKey($providerName + '\CLSID')
        $ace32 = $provider32.OpenSubKey($providerName + '\CLSID')
        if ([Environment]::Is64BitOperatingSystem -and $ace64) { $Platform = 'x64' }
        elseif ($ace32) { $Platform = 'x86' }
        else {
            $Platform = 'AnyCPU'
            Write-Warning 'The Access database engine is missing. Install Microsoft 365 Access Runtime before running the application.'
        }
    } finally {
        if ($ace64) { $ace64.Dispose() }
        if ($ace32) { $ace32.Dispose() }
        $provider64.Dispose()
        $provider32.Dispose()
    }
}

Write-Host "Building $Configuration ($Platform)..."
& $msbuildPath (Join-Path $solutionRoot 'MrDbillinventory.sln') /t:Rebuild "/p:Configuration=$Configuration" '/p:Platform=Any CPU' "/p:PlatformTarget=$Platform" /p:Prefer32Bit=false /nologo /verbosity:minimal
if ($LASTEXITCODE -ne 0) { throw 'The build failed. See the build errors above.' }
$executablePath = Join-Path $solutionRoot "MrDbillinventory/bin/$Configuration/MrDbillinventory.exe"
Write-Host "Built: $executablePath"
if ($Run) {
    if (-not (Test-Path -LiteralPath (Join-Path $solutionRoot 'MrDbillinventory/bin/MrDbase.accdb')) -and -not $env:MRD_DATABASE_PATH) {
        Write-Warning 'The bundled database is missing. Set DatabasePath in the executable configuration or MRD_DATABASE_PATH to your Access database.'
    }
    # This is the interactive application requested by the user.
    Start-Process -FilePath $executablePath -WorkingDirectory (Split-Path $executablePath)
}
