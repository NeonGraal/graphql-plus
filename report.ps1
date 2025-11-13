[CmdletBinding()]
param (
  [int]$Threshold = 20,
  [switch]$ClassTests = $false,
  $Framework = "10.0"
)

$coverageFile = "$PWD/coverage/Coverage-$Framework*.xml"
$testSet = "All"
if ($ClassTests) {
  $testSet = "Class"
}

$report = "-reporttypes:MarkdownSummaryGithub;Html","-reports:$coverageFile","-targetdir:.\coverage"
$report += "settings:rawMode=true","-title:GqlPlus Coverage Report ($Framework $testSet tests)"
$report += "riskHotspotsAnalysisThresholds:metricThresholdForCyclomaticComplexity=$Threshold","riskHotspotsAnalysisThresholds:metricThresholdForCrapScore=$Threshold"

dotnet tool restore
dotnet reportgenerator @report

livereloadserver coverage --port 5300
