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

$testArgs = @{
    "-Framework" = $Framework
    "-Project" = $Project
    "-ClassTests" = $ClassTests
    "-CoverageSettings" = $settings
    "-EnvironmentVariables" = @("GQLPLUS_NO_ATTACHMENTS=true")
}
$test = New-DotnetTestArguments @testArgs

Clear-TestResults

dotnet @test
