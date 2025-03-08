$clean = -not (git status -s)
dotnet outdated .\ -vl minor -u
if ($clean) {
    git commit -a -m "Update packages to latest patch version"
    dotnet outdated .\ -vl major -u
} else {
    dotnet outdated .\ -vl major
}

dotnet tool update --all

dotnet list package --deprecated
dotnet list package --vulnerable --include-transitive
dotnet outdated .\
