@echo off
rem TODO: Elevate itself before running

echo.>perfview.log

echo Running "VeryBadReverse" benchmark
perfview -GCOnly -DataFile:VeryBadReverse -LogFile:perfview.log -NoGui -AcceptEULA run bin\Release\StringReverse.exe VeryBadReverse
echo Done

echo Running "Reverse" benchmark
perfview -GCOnly -DataFile:Reverse -LogFile:perfview.log -NoGui -AcceptEULA run bin\Release\StringReverse.exe Reverse
echo Done
