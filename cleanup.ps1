#Set-ExecutionPolicy -ExecutionPolicy unrestricted -scope process

if (!(Get-Command "Get-ScriptDirectory" -errorAction SilentlyContinue))
{
    function Get-ScriptDirectory
    {
        $Invocation = (Get-Variable MyInvocation -Scope 1).Value
        Split-Path $Invocation.MyCommand.Path
    }
}

$root = Get-ScriptDirectory

$dirToClean = $root + "\CSharp"
Write-Host "Cleaning", $dirToClean
# Delete bin and obj folders
dir $dirToClean -r | where { $_ -is [System.IO.DirectoryInfo] } | where { $_.Name -eq "bin" -or $_.Name -eq "obj"} | % { $_.Delete($true) }

$dirToClean = $root + "\Homework-Tests"
Write-Host "Cleaning", $dirToClean
# Delete bin and obj folders
dir $dirToClean -r | where { $_ -is [System.IO.DirectoryInfo] } | where { $_.Name -eq "bin" -or $_.Name -eq "obj"} | % { $_.Delete($true) }

