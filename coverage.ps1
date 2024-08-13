[CmdletBinding()]
param (
    $Section = ""
)

$coverageFile = "$PWD/coverage/Coverage.xml"
$collect = "-o",$coverageFile,"-f","cobertura","-s","coverage.runsettings"
$coverage = "test","--no-build","--logger:trx;LogFileName=TestResults.trx"

if ($Section) {
  $coverage = $coverage + @("--filter", "FullyQualifiedName~.$Section.")
}

dotnet tool restore
dotnet build
dotnet coverage collect @collect -- dotnet @coverage

Write-Host "`n# Coverage Summary"
./make-summary.ps1
