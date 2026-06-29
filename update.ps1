Write-Host "GitHub Actions ..."
npx --yes actions-up --mode minor --style preserve --yes

dotnet tool restore

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
if ($LASTEXITCODE -ne 0) {
  Write-Host "  -  Update with 'dotnet tool update (<tool> | --all)'"
}

Write-Host "GitHub Actions ..."
npx actions-up --style preserve --dry-run
if ($LASTEXITCODE -ne 0) {
  Write-Host "  -  Update with 'npx actions-up --style preserve'"
}
