[CmdletBinding()]
param (
    $Section = "",
    [switch]$ClassTests = $false,
    [switch]$Report = $false,
    $Framework = "net9.0"
)

$coverageFile = "$PWD/coverage/Coverage.xml"
$collect = "collect","-o",$coverageFile,"-f","cobertura","-s","coverage.runsettings"
$test = "test","--no-build","--logger","trx;LogFileName=TestResults.trx","--framework",$Framework

if ($Section) {
  $test += @("--filter", ".$Section.")
}
if ($ClassTests) {
  $test += @("GqlPlus.ClassTests.slnf")
}

dotnet tool restore
dotnet build
dotnet coverage @collect -- dotnet @test

Write-Host "`n# Coverage Summary"
./make-summary.ps1

if ($Report) {
  ./report.ps1
}
