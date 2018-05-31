@echo off
powershell -noprofile -ExecutionPolicy unrestricted -Command "Get-ChildItem -Recurse -Include AssemblyInfo.cs | ForEach-Object { $t = Get-Content $_.FullName; $t = $t -Replace('Copyright \u00a9 \d{4}-\d{4}', 'Copyright \u00a9 2012-2018'); Write-Host $_.FullName; Set-Content -Path $_.FullName -Value $t -Encoding UTF8; }"
