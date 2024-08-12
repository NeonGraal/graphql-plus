[CmdletBinding()]
param (
    $Heading = "Tests Summary",
    $CoverageFile = "output.cobertura.xml",
    $TestsFilter = "*.trx"
)

[xml]$coverageXml = Get-Content $Coveragefile
$lines = $coverageXml.coverage
$linesPerc = [float]$lines."line-rate" * 100
$coverageSummary = "`nCoverage: {0:f2}% covered {1:n0} of {2:n0} lines" -f $linesPerc, [int]$lines."lines-covered", [int]$lines."lines-valid"

[PsObject]$tests = @{
  "total"=0;"executed"=0;"passed"=0;"failed"=0;"error"=0
}

function Write-Tests($label, $counts) {
  $params = $counts.total, $counts.executed, $counts.passed, $counts.failed, $counts.error, $label
  "`n{5}: {3:n0} failed and {4:n0} errored. Executed {1:n0} of {0:n0} thus passing {2:n0}. " -f $params
}

Get-ChildItem . -Recurse -Filter $TestsFilter | ForEach-Object {
  [xml]$trx = Get-Content $_.FullName

  $counters = $trx.TestRun.ResultSummary.Counters

  $tests.total += $counters.total
  $tests.executed += $counters.executed
  $tests.passed += $counters.passed
  $tests.failed += $counters.failed
  $tests.error += $counters.error
}

$testSummary = Write-Tests "Tests" $tests

Write-Host "## $Heading"
Write-Host $testSummary
Write-Host $coverageSummary
