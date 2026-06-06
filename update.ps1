Write-Host "GitHub Actions ..."
npx actions-up --mode minor --yes

Write-Host "Nuget ..."
$clean = -not (git status -s)
dotnet outdated .\ -vl minor -u

$exclusions = "-exc","Basic.Reference.Assemblies","-exc","CodeAnalysis.CSharp"

if ($clean) {
    git commit -a -m "Update packages to latest patch version"
    dotnet outdated .\ -vl major -u @exclusions
} else {
    dotnet outdated .\ -vl major @exclusions
}

dotnet list package --deprecated
dotnet list package --vulnerable --include-transitive

Write-Host "Nuget ..."
dotnet outdated .\ @exclusions

Write-Host "Dotnet Tools ..."
dotnet tools-outdated
Write-Host "  -  Update with 'dotnet tool update (<tool> | --all)'"

Write-Host "GitHub Actions ..."
npx actions-up --dry-run
Write-Host "  -  Update with 'npx actions-up'"
