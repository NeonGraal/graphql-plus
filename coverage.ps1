[CmdletBinding()]
param (
  $Section = "",
  [switch]$ClassTests = $false,
  [switch]$Html = $false,
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

if ($LASTEXITCODE -ne 0) {
  Write-Host "Build failed, exiting."
  exit $LASTEXITCODE
}

Get-ChildItem test -Filter 'TestResults' -Recurse -Directory | Remove-Item -Recurse -Force

dotnet coverage @collect -- dotnet @test

Write-Host "`n# Coverage Summary"
./make-summary.ps1 -Html:$Html

if ($Report) {
  ./report.ps1
}
