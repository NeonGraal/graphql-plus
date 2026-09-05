[CmdletBinding()]
param (
  $Project = "",
  [switch]$IncludeTests = $false,
  [switch]$ClassTests = $false,
  [switch]$Html = $false,
  [switch]$Report = $false,
  $Framework = "10.0"
)

Import-Module "$PSScriptRoot\scripts\Common.psm1" -Force

Restore-DotnetTools

Invoke-DotnetBuild

if ($Project) {
  $ClassTests = $true
}

./just-coverage.ps1 -Project $Project -ClassTests:$ClassTests -IncludeTests:$IncludeTests -Framework $Framework

Write-Host "`n# Coverage Summary"
./make-summary.ps1 -Html:$Html -Framework $Framework -ClassTests:$ClassTests

if ($Report) {
  ./report.ps1 -Framework $Framework -ClassTests:$ClassTests
}
