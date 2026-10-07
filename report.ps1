[CmdletBinding()]
param (
  [int]$Threshold = 15,
  [switch]$ClassTests = $false,
  $Framework = "10.0"
)

Import-Module "$PSScriptRoot\scripts\Common.psm1" -Force

$coverageDir = "results-$Framework"
$coverageFile = "$coverageDir/Cobertura.xml"
$testSet = Get-TestSetLabel -ClassTests:$ClassTests

$report = "-reporttypes:MarkdownSummaryGithub;Html","-reports:$coverageFile","-targetdir:$coverageDir"
$report += "settings:rawMode=true","-title:GqlPlus Coverage Report ($Framework $testSet tests)"
$report += "riskHotspotsAnalysisThresholds:metricThresholdForCyclomaticComplexity=$Threshold","riskHotspotsAnalysisThresholds:metricThresholdForCrapScore=$Threshold"

Restore-DotnetTools
dotnet reportgenerator @report

livereloadserver $coverageDir --port 5300
