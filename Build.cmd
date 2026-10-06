@echo off
setlocal
set "PSModulePath=%SystemRoot%\System32\WindowsPowerShell\v1.0\Modules;%PSModulePath%"
"%SystemRoot%\System32\WindowsPowerShell\v1.0\powershell.exe" -NoProfile -ExecutionPolicy Bypass -File "%~dp0build.ps1" %*
set "BuildExitCode=%errorlevel%"
if not "%BuildExitCode%"=="0" pause
exit /b %BuildExitCode%
