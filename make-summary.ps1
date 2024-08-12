[CmdletBinding()]
param (
    $CoverageFile = "coverage/Coverage.xml"
)

[xml]$coverageXml = Get-Content $Coveragefile
$lines = $coverageXml.coverage
$linesPerc = [float]$lines."line-rate" * 100
$params = $linesPerc, [int]$lines."lines-covered", [int]$lines."lines-valid"
#$coverageSummary = "`nCoverage: {0:f2}% covered {1:d} of {2:d} lines" -f $params
$coverageSummary = "[Coverage](https://img.shields.io/badge/coverage-{0:f2}%25_covered_{1:d}_of_{2:d}-F6F)" -f $params

[PsObject]$tests = @{
  "total"=0;"executed"=0;"passed"=0;"failed"=0;"error"=0
}

function Write-Tests($label, $counts) {
  $skipped = $counts.total - $counts.executed
  $params = $label, $counts.failed, $counts.error, $counts.passed, $skipped
  # "{0}: {1:d} failed and {2:d} errored. Skipped {3:d} thus passed {4:d}. " -f $params

  if (($counts.failed + $counts.error) -eq 0) {
    "[{0} successful](https://img.shields.io/badge/tests-{3:d}_passed%2C_{4:d}_skipped-6F6)" -f $params
  } else {
    "[{0} failed](https://img.shields.io/badge/tests-{1:d}_failed%2C{2:d}_errored%2C{3:d}_passed%2C_{4:d}_skipped-F66)" -f $params
  }
}

Get-ChildItem . -Recurse -Filter "TestResults*.trx" | ForEach-Object {
  [xml]$trx = Get-Content $_.FullName

  $counters = $trx.TestRun.ResultSummary.Counters

  $tests.total += $counters.total
  $tests.executed += $counters.executed
  $tests.passed += $counters.passed
  $tests.failed += $counters.failed
  $tests.error += $counters.error
}

$testSummary = Write-Tests "All Tests" $tests

Write-Host $testSummary
Write-Host $coverageSummary

if ($env:GITHUB_OUTPUT) {
  Set-Content $env:GITHUB_OUTPUT "coverage_badge=$coverageSummary"
}
