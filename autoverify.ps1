Get-ChildItem test -Filter "*.verified.*" -Recurse | Remove-Item -Force
dotnet test -e GQLPLUS_AUTOVERIFY=true
prettier -w .
