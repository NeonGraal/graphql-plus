#Requires -Version 7.0

<#
  Common helper functions shared between the PowerShell scripts at the
  repository root. Import with:

    Import-Module "$PSScriptRoot\scripts\Common.psm1" -Force
#>

function Invoke-DotnetBuild {
  <#
    Runs `dotnet build` (with optional extra arguments) and exits the
    calling script with the build's exit code if it fails.
  #>
  [CmdletBinding()]
  param (
    [string[]]$Arguments = @()
  )

  dotnet build @Arguments

  if ($LASTEXITCODE -ne 0) {
    Write-Host "Build failed, exiting."
    exit $LASTEXITCODE
  }
}

function Restore-DotnetTools {
  <#
    Restores the dotnet local tools declared in the repository manifest.
  #>
  [CmdletBinding()]
  param ()

  dotnet tool restore
}

function Clear-TestResults {
  <#
    Removes any TestResults directories under the given path, ignoring
    missing paths.
  #>
  [CmdletBinding()]
  param (
    [string]$Path = "test"
  )

  Get-ChildItem $Path -Filter "TestResults" -Recurse -Directory -ErrorAction Ignore |
    Remove-Item -Recurse -Force -ErrorAction Ignore
}

function Get-TestSetLabel {
  <#
    Returns the label used to identify a test run, based on whether it
    is scoped to the ClassTests solution filter.
  #>
  [CmdletBinding()]
  param (
    [switch]$ClassTests = $false
  )

  if ($ClassTests) {
    "Class"
  } else {
    "All"
  }
}

function Invoke-InLocation {
  <#
    Runs a script block after pushing the given location, guaranteeing
    the location is popped afterwards even if the script block throws.
  #>
  [CmdletBinding()]
  param (
    [Parameter(Mandatory)]
    [string]$Path,
    [Parameter(Mandatory)]
    [scriptblock]$ScriptBlock
  )

  Push-Location $Path
  try {
    & $ScriptBlock
  }
  finally {
    Pop-Location
  }
}

Export-ModuleMember -Function Invoke-DotnetBuild, Restore-DotnetTools, Clear-TestResults, Get-TestSetLabel, Invoke-InLocation
