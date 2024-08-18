[CmdletBinding()]
param (
  [Switch]$ShowGithub = $false
)

function Get-Badge($params, $label, $body, $colour, $prefix = "") {
  $labelText = $label -f $params
  $bodyText = $body -f $params
  "$prefix![$labelText](https://img.shields.io/badge/$bodyText-$colour)"
}

function Get-Tests($label, $counts) {
  $skipped = [int]$counts.total - $counts.executed
  @{params = ($label, [int]$counts.failed, [int]$counts.error, [int]$counts.passed, $skipped) }
}

function Convert-Tests($params, $prefix = "") {
  if (($params[1] + $params[2]) -eq 0) {
    $label = "{0} successful"
    $text = "tests-{3:d}_passed%2C_{4:d}_skipped"
    $colour = "6F6"
  } else {
    $label = "{0} failed"
    $text = "tests-{1:d}_failed%2C{2:d}_errored%2C{3:d}_passed%2C_{4:d}_skipped"
    $colour = "F66"
  }

  Get-Badge $params $label $text $colour $prefix
}

function Write-Tests($params, $prefix = "") {
  if (($params[1] + $params[2]) -eq 0) {
    $message = "{0} successful: {3:d} passed, {4:d} skipped" -f $params
  } else {
    $message = "{0} FAILED: {1:d} failed, {2:d} errored, {3:d} passed, {4:d} skipped" -f $params
  }

  Write-Host "$prefix$message"
}

function Convert-Coverage($cover, $prefix = "") {
  $params = $cover.linesPerc, $cover.linesCovered, $cover.linesValid
  Get-Badge $params "Coverage" "coverage-{0:f2}%25_covered_{1:d}_of_{2:d}" "F6F" $prefix
}

function Write-Coverage($cover, $prefix = "") {
  $params = $cover.linesPerc, $cover.linesCovered, $cover.linesValid
  $message = "Coverage: {0:f2}% covered {1:d} of {2:d} lines" -f $params
  Write-Host "$prefix$message"
}

[PsObject]$allCoverage = @{"linesPerc" = 100; "linesCovered" = 0; "linesValid" = 0 }

$coverage = Get-ChildItem coverage -Filter "Coverage*.xml" | ForEach-Object {
  [xml]$coverageXml = Get-Content $_.FullName
  $lines = $coverageXml.coverage
  $linesPerc = [float]$lines."line-rate" * 100

  if ($linesPerc -gt 0) {
    $allCoverage.linesPerc = $allCoverage.linesPerc * $linesPerc / 100
  }
  $allCoverage.linesCovered += $lines."lines-covered"
  $allCoverage.linesValid += $lines."lines-valid"

  @{"linesPerc" = $linesPerc; "linesCovered" = [int]$lines."lines-covered"; "linesValid" = [int]$lines."lines-valid" }
}

[PsObject]$allTests = @{"total" = 0; "executed" = 0; "passed" = 0; "failed" = 0; "error" = 0 }

$testParams = Get-ChildItem . -Recurse -Filter "TestResults*.trx" | ForEach-Object {
  [xml]$trx = Get-Content $_.FullName

  $name = $_.Directory.Parent.Name
  $counters = $trx.TestRun.ResultSummary.Counters

  $allTests.total += $counters.total
  $allTests.executed += $counters.executed
  $allTests.passed += $counters.passed
  $allTests.failed += $counters.failed
  $allTests.error += $counters.error

  Get-Tests $name $counters
}

$allTestsParams = Get-Tests "All Tests" $allTests

Write-Tests $allTestsParams.params
if ($testParams.Count -gt 1) {
  foreach ($test in $testParams) {
    Write-Tests $test.params "- "
  }
}
Write-Coverage $allCoverage

if ($ShowGithub) {
  Write-Host (Convert-Tests $allTestsParams.params)
  if ($testParams.Count -gt 1) {
    $testParams | ForEach-Object { Write-Host (Convert-Tests $_.params "- ") }
  }
  Write-Host (Convert-Coverage $allCoverage)
}

if ($env:GITHUB_STEP_SUMMARY) {
  Convert-Tests $allTestsParams.params | Set-Content $env:GITHUB_STEP_SUMMARY
  if ($testParams.Count -gt 1) {
    $testParams | ForEach-Object { Convert-Tests $_.params "- " } | Set-Content $env:GITHUB_STEP_SUMMARY -Append
  }
  Convert-Coverage $allCoverage | Set-Content $env:GITHUB_STEP_SUMMARY -Append
}

if ($env:GITHUB_OUTPUT) {
  Convert-Coverage $allCoverage "coverage_badge=" | Set-Content $env:GITHUB_OUTPUT
}
