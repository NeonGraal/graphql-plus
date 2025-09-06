[CmdletBinding()]
param (
  $Section = "",
  $Filter = "",
  [ValidateSet('Html', 'Plain', 'Yaml', 'Json')]
  $Generate = "",
  [switch]$ClassTests = $false,
  [switch]$Html = $false,
  $Framework = "9.0"
)

$test = "test","-e","GQLPLUS_TEST_LOGGING=1","--no-build"
$test += "--logger","trx;LogFileName=TestResults-$Framework.trx","--framework","net$Framework"

if ($Generate) {
  $test += "--filter", "Generate=$Generate"
} elseif ($Section) {
  $test += "--filter", ".$Section."
} elseif ($Filter) {
  $test += "--filter", $Filter
}
if ($ClassTests) {
  $test += @("GqlPlus.ClassTests.slnf")
}

dotnet build

if ($LASTEXITCODE -ne 0) {
  Write-Host "Build failed, exiting."
  exit $LASTEXITCODE
}

Get-ChildItem test -Filter 'TestResults' -Recurse -Directory | Remove-Item -Recurse -Force -ErrorAction Ignore
if ($Generate -eq "Html") {
  Get-ChildItem test/Html -Exclude index.html | Remove-Item -Recurse -Force -ErrorAction Ignore
}

dotnet @test

./make-summary.ps1 -NoCoverage -Html:$Html -Framework $Framework -ClassTests:$ClassTests
