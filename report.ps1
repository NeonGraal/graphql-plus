[CmdletBinding()]
param (
  [int]$Threshold = 20,
  $Framework = "9.0"
)

$coverageFile = "$PWD/coverage/Coverage-$Framework*.xml"

$report = "-reporttypes:MarkdownSummaryGithub;Html","-reports:$coverageFile","-targetdir:.\coverage"
$report += "settings:rawMode=true","-title:GqlPlus Coverage Report ($Framework)"
$report += "riskHotspotsAnalysisThresholds:metricThresholdForCyclomaticComplexity=$Threshold","riskHotspotsAnalysisThresholds:metricThresholdForCrapScore=$Threshold"

dotnet tool restore
dotnet reportgenerator @report

livereloadserver coverage --port 5300
