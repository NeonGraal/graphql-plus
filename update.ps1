$clean = -not (git status -s)
dotnet outdated .\ -vl minor -u
if ($clean) {
    git commit -a -m "Update packages to latest patch version"
    dotnet outdated .\ -vl major -u -exc CodeAnalysis.CSharp
} else {
    dotnet outdated .\ -vl major -exc CodeAnalysis.CSharp
}

dotnet tool update --all

dotnet list package --deprecated
dotnet list package --vulnerable --include-transitive
dotnet outdated .\ -exc CodeAnalysis.CSharp
