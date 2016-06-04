@echo off
IF NOT EXIST "%LOCALAPPDATA%" GOTO :eof
IF NOT EXIST "%LOCALAPPDATA%\NuGet\Cache" mkdir "%LOCALAPPDATA%\NuGet\Cache"

echo NuGet cache path: %LOCALAPPDATA%\NuGet\Cache
echo.

copy "%~dp0*.nupkg" "%LOCALAPPDATA%\NuGet\Cache"
pause
