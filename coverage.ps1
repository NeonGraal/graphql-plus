dotnet tool restore
dotnet build
dotnet coverage collect -f cobertura dotnet test --no-build
dotnet reportgenerator -reports:output.cobertura.xml -targetdir:.\coverage
dotnet livereloadserver coverage
