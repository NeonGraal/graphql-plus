param(
  [switch]$Verify,
  [switch]$OnlyPrettier
)

$ErrorActionPreference = "Stop"
Set-StrictMode -Version Latest

New-Item -ItemType Directory -Path "format" -Force | Out-Null

$prettierArgs = if ($Verify) { @("-c", ".") } else { @("-w", ".") }
& npx prettier @prettierArgs

if ($OnlyPrettier) { exit }

$dotnetVerifyArgs = if ($Verify) { @("--verify-no-changes") } else { @() }

& dotnet format whitespace --verbosity detailed @dotnetVerifyArgs --report format/whitespace-report.json GqlPlus.slnx
& dotnet format style --verbosity detailed --severity info @dotnetVerifyArgs --report format/style-report.json GqlPlus.slnx
& dotnet format analyzers --verbosity detailed --severity info @dotnetVerifyArgs --report format/analyzers-report.json GqlPlus.slnx
