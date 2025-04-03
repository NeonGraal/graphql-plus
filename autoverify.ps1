Get-ChildItem test -Filter "*.verified.*" -Recurse | Remove-Item -Force
dotnet test -e GQLPLUS_AUTOVERIFY=true -l "trx;LogFileName=TestResults.trx" -f net9.0
prettier -w .
Write-Host "`n"
./make-summary.ps1 -NoCoverage
