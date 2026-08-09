param(
  [switch]$Verify,
  [switch]$OnlyBiome
)

$ErrorActionPreference = "Stop"
Set-StrictMode -Version Latest

New-Item -ItemType Directory -Path "format" -Force | Out-Null

$BiomeArgs = if ($Verify) { @("check", ".") } else { @("format", "--write", ".") }
& npx --yes biome @BiomeArgs

if ($OnlyBiome) { exit }

$dotnetVerifyArgs = if ($Verify) { @("--verify-no-changes") } else { @() }

& dotnet format whitespace --verbosity detailed @dotnetVerifyArgs --report format/whitespace-report.json GqlPlus.slnx
& dotnet format style --verbosity detailed --severity info @dotnetVerifyArgs --report format/style-report.json GqlPlus.slnx
& dotnet format analyzers --verbosity detailed --severity info @dotnetVerifyArgs --report format/analyzers-report.json GqlPlus.slnx
