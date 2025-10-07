[CmdletBinding()]
param (
  $Section = "",
  [switch]$IncludeTests = $false,
  [switch]$ClassTests = $false,
  $Framework = "9.0"
)

$coverageFile = "$PWD/coverage/Coverage-$Framework.xml"
$testResults = "TestResults-$Framework.trx"
$collect = "collect","-o",$coverageFile,"-f","cobertura"
$settings = "-s","coverage.runsettings"
$test = "test","--no-build","--logger","trx;LogFileName=$testResults","--framework","net$Framework"

if ($Section) {
  $test += @("--filter", ".$Section.")
}
if ($ClassTests) {
  $test += @("GqlPlus.ClassTests.slnf")
}
if ($IncludeTests) {
  $settings = "-s","tests-coverage.runsettings"
}

Get-ChildItem coverage -File | Remove-Item -Recurse -Force -ErrorAction Ignore
Get-ChildItem test -Filter 'TestResults' -Recurse -Directory | Remove-Item -Recurse -Force -ErrorAction Ignore

dotnet coverage @collect @settings -- dotnet @test
