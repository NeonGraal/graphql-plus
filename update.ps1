$clean = -not (git status -s)
dotnet outdated .\ -vl minor -u

$exclusions = "-exc","Basic.Reference.Assemblies","-exc","CodeAnalysis.CSharp"

if ($clean) {
    git commit -a -m "Update packages to latest patch version"
    dotnet outdated .\ -vl major -u @exclusions
} else {
    dotnet outdated .\ -vl major @exclusions
}

dotnet tool update --all

dotnet list package --deprecated
dotnet list package --vulnerable --include-transitive
dotnet outdated .\ @exclusions
