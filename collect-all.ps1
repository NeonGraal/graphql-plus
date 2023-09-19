Get-ChildItem ./graphql-plus -Filter *.md | ForEach-Object {
  $all = @{}
  $current = @()
  $type = ""
  $doc = @()
  $end = $false

  $_ | Get-Content | ForEach-Object {
    if ($end) { return }
    $doc += @($_)
    
    if ($type) {
      if ($_ -eq "``````") {
        $all[$type] += $current + @("")
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
}