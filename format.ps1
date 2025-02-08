prettier -w .
dotnet format whitespace --verbosity detailed --report format/whitespace-report.json
dotnet format style --verbosity detailed --report format/style-report.json
dotnet format analyzers --verbosity detailed --report format/analyzers-report.json
