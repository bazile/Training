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

Write-Host "Cleaning", $root

# Delete bin and obj folders
dir $root -r | where { $_ -is [System.IO.DirectoryInfo] } | where { $_.Name -eq "bin" -or $_.Name -eq "obj"} | % { $_.Delete($true) }
