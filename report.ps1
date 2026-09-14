[CmdletBinding()]
param (
  [int]$Threshold = 15,
  [switch]$ClassTests = $false,
  $Framework = "10.0"
)

Import-Module "$PSScriptRoot\scripts\Common.psm1" -Force

$coverageFile = "$PWD/coverage/Coverage-$Framework*.xml"
$testSet = Get-TestSetLabel -ClassTests:$ClassTests

$report = "-reporttypes:MarkdownSummaryGithub;Html","-reports:$coverageFile","-targetdir:.\coverage"
$report += "settings:rawMode=true","-title:GqlPlus Coverage Report ($Framework $testSet tests)"
$report += "riskHotspotsAnalysisThresholds:metricThresholdForCyclomaticComplexity=$Threshold","riskHotspotsAnalysisThresholds:metricThresholdForCrapScore=$Threshold"

Restore-DotnetTools
dotnet reportgenerator @report

livereloadserver coverage --port 5300
