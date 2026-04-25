# GraphQL+

Defining a successor to GraphQL <img src="images/GraphQL_Logo.svg" width="50" alt="GraphQL Logo">

## Dotnet Parser, Merging Verifier and Modeller

GraphQL+ is a .NET implementation of a parser, merging verifier, and modeller for GraphQL+ schemas and queries.

## Tech stack

- C# with modern language features enabled
- Source projects target .NET Standard 2.0
- Test projects target .NET 10.0, 9.0, and 8.0
- Nullable reference types are enabled
- File-scoped namespaces are preferred

### Test stack

- xUnit v3
- AutoFixture with AutoData
- NSubstitute
- Shouldly
- Verify

## Build and validation

```powershell
dotnet restore
dotnet build
./test.ps1
./test.ps1 -ClassTests
./test.ps1 -Framework "10.0"
./format.ps1
./coverage.ps1
```

`format.ps1` runs Prettier for non-C# files, then `dotnet format whitespace`, `dotnet format style`, and `dotnet format analyzers`.

### Dotnet Packages

- [AutoFixture](https://github.com/AutoFixture/AutoFixture?tab=readme-ov-file#readme) [nuget](https://www.nuget.org/packages/AutoFixture.Xunit3)
- [Fluid](https://github.com/sebastienros/fluid?tab=readme-ov-file#readme) [nuget](https://www.nuget.org/packages/Fluid.Core)
- [PolySharp]() [nuget](https://www.nuget.org/packages/PolySharp)
- [Shouldly](https://docs.shouldly.org/) [nuget](https://www.nuget.org/packages/Shouldly)
- [Verify](https://github.com/VerifyTests/Verify) [nuget](https://www.nuget.org/packages/Verify.XunitV3)
  - [Verify.SourceGenerators](https://github.com/VerifyTests/Verify.SourceGenerators) [nuget](https://www.nuget.org/packages/Verify.SourceGenerators)
- [XUnit v3](https://xunit.net/) [nuget](https://www.nuget.org/packages/xunit.v3)
  - [XUnit SkippableFact](https://github.com/AArnott/Xunit.SkippableFact?tab=readme-ov-file#readme) [nuget](https://www.nuget.org/packages/Xunit.SkippableFact)
  - [XUnit DependencyInjection](https://github.com/pengweiqhca/Xunit.DependencyInjection?tab=readme-ov-file#readme) [nuget](https://www.nuget.org/packages/Xunit.DependencyInjection)
- [YamlDotNet](https://github.com/aaubry/YamlDotNet/wiki) [nuget](https://www.nuget.org/packages/YamlDotNet)

## Dotnet local tools

- [Coverage](https://learn.microsoft.com/en-us/dotnet/core/additional-tools/dotnet-coverage) [nuget](https://www.nuget.org/packages/dotnet-coverage)
- [Report Generator](https://github.com/danielpalme/ReportGenerator) [nuget](https://www.nuget.org/packages/dotnet-reportgenerator-globaltool)

## Dotnet Global tools

Various scripts presume these dotnet tools are installed globally:

- [Live Reload Server](https://github.com/RickStrahl/LiveReloadServer) [nuget](https://www.nuget.org/packages/LiveReloadServer)

## Development

For repository-wide coding style, see [Style-Guide.md](Style-Guide.md).

For development conventions including testing standards, see [Conventions.md](Conventions.md).

For agent workflow guidance, see [AGENTS.md](AGENTS.md).

### Other references

- [Liquid](https://shopify.github.io/liquid/)
- [Pico Css](https://picocss.com/) [jsDelivr](https://www.jsdelivr.com/package/npm/@picocss/pico)
- [Mermaid](https://mermaid.js.org/syntax/flowchart.html) [jsDelivr](https://www.jsdelivr.com/package/npm/mermaid)
- Source Generators
  - [Creating a Source Generator](https://andrewlock.net/series/creating-a-source-generator/)
  - [Incremental Roslyn Source Generators](https://www.thinktecture.com/en/net/roslyn-source-generators-high-level-api-forattributewithmetadataname/)
  - [Source Generators in 2024](https://posts.specterops.io/dotnet-source-generators-in-2024-part-1-getting-started-76d619b633f5)

  ## Link checker (local files)

  A small PowerShell script is provided to verify that all local links reachable from `test/Html/index.html` exist on disk.

  Usage (from repo root):

  ```powershell
  powershell -NoProfile -ExecutionPolicy Bypass -File .\check-links.ps1 \
    -Entry test/Html/index.html -Root test/Html -Verbose
  ```

  The script:
  - follows only local links (ignores `http(s):`, `mailto:`, `tel:`, `data:` and protocol-relative `//` links)
  - recurses only into HTML files under `test/Html`
  - ignores fragment-only links (e.g. `#anchor`) and does not validate in-page anchors
  - returns exit code `1` when broken links are found (suitable for CI)

  Example GitHub Actions job snippet:

  ```yaml
  - name: Check out repository
    uses: actions/checkout@v4

  - name: Check local HTML links
    run: pwsh -NoProfile -NonInteractive -ExecutionPolicy Bypass -File ./check-links.ps1 -Entry test/Html/index.html -Root test/Html
  ```
