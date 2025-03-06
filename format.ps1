prettier -w .
dotnet format whitespace --verbosity detailed --report format/whitespace-report.json GqlPlus.sln
dotnet format style --verbosity detailed --report format/style-report.json GqlPlus.sln
dotnet format analyzers --verbosity detailed --report format/analyzers-report.json GqlPlus.sln
