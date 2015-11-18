@echo off
IF NOT EXIST "%LOCALAPPDATA%" GOTO :eof
IF NOT EXIST "%LOCALAPPDATA%\NuGet\Cache" mkdir "%LOCALAPPDATA%\NuGet\Cache"
copy "%~dp0*.nupkg" "%LOCALAPPDATA%\NuGet\Cache"
pause
