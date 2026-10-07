[CmdletBinding()]
param (
  $Project = "",
  $Section = "",
  $Filter = "",
  [ValidateSet('Html', 'Plain', 'Yaml', 'Json')]
  $Generate = "",
  [switch]$NoBuild = $false,
  [switch]$ClassTests = $false,
  [switch]$Html = $false,
  $Framework = "10.0"
)

Import-Module "$PSScriptRoot\scripts\Common.psm1" -Force

if (-not $NoBuild) {
  Invoke-DotnetBuild
}

$testArgs = @{
    "-Framework" = $Framework
    "-Project" = $Project
    "-ClassTests" = $ClassTests
#    "-EnvironmentVariables" = @("GQLPLUS_TEST_LOGGING=1", "GQLPLUS_NO_ATTACHMENTS=true")
    "-EnvironmentVariables" = @("GQLPLUS_NO_ATTACHMENTS=true")
}
$test = New-DotnetTestArguments @testArgs

if ($Generate) {
  $test += "--filter-trait", "Generate=$Generate"
}
if ($Section) {
  $test += "--filter-namespace", "*$Section*"
}
if ($Filter) {
  $test += "--filter-method", "*$Filter*"
}

Clear-TestResults
if ($Generate -eq "Html") {
  Get-ChildItem test/Html -Recurse -Exclude index.html | Remove-Item -Recurse -Force -ErrorAction Ignore
}

# $test += "--report-trx"

dotnet @test

Write-Host ""

if (-not $ClassTests) {
  ./check-links.ps1
  if (-not $?) {
    exit 1
  }
}

./make-summary.ps1 -NoCoverage -Html:$Html -Framework $Framework -ClassTests:$ClassTests -ShowFailures
