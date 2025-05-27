[CmdletBinding()]
param (
  $Section = "",
  [switch]$ClassTests = $false,
  $Framework = "9.0"
)

$coverageFile = "$PWD/coverage/Coverage-$Framework.xml"
$testResults = "TestResults-$Framework.trx"
$collect = "collect","-o",$coverageFile,"-f","cobertura","-s","coverage.runsettings"
$test = "test","--no-build","--logger","trx;LogFileName=$testResults","--framework","net$Framework"

if ($Section) {
  $test += @("--filter", ".$Section.")
}
if ($ClassTests) {
  $test += @("GqlPlus.ClassTests.slnf")
}

Get-ChildItem test -Filter 'TestResults' -Recurse -Directory | Remove-Item -Recurse -Force

dotnet coverage @collect -- dotnet @test
