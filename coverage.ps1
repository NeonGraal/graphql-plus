[CmdletBinding()]
param (
    $Section = "",
    [int]$Threshold = 20
)

$coverage = "test","--no-build"

if ($Section) {
  $coverage = $coverage + @("--filter", "FullyQualifiedName~.$Section.")
}

$report = "riskHotspotsAnalysisThresholds:metricThresholdForCyclomaticComplexity=$Threshold","riskHotspotsAnalysisThresholds:metricThresholdForCrapScore=$Threshold"

dotnet tool restore
dotnet build
dotnet coverage collect --settings coverage.runsettings -- dotnet @coverage
dotnet reportgenerator -reports:output.cobertura.xml -targetdir:.\coverage @report
dotnet livereloadserver coverage
