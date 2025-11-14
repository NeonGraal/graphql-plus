
dotnet build

if ($LASTEXITCODE -ne 0) {
  Write-Host "Build failed, exiting."
  exit $LASTEXITCODE
}

Get-ChildItem test -Filter "*.verified.*" -Recurse | Remove-Item -Force
Get-ChildItem test/Html/* -Directory | Remove-Item -Recurse -Force

dotnet test -e GQLPLUS_AUTOVERIFY=true -l "trx;LogFileName=TestResults-10.0.trx" -f net10.0

Write-Host "`n"
./make-summary.ps1 -NoCoverage -Framework 10.0
