[CmdletBinding()]
param (
    $Section = ""
)

$params = "test","--no-build"

if ($Section) {
  $params = $params + @("--filter", "FullyQualifiedName~.$Section.")
}

prettier -w .
dotnet tool restore
dotnet build
dotnet coverage collect --settings coverage.runsettings -- dotnet @params
dotnet reportgenerator -reports:output.cobertura.xml -targetdir:.\coverage riskHotspotsAnalysisThresholds:metricThresholdForCyclomaticComplexity=20
dotnet livereloadserver coverage
