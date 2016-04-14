$scriptRoot = split-path -parent $MyInvocation.MyCommand.Definition

Add-Type -assembly "System.IO.Compression.FileSystem"

$packages = @( `
	@{'Name'= 'Humanizer.Core'                    ;                  }, `
	@{'Name'= 'Humanizer.Core.ru'                 ;                  }, `
	@{'Name'= 'Microsoft.Bcl'                     ;                  }, `
	@{'Name'= 'Microsoft.Bcl.Build'               ;                  }, `
	@{'Name'= 'Microsoft.WindowsAPICodePack-Core' ;                  }, `
	@{'Name'= 'Microsoft.WindowsAPICodePack-Shell';                  }, `
	@{'Name'= 'morelinq'                          ;                  }, `
	@{'Name'= 'NodaTime'                          ;                  }, `
	@{'Name'= 'NUnit'                             ; 'Version'='2.6.4'},  `
	@{'Name'= 'UDE.CSharp'                        ;                  }, `
	@{'Name'= 'UnconstrainedMelody'               ;                  }  `
)
foreach ($pkg in $packages) {
	$pkgName = $pkg.Name
	$tempPkgPath = "$env:temp\$pkgName.nupkg"
	
	if ($pkg.Version) {
		Write-Host "Downloading $pkgName v$($pkg.Version)"
		
		$web = new-object net.webclient
		$web.DownloadFile("https://www.nuget.org/api/v2/package/$pkgName/$($pkg.Version)", $tempPkgPath)
		$web.Dispose()
		
	} else {
		Write-Host "Downloading $pkgName"
		
		$web = new-object net.webclient
		$web.DownloadFile("https://www.nuget.org/api/v2/package/$pkgName", $tempPkgPath)
		$web.Dispose()
	}
	
	$arc = [io.compression.ZipFile]::OpenRead($tempPkgPath)
	$entry = $arc.GetEntry("$pkgName.nuspec")
	$reader = new-object io.StreamReader($entry.Open())
	[xml]$nuspec = $reader.ReadToEnd()
	$reader.Close()
	$arc.Dispose()
	
	$pkgVer = $nuspec.package.metadata.version
	
	Move-Item $tempPkgPath "$scriptRoot\$pkgName.$pkgVer.nupkg" -Force
}
