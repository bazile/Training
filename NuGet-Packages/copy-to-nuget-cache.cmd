@echo off
IF NOT EXIST %LOCALAPPDATA%\NuGet\Cache GOTO :eof
echo copy "%~dp0*.nupkg" "%LOCALAPPDATA%\NuGet\Cache"
