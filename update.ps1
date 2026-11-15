[CmdletBinding()]
param (
  [switch]$DryRun = $false
)

$exclusions = "-exc","Basic.Reference.Assemblies","-exc","Microsoft.CodeAnalysis"

if (-not $DryRun) {
  Write-Host "GitHub Actions ..."
    npx --yes actions-up --mode minor --style preserve --yes

    Import-Module "$PSScriptRoot\scripts\Common.psm1" -Force

    Restore-DotnetTools

    Write-Host "Nuget ..."
    $status = @(git status -sb)
    $branch = ($status[0] -split ' |\.')[1]
    $clean = $status.Length -eq 1
    dotnet outdated .\ -vl minor -u

    if ($clean) {
        if ($branch -eq 'main') {
            $date = Get-Date -Format 'dd-MM-yy'
            git switch -c "updates-$date"
        }

        git commit -a -m "Update packages to latest patch version"
        dotnet outdated .\ -vl major -u
    } else {
        dotnet outdated .\ -vl major
    }

    dotnet list package --deprecated
    dotnet list package --vulnerable --include-transitive

    dprint fmt
} else {
    Write-Host "Nuget ..."
}

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
