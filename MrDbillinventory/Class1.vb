Imports System.Configuration
Imports System.Data.OleDb
Imports System.IO

Public Class Class1
    Public Sub main()
        CloseDatabase()

        Dim databasePath As String = Environment.GetEnvironmentVariable("MRD_DATABASE_PATH")
        If String.IsNullOrWhiteSpace(databasePath) Then
            databasePath = ConfigurationManager.AppSettings("DatabasePath")
        End If
        If String.IsNullOrWhiteSpace(databasePath) Then databasePath = "..\MrDbase.accdb"
        If Not Path.IsPathRooted(databasePath) Then
            databasePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, databasePath)
        End If
        databasePath = Path.GetFullPath(databasePath)
        If Not File.Exists(databasePath) Then
            Throw New FileNotFoundException("The Access database was not found at:" & Environment.NewLine &
                databasePath & Environment.NewLine & Environment.NewLine &
                "Set DatabasePath in MrDbillinventory.exe.config to your MrDbase.accdb file.", databasePath)
        End If

        Dim provider As String = ConfigurationManager.AppSettings("DatabaseProvider")
        If String.IsNullOrWhiteSpace(provider) Then provider = "Microsoft.ACE.OLEDB.12.0"
        Dim connectionString As New OleDbConnectionStringBuilder()
        connectionString.Provider = provider
        connectionString.DataSource = databasePath
        connectionString.PersistSecurityInfo = False

        Try
            con.Open(connectionString.ConnectionString)
            OpenRecordset(invent, "Inventory", "ID")
            OpenRecordset(account, "Accounts", "ID")
            OpenRecordset(tranOut, "tranOut", "ID")
            OpenRecordset(taborn, "taborn", "ID DESC")
            OpenRecordset(po, "PurchaseOrders", "ID DESC")
            OpenRecordset(poitm, "PO_Items", "ID")
        Catch ex As Exception
            CloseDatabase()
            Dim processBits As String = If(Environment.Is64BitProcess, "64-bit", "32-bit")
            Throw New InvalidOperationException("Could not open the Access database:" & Environment.NewLine &
                databasePath & Environment.NewLine & Environment.NewLine &
                "This application is running as " & processBits & ". The Access database engine must match. " &
                "Run build.ps1 -Platform x86 for a 32-bit Access engine, or -Platform x64 for a 64-bit engine." &
                Environment.NewLine & Environment.NewLine & ex.Message, ex)
        End Try
    End Sub

    Private Sub OpenRecordset(ByVal records As ADODB.Recordset, ByVal tableName As String, ByVal sort As String)
        records.CursorLocation = ADODB.CursorLocationEnum.adUseClient
        records.Open("SELECT * FROM [" & tableName & "] ORDER BY " & sort, con,
                     ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockOptimistic)
    End Sub

    Public Sub CloseDatabase()
        For Each records As ADODB.Recordset In New ADODB.Recordset() {invent, account, tranOut, taborn, po, poitm}
            If records.State <> ADODB.ObjectStateEnum.adStateClosed Then records.Close()
        Next
        If con.State <> ADODB.ObjectStateEnum.adStateClosed Then con.Close()
    End Sub
End Class
