@echo off
setlocal
set "PSModulePath=%SystemRoot%\System32\WindowsPowerShell\v1.0\Modules;%PSModulePath%"
"%SystemRoot%\System32\WindowsPowerShell\v1.0\powershell.exe" -NoProfile -ExecutionPolicy Bypass -File "%~dp0build.ps1" -Run %*
set "RunExitCode=%errorlevel%"
if not "%RunExitCode%"=="0" pause
exit /b %RunExitCode%
