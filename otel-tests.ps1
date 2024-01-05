[CmdletBinding()]
param (
  [switch]$Keep = $false
)

dotnet publish -r win-x64 -o .\publish

if (!$Keep) {
  Remove-Item .\auto-logs\ -Force -Recurse -ErrorAction Ignore
}

Push-Location .\publish
try {
  dotnet vstest .\GqlPlus.Verifier.*Tests.dll /settings:../otel.runsettings
}
finally {
  Pop-Location
}