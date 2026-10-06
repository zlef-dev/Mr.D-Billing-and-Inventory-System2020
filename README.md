# Mr. D Billing and Inventory

A point-of-sale and inventory system for a small convenience store, written as a Windows desktop app in **VB.NET, Windows Forms, .NET Framework 4.8, ADODB, Microsoft Access (`.accdb`), and Visual Basic Power Packs 10**.

I built this in 2020 as a Senior High School project, in the ICT strand of the Philippine K-12 program.

## The story

My teacher introduced the class to this tech stack (VB.NET with an Access database) and then left it to us. Everything after that was mine: I picked the project, designed the screens, wrote the code, and built the database, working alone.

There was no AI assistant back then. When I got stuck, I thought it through on my own, searched, and read a lot of Stack Overflow answers until something worked. Most of what is in here is the result of that: trying things, breaking them, and slowly working out why.

I chose a convenience store because it is a system I could picture end to end: a cashier ringing up items, stock going down with every sale, and an owner who wants to know what sold and what to reorder.

The code shows its age. It is a lot of event handlers on big forms, with the logic living right next to the UI. I'm leaving it that way on purpose, because it is an honest record of where I started.

## What it does

**Cashier screen**
- Search for or select items, build a cart, and edit or remove lines.
- Enter the cash received and the app computes the change.
- Prints a receipt (`Resibo`, Filipino for "receipt") on the Windows default printer. A sale is saved before printing, so an unavailable printer doesn't lose it.

**Admin side** (behind a login, reached with **Switch User**)
- **Stocks:** the item list, with UPC number, quantity, and selling price.
- **Transactions:** every sale by OR number, with a filter by date.
- **Purchase Orders:** restocking records and their line items.
- **Sales Report:** sales and products sold per month and for the year, with charts.
- **Settings:** account management. Password recovery uses a security question stored with the account.

## Original work and later additions

The forms, logic, database design, and look of the app are the original 2020 work.

In 2026 I came back to it and added only what was needed to make it runnable again, without redesigning anything:

- `Run.cmd`, `Build.cmd`, and `build.ps1`, which restore the dependency, build, and launch the app.
- A configurable database path (`DatabasePath` in `App.config`, or the `MRD_DATABASE_PATH` environment variable) instead of one fixed to my old laptop.
- Clearer error messages for a missing database, a mismatched Access driver, or an unavailable printer.
- `scripts/smoke-test.ps1`, an integration test that runs against a copy of the database.

> **Status:** this has only been verified on the machine I developed it on. It is Windows-only and needs the Access database engine installed. It is a finished student project kept as a portfolio piece, not production software.

## Run

Double-click **Run.cmd**. It restores the Power Packs dependency, builds the app, picks the architecture that matches your installed Access driver, and opens the cashier screen.

To build without opening the app, double-click **Build.cmd**. You can also open `MrDbillinventory.sln` in Visual Studio after running Build.cmd once.

From PowerShell:

```powershell
.\build.ps1 -Run
.\build.ps1 -Configuration Release
.\build.ps1 -Platform x86 -Run
```

### Requirements

- Windows with .NET Framework 4.8.
- Visual Studio or Build Tools with **.NET desktop development**, the **.NET Framework 4.8 targeting pack**, and the .NET Framework SDK. The launcher uses Visual Studio's MSBuild.
- An Access database engine matching the application's architecture (64-bit or 32-bit). [Microsoft 365 Access Runtime](https://support.microsoft.com/en-us/access/download-and-install-microsoft-365-access-runtime) supplies the engine; match your existing Office installation.
- Internet access for the first Power Packs restore. Later builds use the local package cache.

Power Packs is restored from [VisualBasic.PowerPacks.Vs 1.0.0 on NuGet](https://www.nuget.org/packages/VisualBasic.PowerPacks.Vs/1.0.0), which contains the original Microsoft-signed assembly version 10.0.0.0. The launcher checks the package and assembly SHA-256 values. It references only the Power Packs assembly, keeping the framework's Visual Basic runtime. ADODB uses the installed original Microsoft interop assembly when available, with a Windows ADO COM-reference fallback.

## Database and login

The database lives at `MrDbillinventory\bin\MrDbase.accdb`. Builds never replace it or reset its accounts. The cashier opens directly; **Switch User** uses the administrator account stored in the database.

`DatabasePath` in `MrDbillinventory\App.config` defaults to `..\MrDbase.accdb`, resolved relative to the executable folder. You can set an absolute path or use the `MRD_DATABASE_PATH` environment variable. The environment variable takes priority, which is useful for a separate test database.

To deploy, copy the complete Release output folder (both DLLs and the executable configuration), provide a writable Access database, and set `DatabasePath` in `MrDbillinventory.exe.config`. Rebuilding regenerates that file from `App.config`.

The original forms use a fixed 1366 x 768 layout, so use a display large enough for the whole window.

## Verification

The smoke test works on a separate copy of the database under `.smoke-test`, keeps credentials out of its output, and suppresses receipt printing. Run it in Windows PowerShell 5.1 with STA and the architecture matching your driver:

```powershell
powershell.exe -NoProfile -STA -ExecutionPolicy Bypass -File .\scripts\smoke-test.ps1
powershell.exe -NoProfile -STA -ExecutionPolicy Bypass -File .\scripts\smoke-test.ps1 -FirstSale
```

It checks database initialization, forms, navigation, cart operations, and sales on the copy, then confirms that the original database's SHA-256 is unchanged. Physical printing still needs a check with your actual receipt printer.
