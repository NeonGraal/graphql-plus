[CmdletBinding()]
param (
  [Switch]$NoCoverage = $false,
  [Switch]$ShowGithub = $false
)

function Get-Badge($params, $label, $body, $colour, $prefix = "") {
  $labelText = $label -f $params
  $bodyText = ($body -f $params) -replace " ", "_"
  "$prefix![$labelText](https://img.shields.io/badge/$bodyText-$colour)"
}

function Convert-Tests($test, $prefix = "") { 
  $params = ($test.label -replace " ", "_"), $test.failed, $test.error, $test.passed, $test.skipped
  if (($test.failed + $test.error) -eq 0) {
    $label = $test.label + " successful"
    $text = "{0}-{3:d}_passed%2C_{4:d}_skipped"
    $colour = "6F6"
  } else {
    $label = $test.label + " failed"
    $text = "{0}-{1:d}_failed%2C{2:d}_errored%2C{3:d}_passed%2C_{4:d}_skipped"
    $colour = "F66"
  }

  Get-Badge $params $label $text $colour $prefix
}

function Write-Tests($test, $prefix = "") {
  $params = $test.label, $test.failed, $test.error, $test.passed, $test.skipped
  if (($test.failed + $test.error) -eq 0) {
    $message = "{0} successful: {3:d} passed, {4:d} skipped" -f $params
  } else {
    $message = "{0} FAILED: {1:d} failed, {2:d} errored, {3:d} passed, {4:d} skipped" -f $params
  }

  Write-Host "$prefix$message"
}

function Convert-Coverage($cover, $prefix = "") {
  if ($cover.linesValid -gt 0) {
    $linesPerc = $cover.linesCovered * 100.0 / $cover.linesValid
  } else {
    $linesPerc = 0.0
  }
  $params = $linesPerc, $cover.linesCovered, $cover.linesValid, $cover.label
  Get-Badge $params "{3} Coverage" "{3}_Coverage-{0:f2}%25_covered_{1:d}_of_{2:d}" "F6F" $prefix
}

function Write-Coverage($cover, $prefix = "") {
  if ($cover.linesValid -gt 0) {
    $linesPerc = $cover.linesCovered * 100.0 / $cover.linesValid
  } else {
    $linesPerc = 0.0
  }
  $params = $linesPerc, $cover.linesCovered, $cover.linesValid, ($cover.label -replace "_", " ")
  $message = "{3} Coverage: {0:f2}% covered {1:d} of {2:d} lines" -f $params
  Write-Host "$prefix$message"
}

[PsObject]$allCoverage = @{label = "All"; linesCovered = 0; linesValid = 0 }

if (-not $NoCoverage) {
  $coverage = Get-ChildItem coverage -Filter "Coverage*.xml" | ForEach-Object {
    [xml]$coverageXml = Get-Content $_.FullName
    $lines = $coverageXml.coverage

    $allCoverage.linesCovered += $lines."lines-covered"
    $allCoverage.linesValid += $lines."lines-valid"

    $label = $_.BaseName -replace "Coverage-", "" -replace "-", " "  
    @{label = $label; linesCovered = [int]$lines."lines-covered"; linesValid = [int]$lines."lines-valid" }
  }
}

[PsObject]$allTests = @{label = "All Tests"; skipped = 0; passed = 0; failed = 0; error = 0 }
$allErrors = @{}

$tests = Get-ChildItem . -Recurse -Filter "TestResults*.trx" | ForEach-Object {
  [xml]$trx = Get-Content $_.FullName

  $name = $_.Directory.Parent.Name -replace "GqlPlus\.","" -replace "\."," "
  $summary = $trx.TestRun.ResultSummary
  $counts = $summary.Counters
  $skipped = [int]$counts.total - $counts.executed

  $allTests.skipped += $skipped
  $allTests.passed += $counts.passed
  $allTests.failed += $counts.failed
  $allTests.error += $counts.error

  if ($NoCoverage -and $summary.outcome -eq "Failed") {
    $allErrors[$name] = $summary.RunInfos.RunInfo | ForEach-Object { ($_.Text -split '[[\]]')[2].Trim() }
  }

  @{label = $name; failed = [int]$counts.failed; error = [int]$counts.error; passed = [int]$counts.passed; skipped = $skipped }
}

Write-Tests $allTests
if ($tests.Count -gt 1) {
  $tests | ForEach-Object { Write-Tests $_ "- " }

  $allErrors.Keys | ForEach-Object {
    Write-Host "* $_ FAILURES"
    $allErrors[$_].ForEach({ Write-Host "  - $_" })
  }
}

if ($NoCoverage) {
  exit 0
}

Write-Coverage $allCoverage
if ($coverage.Count -gt 1) {
  $coverage | ForEach-Object { Write-Coverage $_ "- " }
}

if ($ShowGithub) {
  Write-Host (Convert-Tests $allTests)
  if ($tests.Count -gt 1) {
    $tests | ForEach-Object { Write-Host (Convert-Tests $_ "- ") }
  }
  Write-Host (Convert-Coverage $allCoverage "`n")
  if ($coverage.Count -gt 1) {
    $coverage | ForEach-Object { Write-Host (Convert-Coverage $_ "- ") }
  }  
}

if ($env:GITHUB_STEP_SUMMARY) {
  Convert-Tests $allTests | Set-Content $env:GITHUB_STEP_SUMMARY
  if ($tests.Count -gt 1) {
    $tests | ForEach-Object { Convert-Tests $_ "- " } | Add-Content $env:GITHUB_STEP_SUMMARY
  }
  Convert-Coverage $allCoverage "`n" | Add-Content $env:GITHUB_STEP_SUMMARY
  if ($coverage.Count -gt 1) {
    $coverage | ForEach-Object { Convert-Coverage $_ "- " } | Add-Content $env:GITHUB_STEP_SUMMARY
  }  
}

if ($env:GITHUB_OUTPUT) {
  Convert-Coverage $allCoverage "coverage_badge=" | Set-Content $env:GITHUB_OUTPUT
}
