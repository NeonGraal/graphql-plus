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

$test = "test","-e","GQLPLUS_TEST_LOGGING=1","--framework","net$Framework","--no-build"
# $test += "--logger","trx;LogFileName=TestResults-$Framework.trx","--framework","net$Framework"
if ($ClassTests) {
  $test += @("GqlPlus.ClassTests.slnf")
}

$test += "--","--report-xunit-trx","--report-xunit-trx-filename","TestResults-{tfm}.trx"

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
  dotnet build

  if ($LASTEXITCODE -ne 0) {
    Write-Host "Build failed, exiting."
    exit $LASTEXITCODE
  }
}

Get-ChildItem test -Filter 'TestResults' -Recurse -Directory | Remove-Item -Recurse -Force -ErrorAction Ignore
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
