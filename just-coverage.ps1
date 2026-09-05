[CmdletBinding()]
param (
  $Project = "",
  [switch]$IncludeTests = $false,
  [switch]$ClassTests = $false,
  $Framework = "10.0"
)

$coverageFile = "$PWD/coverage/Coverage-$Framework.xml"
$collect = "collect","-o",$coverageFile,"-f","cobertura"
$settings = "coverage.runsettings"
$test = "test","--no-build","--framework","net$Framework"

if ($Project)
{
  $project = "GqlPlus.$Project.ClassTests"
  $test += @("test/$project/$project.csproj")
} elseif ($ClassTests)
{
  $test += @("GqlPlus.ClassTests.slnf")
}
if ($IncludeTests)
{
  $settings = "tests-coverage.runsettings"
}
$test += "--","--output","minimal","--report-xunit-trx"

Get-ChildItem coverage -File -ErrorAction Ignore | Remove-Item -Recurse -Force -ErrorAction Ignore
Get-ChildItem test -Filter 'TestResults' -Recurse -Directory | Remove-Item -Recurse -Force -ErrorAction Ignore

dotnet coverage @collect -s $settings -- dotnet @test
