param(
  [switch]$NoBuild
)

Import-Module "$PSScriptRoot\scripts\Common.psm1" -Force

if (-not $NoBuild) {
  Invoke-DotnetBuild
}

Get-ChildItem test -Filter "*.verified.*" -Recurse | Remove-Item -Force
Get-ChildItem test/Html/* -Directory | Remove-Item -Recurse -Force

$test = "-e","GQLPLUS_AUTOVERIFY=true","-f","net10.0"
if ($NoBuild) {
  $test += "--no-build"
}
$test += "--","--output","minimal","--report-xunit-trx"

dotnet test @test

Write-Host "`n"
./make-summary.ps1 -NoCoverage -Framework 10.0
