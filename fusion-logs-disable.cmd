@ECHO OFF
echo Deleting ForceLog from HKLM\Software\Microsoft\Fusion
reg delete HKLM\Software\Microsoft\Fusion /f /v ForceLog
echo.
echo Deleting LogPath from HKLM\Software\Microsoft\Fusion
reg delete HKLM\Software\Microsoft\Fusion /f /v LogPath
