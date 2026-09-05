param(
  [switch]$NoBuild
)

Import-Module "$PSScriptRoot\scripts\Common.psm1" -Force

if (-not $NoBuild) {
  Invoke-DotnetBuild
}

Get-ChildItem test -Filter "*.verified.*" -Recurse | Remove-Item -Force
Get-ChildItem test/Html/* -Directory | Remove-Item -Recurse -Force

$test = New-DotnetTestArguments -Framework "10.0" -EnvironmentVariables "GQLPLUS_AUTOVERIFY=true" -NoBuild:$NoBuild

dotnet @test

Write-Host "`n"
./make-summary.ps1 -NoCoverage -Framework 10.0
