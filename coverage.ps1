[CmdletBinding()]
param (
    $Section = ""
)

$coverageFile = "$PWD/coverage/Coverage.xml"
$collect = "collect","-o",$coverageFile,"-f","cobertura","-s","coverage.runsettings"
$test = "test","--no-build","--logger:trx;LogFileName=TestResults.trx","--framework","net9.0"

if ($Section) {
  $test = $test + @("--filter", "FullyQualifiedName~.$Section.")
}

dotnet tool restore
dotnet build
dotnet coverage @collect -- dotnet @test

Write-Host "`n# Coverage Summary"
./make-summary.ps1
