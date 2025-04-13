[CmdletBinding()]
param (
  [switch]$AutoVerify = $false,
  $SpecPath = "../graphql-plus.github.io"
)

$source = Join-Path $SpecPath "samples"
$dest = "test/GqlPlus.ComponentTestBase/Samples"

Push-Location $source
try {
  $gitDetails = git show -s --format="%h %d %as %s"
}
finally {
  Pop-Location
}

Remove-Item $dest -Recurse -Force -ErrorAction Ignore
New-Item $dest -ItemType Directory -Force | Out-Null

$gitDetails | Set-Content "$dest/git-details.txt"

Get-ChildItem $source -Recurse -Exclude "*.md","*.yml" | ForEach-Object {
  $relative = Resolve-Path -RelativeBasePath $source -Relative $_
  $to = Join-Path $dest $relative
  Copy-Item $_ $to -Force
}

if ($AutoVerify) {
  ./autoverify.ps1
}
