[CmdletBinding()]
param (
    [int]$Threshold = 20
)

$coverageFile = "$PWD/coverage/Coverage.xml"

$report = "-reporttypes:MarkdownSummaryGithub;Html;Badges","-reports:$coverageFile","-targetdir:.\coverage "
$report += "riskHotspotsAnalysisThresholds:metricThresholdForCyclomaticComplexity=$Threshold","riskHotspotsAnalysisThresholds:metricThresholdForCrapScore=$Threshold"

dotnet tool restore
dotnet reportgenerator @report
dotnet livereloadserver coverage --port 5300
