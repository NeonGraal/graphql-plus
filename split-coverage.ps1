dotnet tool restore
dotnet build

New-Item cobertura -ItemType Directory -ErrorAction Ignore | Out-Null

$sections = "BuiltInTests DependencyInjectionTests SampleTests Verification Parse TokenizerTests Result Merging Ast" -split ' '

$base = "-s","coverage.runsettings","-f","cobertura","-o"
$dotnet = "--","dotnet","test","--no-build","--filter"

foreach ($section in $sections) {
  $params = $base + @("cobertura/$section.xml","-id",$section) + $dotnet + @(".$section.")
  dotnet coverage collect @params
}

dotnet reportgenerator -reports:cobertura/*.xml -targetdir:.\coverage-split riskHotspotsAnalysisThresholds:metricThresholdForCyclomaticComplexity=20
livereloadserver coverage-split
