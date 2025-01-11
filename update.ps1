$clean = -not (git status -s)
dotnet outdated .\ -vl minor -u
if ($clean) {
    git commit -a -m "Update packages to latest patch version"
    dotnet outdated .\ -vl major -u
} else {
    dotnet outdated .\ -vl major
}
dotnet outdated .\

dotnet tool update --tool-manifest .\.config/dotnet-tools-ci.json --all
dotnet tool update --all

dotnet tools-outdated
