dotnet outdated .\ -vl minor -u
dotnet outdated .\

dotnet tool update --tool-manifest .\.config\dotnet-tools-ci.json --all
dotnet tool update --all

dotnet tools-outdated
