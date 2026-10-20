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

if ($Project -and -not (Test-Path test/GqlPlus.$Project.ClassTests))
{
    Write-Host "Project 'GqlPlus.$Project.ClassTests' does not exist"
    exit -1
}

$testArgs = @{
    "-Framework" = $Framework
    "-Project" = $Project
    "-ClassTests" = $ClassTests
#    "-EnvironmentVariables" = @("GQLPLUS_TEST_LOGGING=1", "GQLPLUS_NO_ATTACHMENTS=true")
    "-EnvironmentVariables" = @("GQLPLUS_NO_ATTACHMENTS=true")
}
$test = New-DotnetTestArguments @testArgs

$links = -not $Project
if ($Generate) {
  $test += "--filter-trait", "Generate=$Generate"
  $links = $false
}
if ($Section) {
  $test += "--filter-namespace", "*$Section*"
  $links = $false
}
if ($Filter) {
  $test += "--filter-method", "*$Filter*"
  $links = $false
}

Clear-TestResults
if ($Generate -eq "Html") {
  Get-ChildItem test/Html -Recurse -Exclude index.html | Remove-Item -Recurse -Force -ErrorAction Ignore
}

Write-Host "Test $($test -join ' ')"
dotnet test -bl:test.binlog @test

Write-Host ""

if ($links) {
  ./check-links.ps1 -ClassTests:$ClassTests
  if (-not $?) {
    exit 1
  }
}

./make-summary.ps1 -NoCoverage -Html:$Html -Framework $Framework -ClassTests:$ClassTests -ShowFailures
