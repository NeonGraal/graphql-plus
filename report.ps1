[CmdletBinding()]
param (
  [switch]$Html = $false,
  [int]$Threshold = 20
)

$coverageFile = "$PWD/coverage/Coverage*.xml"

$report = "-reporttypes:MarkdownSummaryGithub;Html","-reports:$coverageFile","-targetdir:.\coverage "
$report += "riskHotspotsAnalysisThresholds:metricThresholdForCyclomaticComplexity=$Threshold","riskHotspotsAnalysisThresholds:metricThresholdForCrapScore=$Threshold"

dotnet tool restore
dotnet reportgenerator @report
if ($Html) {
  Start-Process test/Html/index.html
}

livereloadserver coverage --port 5300
