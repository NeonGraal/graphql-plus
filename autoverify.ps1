Get-ChildItem test -Filter "*.verified.*" -Recurse | Remove-Item -Force
Get-ChildItem test/Html/* -Directory | Remove-Item -Recurse -Force
dotnet test -e GQLPLUS_AUTOVERIFY=true -l "trx;LogFileName=TestResults.trx" -f net9.0
Write-Host "`n"
./make-summary.ps1 -NoCoverage
