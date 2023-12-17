Get-ChildItem ./graphql-plus -Filter *.md | ForEach-Object {
  $all = @{}
  $sections = @{ "Complete" = @() }
  $current = @()
  $type = ""
  $doc = @()
  $end = $false
  $name = $_.Name.Substring(0,5)

  $_ | Get-Content | ForEach-Object {
    if ($end) { return }
    $doc += @($_)

    if ($_ -match "## (\w+)") {
      $section = $Matches[1]
    }
    
    if ($type) {
      if ($_ -eq "``````") {
        $all[$type] += $current + @("")

        if ($type -eq "gqlp" -and $section) {
          $sections[$section] = $current + @()
          $sections["Complete"] += $current + @()
          $section = ""
        }

        $type = ""
      } else {
        $current += @($_)
      }
    } else {
      if ($_ -match "# Complete") {
        if ($all.Keys -contains "PEG") {
          $doc += @("", "``````PEG") + $all["PEG"] + @("``````")
          $end = $true
        } elseif ($all.Keys -contains "gqlp") {
          $doc += @("", "``````gqlp") + $all["gqlp"] + @("``````")
          $end = $true
        }        
      }
      if ($_ -match "``````(\w+)") {
        $type = $Matches[1]
        $current = @()
      }
    }
  }
  $doc | Set-Content $_.FullName

  if ($name -eq "Intro") {
    foreach ($section in $sections.Keys) {
      $sections[$section] | Set-Content ".\test\GqlPlus.Verifier.ComponentTests\Sample\Schema\Intro_$section.graphql+"
    }
  }
}

prettier -w .
