dotnet tool restore
dotnet build
dotnet coverage collect --settings coverage.runsettings --output-format cobertura dotnet test --no-build
dotnet reportgenerator -reports:output.cobertura.xml -targetdir:.\coverage riskHotspotsAnalysisThresholds:metricThresholdForCyclomaticComplexity=20
dotnet livereloadserver coverage
