[CmdletBinding()]
param (
    $Section = "",
    [int]$Threshold = 20
)

$coverageFile = "$PWD/coverage/Coverage.xml"
$collect = "-o",$coverageFile,"-f","cobertura","-s","coverage.runsettings"
$coverage = "test","--no-build","--logger:trx;LogFileName=TestResults.trx"

if ($Section) {
  $coverage = $coverage + @("--filter", "FullyQualifiedName~.$Section.")
}

$report = "-reporttypes:MarkdownSummaryGithub;Html;Badges","-reports:$coverageFile","-targetdir:.\coverage "
$report += "riskHotspotsAnalysisThresholds:metricThresholdForCyclomaticComplexity=$Threshold","riskHotspotsAnalysisThresholds:metricThresholdForCrapScore=$Threshold"

dotnet tool restore
dotnet build
dotnet coverage collect @collect -- dotnet @coverage
dotnet reportgenerator @report
./make-summary.ps1
dotnet livereloadserver coverage --port 5300
