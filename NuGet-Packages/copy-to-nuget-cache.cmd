@echo off
IF NOT EXIST %LOCALAPPDATA%\NuGet\Cache GOTO :eof
copy "%~dp0*.nupkg" "%LOCALAPPDATA%\NuGet\Cache"
