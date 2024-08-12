[CmdletBinding()]
param (
    $Section = "",
    [int]$Threshold = 20
)

$coverage = "test","--no-build","--logger:trx"

if ($Section) {
  $coverage = $coverage + @("--filter", "FullyQualifiedName~.$Section.")
}

$report = "-reporttypes:MarkdownSummaryGithub;Html;Badges","-reports:output.cobertura.xml","-targetdir:.\coverage "
$report += "riskHotspotsAnalysisThresholds:metricThresholdForCyclomaticComplexity=$Threshold","riskHotspotsAnalysisThresholds:metricThresholdForCrapScore=$Threshold"

dotnet tool restore
dotnet build
dotnet coverage collect --settings coverage.runsettings -- dotnet @coverage
dotnet reportgenerator @report
# dotnet livereloadserver coverage --port 5300
