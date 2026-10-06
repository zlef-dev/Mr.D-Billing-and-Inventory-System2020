# Mr. D Billing and Inventory

The original Windows desktop application: **VB.NET, Windows Forms, .NET Framework 4.8, ADODB, Microsoft Access (`.accdb`), and Visual Basic Power Packs 10**.

> ⚠️ **Status (2026) — needs rework:** This app currently runs only on the laptop where it was developed. Its paths, database location, Access driver, and local dependencies are all machine-specific, so it must be modified/ported in 2026 before it can run on other computers.

## Run

Double-click **Run.cmd** in this folder. It restores the existing Power Packs dependency, builds the application, chooses the architecture that matches your installed Access driver, and opens the cashier screen.

To build without opening the application, double-click **Build.cmd**. You can also open `MrDbillinventory.sln` in Visual Studio after running Build.cmd once.

From PowerShell:

```powershell
.\build.ps1 -Run
.\build.ps1 -Configuration Release
.\build.ps1 -Platform x86 -Run
```

## Requirements

- Windows with .NET Framework 4.8.
- Visual Studio / Build Tools with **.NET desktop development**, the **.NET Framework 4.8 targeting pack**, and the .NET Framework SDK. The launcher uses Visual Studio's MSBuild.
- An Access database engine matching the application's architecture. This computer has the 64-bit engine. For another computer, [Microsoft 365 Access Runtime](https://support.microsoft.com/en-us/access/download-and-install-microsoft-365-access-runtime) supplies the engine; match the existing Office installation.
- Internet access for the first Power Packs restore. Later builds use the local package cache.

Power Packs is restored from [VisualBasic.PowerPacks.Vs 1.0.0 on NuGet](https://www.nuget.org/packages/VisualBasic.PowerPacks.Vs/1.0.0), which contains the original Microsoft-signed assembly version 10.0.0.0. The launcher checks the package and assembly SHA-256 values. It references only the Power Packs assembly, keeping the framework's Visual Basic runtime. ADODB uses the installed original Microsoft interop assembly when available, with a Windows ADO COM-reference fallback.

## Database and login

The existing database stays at `MrDbillinventory\bin\MrDbase.accdb`. Builds do not replace it or reset its accounts. The cashier opens directly; **Switch User** uses the administrator account already stored in the database.

`DatabasePath` in `MrDbillinventory\App.config` defaults to `..\MrDbase.accdb`, resolved relative to the executable folder. You can set an absolute path or use the `MRD_DATABASE_PATH` environment variable. An environment override takes priority and is useful for a separate test database.

For deployment, copy the complete Release output folder (including both DLLs and the executable configuration), provide a writable Access database, and set `DatabasePath` in `MrDbillinventory.exe.config`. Rebuilding regenerates that output configuration from App.config.

Receipts use the Windows default printer. Completing a sale saves it before printing; an unavailable printer now reports the problem and returns to the cashier.

The original forms use a fixed 1366 x 768 layout. Use a display with enough space for the whole window.

## Verification

The integration smoke test uses a separate copy of the database under `.smoke-test`, keeps credentials out of its output, and suppresses receipt printing. Run it in Windows PowerShell 5.1 with STA and the architecture matching your driver:

```powershell
powershell.exe -NoProfile -STA -ExecutionPolicy Bypass -File .\scripts\smoke-test.ps1
powershell.exe -NoProfile -STA -ExecutionPolicy Bypass -File .\scripts\smoke-test.ps1 -FirstSale
```

The test checks database initialization, forms, navigation, cart operations, and sales on the copy, then confirms that the original database's SHA-256 is unchanged. Physical printing still needs a check with your actual receipt printer.
