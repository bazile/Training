@powershell -noprofile -ExecutionPolicy unrestricted -Command "Get-ChildItem -include packages.config -Recurse | ForEach-Object { $xml = [xml](Get-Content $_); $xml.packages.package; } | ForEach-Object { $_.Id + ' v' + $_.Version; } | Get-Unique | Sort-Object"

