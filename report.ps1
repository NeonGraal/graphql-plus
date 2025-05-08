[CmdletBinding()]
param (
  [int]$Threshold = 20
)

$coverageFile = "$PWD/coverage/Coverage*.xml"

$report = "-reporttypes:MarkdownSummaryGithub;Html","-reports:$coverageFile","-targetdir:.\coverage","settings:rawMode=true"
$report += "riskHotspotsAnalysisThresholds:metricThresholdForCyclomaticComplexity=$Threshold","riskHotspotsAnalysisThresholds:metricThresholdForCrapScore=$Threshold"

dotnet tool restore
dotnet reportgenerator @report

livereloadserver coverage --port 5300
