Install-Module -Name powershell-yaml

$runs = @{}

$files = Get-ChildItem .\per-class -Filter "*.yml"

$count = 0
$total = $files.Count

$files | ForEach-Object {
  $run = $_.BaseName

  $count += 1
  $perc = $count * 100 / $total
  Write-Progress "Combine" $run -PercentComplete $perc

  $_ | Get-Content | ConvertFrom-Yaml | `
  ForEach-Object {
    $_ | ForEach-Object {
      if ($_.filename -match "\\test\\")  {
        return
      }
      $class = $_.name
      if ($runs.Keys -notcontains $class ) {
        $runs[$class] = @{filename=$_.filename;allLines=$_.allLines;runs=@{}}
      }
      $runs[$class].runs[$run] = $_.lines.ToString()
    }
  }
}

Write-Progress "Combine" -Completed
  
$runs | ConvertTo-Yaml -Options DisableAliases | Set-Content "runs-all.yml"

$singles = $runs.Keys | Where-Object { $runs[$_].runs.Count -lt 2 }

foreach ($class in $singles) {
  $runs.Remove($class)
}

$runs | ConvertTo-Yaml -Options DisableAliases | Set-Content "runs-many.yml"
