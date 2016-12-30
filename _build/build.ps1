if ((Test-Path $PSScriptRoot\packages\psake.4.6.0\tools\psake.psm1) -ne $true) {
	if (Get-Command "nuget" -ErrorAction SilentlyContinue) {
		nuget restore $PSScriptRoot\.nuget\packages.config -SolutionDirectory $PSScriptRoot
	}
    else {
		$storageDir = "$PSScriptRoot\packages"
        if ((Test-Path $storageDir) -ne $true) {
            New-Item -ItemType Directory -Force -Path $storageDir
        }
		$webclient = New-Object System.Net.WebClient
		$nugetUrl = "https://dist.nuget.org/win-x86-commandline/latest/nuget.exe"
		$file = "$storageDir\nuget.exe"
		$webclient.DownloadFile($nugetUrl, $file)
        if ($env:Path -notcontains "$PSScriptRoot\packages") {
		    $env:Path = "$env:Path;$storageDir"
        }

		if (Get-Command "nuget" -ErrorAction SilentlyContinue) {
			nuget restore $PSScriptRoot\.nuget\packages.config -SolutionDirectory $PSScriptRoot
		}
	}
}
if ($env:Path -notcontains "$PSScriptRoot\packages") {
    $env:Path = "$PSScriptRoot\packages"
}
Import-Module $PSScriptRoot\packages\psake.4.6.0\tools\psake.psm1 -force
if ($MyInvocation.UnboundArguments.Count -ne 0) {
    . $PSScriptRoot\psake.ps1 -taskList ($MyInvocation.UnboundArguments -join " ")
}
else {
    . $PSScriptRoot\build.ps1 Build
}
exit !($psake.build_success)