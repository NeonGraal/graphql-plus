[CmdletBinding()]
param (
  $Project = "",
  [switch]$IncludeTests = $false,
  [switch]$ClassTests = $false,
  $Framework = "10.0"
)

Import-Module "$PSScriptRoot\scripts\Common.psm1" -Force

$settings = "coverage.runsettings"
if ($IncludeTests)
{
  $settings = "tests-coverage.runsettings"
}

$file = "results-$Framework/Coverage.xml"
$coverage = "collect","-o",$file,"-f","cobertura","-s",$settings,"-l","coverage.log"

$testArgs = @{
    "-Framework" = $Framework
    "-Project" = $Project
    "-ClassTests" = $ClassTests
    "-EnvironmentVariables" = @("GQLPLUS_NO_ATTACHMENTS=true")
}
$test = New-DotnetTestArguments @testArgs

Clear-TestResults
Restore-DotnetTools

Write-Host @("Coverage", $coveragem, "Test", $test ) -join ' '
dotnet coverage @coverage -- dotnet test @test
