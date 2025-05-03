[CmdletBinding()]
param (
  $Section = "",
  [switch]$ClassTests = $false,
  [switch]$Html = $false,
  $Framework = "net9.0"
)

$test = "test","-e","GQLPLUS_TEST_LOGGING=1","--no-build"
$test += "--logger","trx;LogFileName=TestResults.trx","--framework",$Framework

if ($Section) {
  $test += "--filter", ".$Section."
}
if ($ClassTests) {
  $test += @("GqlPlus.ClassTests.slnf")
}

dotnet build

if ($LASTEXITCODE -ne 0) {
  Write-Host "Build failed, exiting."
  exit $LASTEXITCODE
}

Get-ChildItem test -Filter 'TestResults' -Recurse -Directory | Remove-Item -Recurse -Force

dotnet @test

./make-summary.ps1 -NoCoverage -Html:$Html
