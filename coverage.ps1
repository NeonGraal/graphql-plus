[CmdletBinding()]
param (
  $Section = "",
  [switch]$IncludeTests = $false,
  [switch]$ClassTests = $false,
  [switch]$Html = $false,
  [switch]$Report = $false,
  $Framework = "10.0"
)

dotnet tool restore

dotnet build

if ($LASTEXITCODE -ne 0) {
  Write-Host "Build failed, exiting."
  exit $LASTEXITCODE
}

./just-coverage.ps1 -Section $Section -ClassTests:$ClassTests -IncludeTests:$IncludeTests -Framework $Framework

Write-Host "`n# Coverage Summary"
./make-summary.ps1 -Html:$Html -Framework $Framework -ClassTests:$ClassTests

if ($Report) {
  ./report.ps1 -Framework $Framework -ClassTests:$ClassTests
}
