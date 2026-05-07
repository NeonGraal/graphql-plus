[CmdletBinding()]
param (
  [switch]$AutoVerify = $false,
  $SpecPath = "../graphql-plus.github.io"
)

$source = Join-Path $SpecPath "samples"
$dest = "test/GqlPlus.ComponentTestBase/Samples"
$models = "src/GqlPlus.Models/Models"

Push-Location $source
try {
  $gitDetails = git show -s --format="%h %d %as %s"
}
finally {
  Pop-Location
}

Remove-Item $dest -Recurse -Force -ErrorAction Ignore
Remove-Item "$models/*.graphql+" -Recurse -Force -ErrorAction Ignore
New-Item $dest -ItemType Directory -Force | Out-Null

$gitDetails | Set-Content "$dest/git-details.txt"

Get-ChildItem $source -Recurse -Exclude "*.md","*.yml" | ForEach-Object {
  $relative = Resolve-Path -RelativeBasePath $source -Relative $_
  $to = Join-Path $dest $relative
  Copy-Item $_ $to -Force

  if ($relative -match '.*Introspection[/\\]-.*\.graphql+') {
    $fileName = Split-Path $relative -Leaf
    $to = Join-Path $models $fileName
    Copy-Item $_ $to -Force
  }
}

if ($AutoVerify) {
  ./autoverify.ps1
}
