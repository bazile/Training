@ECHO OFF
CHOICE /m "Enable CLR binding logging"
IF ERRORLEVEL 2 GOTO :eof

echo.
echo Adding HKLM\Software\Microsoft\Fusion, ForceLog = 1
reg add HKLM\Software\Microsoft\Fusion /f /v ForceLog /t REG_DWORD /d 1

echo.
echo Adding HKLM\Software\Microsoft\Fusion, LogPath = %SystemDrive%\FusionLogs
reg add HKLM\Software\Microsoft\Fusion /f /v LogPath /t REG_SZ /d "%SystemDrive%\FusionLogs"
