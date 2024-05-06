Install-Module -Name powershell-yaml

dotnet tool restore
dotnet build --disable-build-servers

New-Item per-class -ItemType Directory -ErrorAction Ignore | Out-Null

Push-Location .\test\GqlPlus.Parser.ClassTests

$base = "-s","coverage.runsettings","-f","cobertura","-o"
$dotnet = "--","dotnet","test","--no-build","--verbosity","quiet","--disable-build-servers","--filter"

try {
  $classes = dotnet test --list-tests --no-build | `
    Select-String "    GqlPlus.Verifier" -Raw | `
    ForEach-Object {
      ($_ -split '\.')[-2]
    } | `
    Select-Object -Unique

  $allLinesField = @{L="allLines";E={ ($_.lines.line |
    Select-Object -ExpandProperty number
    ) -join " "
  }}

  $linesField = @{L="lines";E={ ($_.lines.line |
    Where-Object hits -ne 0 |
    Select-Object -ExpandProperty number
    ) -join " "
  }}

  $count = 0
  $total = $classes.Count

  foreach ($run in $classes) {
    $count += 1
    $perc = $count * 100 / $total
    Write-Progress "Test run" $run -PercentComplete $perc

    $xmlFile = "../../per-class/$run.xml"
    $params = $base + @($xmlFile,"-id",$run) + $dotnet + @(".$run.")
    dotnet coverage collect @params | Out-Null

    $runField = @{L="run";E={$run}}

    [xml]$xml = Get-Content $xmlFile
    $xmlClasses = $xml.coverage.packages | `
      ForEach-Object { $_.package.classes } | `
      Select-Object -ExpandProperty class | `
      Where-Object line-rate -ne 0 | `
      Select-Object $runField,name,filename,line-rate,$linesField,$allLinesField

    $ymlFile = "../../per-class/$run.yml"
    $xmlClasses | ConvertTo-Yaml -Options DisableAliases | Set-Content $ymlFile
  }
}
finally {
  Pop-Location
}

Write-Progress "Test run" -Completed
