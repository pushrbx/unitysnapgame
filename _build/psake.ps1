Import-Module $PSScriptRoot\packages\psake.4.6.0\tools\psake.psm1 -force
Invoke-Expression("Invoke-psake build.targets.ps1 " + $MyInvocation.UnboundArguments -join " ")
exit !($psake.build_success)
