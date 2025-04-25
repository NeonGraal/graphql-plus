[CmdletBinding()]
param (
  $Section = "",
  [switch]$ClassTests = $false,
  [switch]$Html = $false,
  $Framework = "net9.0"
)

$test = "test","--no-build","--logger","trx;LogFileName=TestResults.trx","--framework",$Framework

if ($Section) {
  $test += @("--filter", ".$Section.")
}
if ($ClassTests) {
  $test += @("GqlPlus.ClassTests.slnf")
}

dotnet build
dotnet @test

if ($Html) {
  Start-Process test/Html/index.html
}

./make-summary.ps1 -NoCoverage
