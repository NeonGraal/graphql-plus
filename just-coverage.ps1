[CmdletBinding()]
param (
  $Project = "",
  [switch]$IncludeTests = $false,
  [switch]$ClassTests = $false,
  $Framework = "10.0"
)

Import-Module "$PSScriptRoot\scripts\Common.psm1" -Force

$coverageFile = "$PWD/coverage/Coverage-$Framework.xml"
$collect = "collect","-o",$coverageFile,"-f","cobertura"
$settings = "coverage.runsettings"
$test = New-DotnetTestArguments -Framework $Framework -NoBuild -Project $Project -ClassTests:$ClassTests

if ($IncludeTests)
{
  $settings = "tests-coverage.runsettings"
}

Get-ChildItem coverage -File -ErrorAction Ignore | Remove-Item -Recurse -Force -ErrorAction Ignore
Clear-TestResults

dotnet coverage @collect -s $settings -- dotnet @test
