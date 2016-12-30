Properties {
    $rootDir = Split-Path $psake.build_script_file
    $srcDir = "$rootDir\.."
    $solutionFile = "$srcDir\AwesomeSnapGame.sln"
    $logicProjFiles = "$srcDir\Logic\SnapGameLogic\SnapGameLogic.csproj", "$srcDir\Logic\SnapGameLogicTests\SnapGameLogicTests.csproj"
    $testDir = "$srcDir\Logic\SnapGameLogicTests"
    $slns = ls "$srcDir\*.sln"
    $packagesDir = "$srcDir\packages"
    $buildNumber = [Convert]::ToInt32($env:BUILD_BUILDNUMBER).ToString("0000")
    $logDir = "$rootDir\log"
    $configuration = (&{if($isRelease) {"Release"} else {"Debug"}})
	$isCi = $env:CONTINOUS_INTEGRATION -eq $true
	$isRelease = $isCi -and ($env:CI_REPO_BRANCH -eq "master")
}

FormatTaskName (("-"*25) + "[{0}]" + ("-"*25))

Task Default -Depends Build, Test

Task Rebuild -Depends Clean, Build

Task Restore {
    if ($buildNumber -eq "0000") {
        $buildNumber = [System.DateTime]::Now.ToFileTime().ToString()
    }
    Write-Host "Build number: $buildNumber" -ForegroundColor Green
    Foreach($sln in $slns) {
        RestorePkgs $sln
    }
}

# todo: nuget, update nuspec
Task Prepare-Build -depends Restore

Task Build-Backend -depends Prepare-Build {
    BuildListOfProjectFiles $backEndProjFiles
}

Task Build-Frontend -depends Prepare-Build {
    BuildListOfProjectFiles $frontEndProjFiles
}

Task Build -depends Prepare-Build, Build-Only

Task Build-Only -depends Build-Frontend, Build-Backend

Task Clean {
    Exec { msbuild $solutionFile /t:Clean /v:quiet }
}

Task Set-Log {
    if ((Test-Path $logDir) -eq $false)
    {
        Write-Host -ForegroundColor DarkBlue "Creating log directory $logDir"
        mkdir $logDir | Out-Null
    }
}

Task Test -depends Set-Log {
    RunTest "$testDir\$testDll"
}

function BuildListOfProjectFiles($projectFiles) {
    foreach($proj in $projectFiles) {
        if ((Test-Path $proj) -eq $true) {
            Exec { msbuild $proj /m /fl /verbosity:minimal /p:AllowUnsafeBlocks=true /p:Configuration=$configuration }
        }
    }
}

function RestorePkgs($sln) {
    Write-Host "Restoring $sln..." -ForegroundColor Green
    if (Get-Command "nuget" -ErrorAction SilentlyContinue) {
        Write-Host "Nuget found in PATH." -ForegroundColor Green
    }
    else {
        Write-Host "Nuget not found in PATH. Trying to restore it..." -ForegroundColor Yellow
        . "$PSScriptRoot\scripts\Initialize-Environment.ps1" -RepoRoot $PSScriptRoot
    }
    if (-Not (Test-Path $sln)) {
        Write-Host "File $sln does not exist, exiting." -ForegroundColor DarkRed
        return
    }
    nuget restore $sln
}

function TestPath($paths) {
    $notFound = @()
    foreach($path in $paths) {
        if ((Test-Path $path) -eq $false)
        {
            $notFound += $path
        }
    }
    $notFound
}

function RunTest($fullTestDllPath) {

	# check if the vstest.console.exe is in the path or not
    if (Get-Command "vstest.console" -ErrorAction SilentlyContinue) {
        vstest.console /Framework:Framework35 /InIsolation $fullTestDllPath
    }
    else {

		if ($isCi -eq $FALSE) {
			# this is not a VSTS environment
			Write-Error "Could not find the vstest.console.exe in path and this is not a CI build environment. Can't run the tests. Aborting."
			exit 1
		}

        # lets try with vsts
        import-module "Microsoft.TeamFoundation.DistributedTask.Task.Internal"
        import-module "Microsoft.TeamFoundation.DistributedTask.Task.Common"
        import-module "Microsoft.TeamFoundation.DistributedTask.Task.TestResults"
        Write-Verbose -Verbose "Calling Invoke-VSTest for all test assemblies"

        # vsts and test specific sourcedir variable
        $sourcesDirectory = Get-TaskVariable -Context $distributedTaskContext -Name "Build.SourcesDirectory"
        if(!$sourcesDirectory)
        {
            # For RM, look for the test assemblies under the release directory.
            $sourcesDirectory = Get-TaskVariable -Context $distributedTaskContext -Name "Agent.ReleaseDirectory"
        }

        if(!$sourcesDirectory)
        {
            # If there is still no sources directory, error out immediately.
            Write-Host "##vso[task.logissue type=error;code=002002;]"
            throw (Get-LocalizedString -Key "No source directory found.")
        }
        
        $testAssemblyFiles = @()
        $testAssemblyFiles += ,($fullTestDllPath)

        $artifactsDirectory = Get-TaskVariable -Context $distributedTaskContext -Name "System.ArtifactsDirectory" -Global $FALSE
        $workingDirectory = $artifactsDirectory
        $testResultsDirectory = $workingDirectory + [System.IO.Path]::DirectorySeparatorChar + "TestResults"

        $defaultCpuCount = "0"
        Invoke-VSTest -TestAssemblies $testAssemblyFiles -WorkingFolder $workingDirectory -TestResultsFolder $testResultsDirectory

        # publish test results
        $resultFiles = Find-Files -SearchPattern "*.trx" -RootFolder $testResultsDirectory

        if($resultFiles)
        {
            Publish-TestResults -Context $distributedTaskContext -TestResultsFiles $resultFiles -TestRunner "VSTest" -Platform $platform -Configuration $configuration -RunTitle "pushrbx.storage Tests"
        }
        else
        {
            Write-Host "##vso[task.logissue type=warning;code=002003;]"
            Write-Warning (Get-LocalizedString -Key "No results found to publish.")
        }
    }
}