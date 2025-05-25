[CmdletBinding()]
param (
  [switch]$Html = $false,
  [Switch]$NoCoverage = $false,
  [Switch]$ShowGithub = $false,
  [switch]$ClassTests = $false,
  $Framework = "9.0"
)

$testSet = "All"
if ($ClassTests) {
  $testSet = "Class"
}

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
    $colour = "CFA"
  } else {
    $label = $test.label + " failed"
    $text = "{0}-{1:d}_failed%2C{2:d}_errored%2C{3:d}_passed%2C_{4:d}_skipped"
    $colour = "FAC"
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
  if ($cover.lineRate -gt 0) {
    $linesPerc = $cover.lineRate
  } else {
    $linesPerc = 0.0
  }
  $params = $linesPerc, $cover.linesCovered, $cover.linesValid, $cover.label
  $message = "{3}_Coverage-{0:f2}%25_covered"
  if ($cover.linesValid -gt 0) {
    $message += "_{1:d}_of_{2:d}_lines"
  }
  if ($linesPerc -gt 80) {
    $colour = "ACF"
  } else {
    $colour = "CAF"
  }
  Get-Badge $params "{3} Coverage" $message $colour $prefix
}

function Write-Coverage($cover, $prefix = "") {
  if ($cover.lineRate -gt 0) {
    $linesPerc = $cover.lineRate
  } else {
    $linesPerc = 0.0
  }
  $message = "{1} Coverage: {0:f2}% covered" -f ($linesPerc, $cover.label)
  if ($cover.linesValid -gt 0) {
    $message += " {0:d} of {1:d} lines" -f ($cover.linesCovered, $cover.linesValid)
  }
  Write-Host "$prefix$message"
}

[PsObject]$allCoverage = @{label = $testSet; linesCovered = 0; linesValid = 0; lineRate = 100.0 }

if (-not $NoCoverage) {
  $coverage = Get-ChildItem coverage -Filter "Coverage-$Framework-$Framework*.xml" | ForEach-Object {
    [xml]$coverageXml = Get-Content $_.FullName
    $lines = $coverageXml.coverage

    $allCoverage.linesCovered += $lines."lines-covered"
    $allCoverage.linesValid += $lines."lines-valid"
    $allCoverage.lineRate *= $lines."line-rate"

    $lines.packages.package | ForEach-Object {
      $label = $_.name -replace 'GqlPlus\.','' -replace '\.',' '
      @{label = $label; lineRate = 100.0 * [float]$_."line-rate" }
    }
  } | Sort-Object label
}

[PsObject]$allTests = @{label = "$testSet tests"; skipped = 0; passed = 0; failed = 0; error = 0 }
$allErrors = @{}

$tests = Get-ChildItem . -Recurse -Filter "TestResults-$Framework-$Framework*.trx" | ForEach-Object {
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
    $allErrors[$name] = $summary.RunInfos.RunInfo | Where-Object {
      $_.outcome -eq "Failed" -or $_.outcome -eq "Error"
    } | ForEach-Object { 
      ($_.Text -split '[[\]]')[2].Trim() 
    }
  }

  @{label = $name; failed = [int]$counts.failed; error = [int]$counts.error; passed = [int]$counts.passed; skipped = $skipped }
} | Sort-Object label

Set-Content summary.md "# Summary"

Write-Tests $allTests
Convert-Tests $allTests "`n" | Add-Content summary.md
if ($tests.Count -gt 1) {
  $tests | ForEach-Object { Write-Tests $_ "- " }
  $tests | ForEach-Object { Convert-Tests $_ "- " | Add-Content summary.md }

  $allErrors.Keys | ForEach-Object {
    Write-Host "* $_ FAILURES"
    $allErrors[$_].ForEach({ Write-Host "  - $_" })
  }
}

if ($Html) {
  Start-Process test/Html/index.html
}

if ($NoCoverage) {
  exit 0
}

Write-Coverage $allCoverage
Convert-Coverage $allCoverage "`n" | Add-Content summary.md
if ($coverage.Count -gt 1) {
  $coverage | ForEach-Object { Write-Coverage $_ "- " }
  $coverage | ForEach-Object { Convert-Coverage $_ "- " | Add-Content summary.md }
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
