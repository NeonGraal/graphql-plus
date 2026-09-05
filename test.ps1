[CmdletBinding()]
param (
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

$test = New-DotnetTestArguments -Framework $Framework -EnvironmentVariables "GQLPLUS_TEST_LOGGING=1" -NoBuild -ClassTests:$ClassTests

if ($Generate) {
  $test += "--trait-filter", "Generate=$Generate"
}
if ($Section) {
  $test += "--namespace-filter", "*$Section*"
}
if ($Filter) {
  $test += "--method-filter", "*$Filter*"
}

if (-not $NoBuild) {
  Invoke-DotnetBuild
}

Clear-TestResults
if ($Generate -eq "Html") {
  Get-ChildItem test/Html -Recurse -Exclude index.html | Remove-Item -Recurse -Force -ErrorAction Ignore
}

dotnet @test

Write-Host ""

if (-not $ClassTests) {
  ./check-links.ps1
  if (-not $?) {
    exit 1
  }
}

./make-summary.ps1 -NoCoverage -Html:$Html -Framework $Framework -ClassTests:$ClassTests -ShowFailures
