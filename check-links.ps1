param(
    [string]$Entry = "test/Html/index.html",
    [string]$Root = "test/Html",
    [int]$MaxDepth = -1,
    [switch]$Verbose,
    [switch]$FailOnMissing
)

function Write-VerboseLine {
    param($msg)
    if ($Verbose) { Write-Host $msg }
}

function Get-LinksFromHtmlContent {
    param([string]$content)
    $links = New-Object System.Collections.Generic.List[string]

$attrPattern = @"
(?i)(?:href|src)\s*=\s*"([^"]+)"|(?:href|src)\s*=\s*'([^']+)'
"@
    $matches = [regex]::Matches($content, $attrPattern)
    foreach ($m in $matches) {
        $val = $m.Groups[1].Value
        if (-not $val) { $val = $m.Groups[2].Value }
        if ($val) { $links.Add($val) }
    }

$srcsetPattern = @"
(?i)srcset\s*=\s*"([^"]+)"|srcset\s*=\s*'([^']+)'
"@
    $matches = [regex]::Matches($content, $srcsetPattern)
    foreach ($m in $matches) {
        $val = $m.Groups[1].Value
        if (-not $val) { $val = $m.Groups[2].Value }
        if ($val) {
            foreach ($part in ($val -split ',')) {
                $candidate = ($part.Trim() -split '\s+')[0]
                if ($candidate) { $links.Add($candidate) }
            }
        }
    }

    return $links | Where-Object { $_ -and $_ -ne '' } | Select-Object -Unique
}

function Is-ExternalLink {
    param([string]$link)
    if ($link -match '^[#]') { return $true }
    if ($link -match '^(?i)(?:http|https|mailto|tel|javascript|data):') { return $true }
    if ($link -match '^//') { return $true }
    return $false
}

function Resolve-Link {
    param([string]$baseFile, [string]$link, [string]$rootDir)
    $link = $link.Trim()
    if ($link -eq '') { return $null }
    if ($link -like '#*') { return $null }
    if (Is-ExternalLink $link) { return $null }

    # strip query and fragment
    $clean = $link -replace '\?.*$','' -replace '#.*$',''
    if ($clean -eq '') { return $null }

    if ($clean.StartsWith('/')) {
        # treat as relative to repo root / project root: combine with rootDir
        $rel = $clean.TrimStart('/')
        $combined = Join-Path $rootDir $rel
    } else {
        $baseDir = Split-Path -Parent $baseFile
        $combined = Join-Path $baseDir $clean
    }

    try {
        return [System.IO.Path]::GetFullPath($combined)
    } catch { return $combined }
}

function Is-UnderRoot {
    param([string]$path, [string]$root)
    try {
        $p = [System.IO.Path]::GetFullPath($path).TrimEnd('\')
        $r = [System.IO.Path]::GetFullPath($root).TrimEnd('\')
        return $p.StartsWith($r, [System.StringComparison]::OrdinalIgnoreCase)
    } catch { return $false }
}

if (-not (Test-Path -LiteralPath $Entry)) { Write-Host "Entry file not found: $Entry" -ForegroundColor Red; exit 2 }
if (-not (Test-Path -LiteralPath $Root)) { Write-Host "Root directory not found: $Root" -ForegroundColor Red; exit 2 }

$rootHtmlFull = [System.IO.Path]::GetFullPath($Entry)
$rootDirFull = [System.IO.Path]::GetFullPath($Root)

$visited = [System.Collections.Generic.HashSet[string]]::new()
$queue = [System.Collections.Generic.Queue[object]]::new()
$queue.Enqueue((New-Object PSObject -Property @{ Path = $rootHtmlFull; Depth = 0 }))

$broken = New-Object System.Collections.Generic.List[psobject]
$totalLinks = 0

while ($queue.Count -gt 0) {
    $item = $queue.Dequeue()
    $file = $item.Path
    $depth = $item.Depth
    if ($visited.Contains($file)) { continue }
    $visited.Add($file) | Out-Null

    Write-VerboseLine "Scanning: $file"
    try { $content = Get-Content -Raw -LiteralPath $file -ErrorAction Stop } catch { $broken.Add([pscustomobject]@{ Source=$file; Link='(file-read)'; Resolved='(unreadable)'; Reason='Cannot read file' }); continue }

    $links = Get-LinksFromHtmlContent -content $content
    foreach ($link in $links) {
        $totalLinks++
        $resolved = Resolve-Link -baseFile $file -link $link -rootDir $rootDirFull
        if (-not $resolved) { continue }

        $exists = Test-Path -LiteralPath $resolved -PathType Any
        if (-not $exists) {
            $broken.Add([pscustomobject]@{ Source=$file; Link=$link; Resolved=$resolved; Reason='Not found' })
        } else {
            Write-VerboseLine "OK: $file -> $link"
            $ext = [System.IO.Path]::GetExtension($resolved).ToLower()
            if (($ext -eq '.html' -or $ext -eq '.htm') -and (Is-UnderRoot $resolved $rootDirFull)) {
                if ($MaxDepth -lt 0 -or $depth -lt $MaxDepth) {
                    if (-not $visited.Contains($resolved)) { $queue.Enqueue((New-Object PSObject -Property @{ Path = $resolved; Depth = $depth + 1 })) }
                }
            }
        }
    }
}

Write-Host "Checked $totalLinks links; Broken: $($broken.Count)"
if ($broken.Count -gt 0) {
    Write-Host "Details of broken links:" -ForegroundColor Red
    if ($env:GITHUB_STEP_SUMMARY) {
      "Details of broken links:" | Set-Content $env:GITHUB_STEP_SUMMARY
    }
    foreach ($b in $broken) {
      $output = "- $($b.Source) -> $($b.Link) (resolved: $($b.Resolved)) Reason: $($b.Reason)"
      Write-Host $output
      if ($env:GITHUB_STEP_SUMMARY) {
        $output | Add-Content $env:GITHUB_STEP_SUMMARY
      }
    }
}

if ($FailOnMissing -and $broken.Count -gt 0) { exit 1 } else { exit 0 }
