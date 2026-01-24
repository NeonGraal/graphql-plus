# GraphQL+

Defining a successor to GraphQL <img src="images/GraphQL_Logo.svg" width="50" alt="GraphQL Logo">

## Dotnet Parser, Merging Verifier and Modeller

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

## Testing Conventions

### Test Method Naming

All test methods must follow the **`MethodUnderTest_StateUnderTest_ExpectedResult`** naming convention.

**Format**: `{MethodName}_{Scenario}_{ExpectedBehavior}`

**Examples**:
- `ArrayOf_NullInput_ReturnsEmptyArray()` - Tests the `ArrayOf` method with null input, expects empty array
- `ThrowIfNull_NullValue_ThrowsArgumentNullException()` - Tests `ThrowIfNull` with null, expects exception
- `Verify_UndefinedInput_ReturnsError()` - Tests `Verify` with undefined input, expects error result
- `Parse_ValidSyntax_ReturnsAst()` - Tests `Parse` with valid syntax, expects AST returned

**Guidelines**:
- Use PascalCase for each segment
- Separate segments with underscores (`_`)
- Be descriptive but concise
- Focus on the behavior being tested, not implementation details
- For parameterized tests with `[Theory]`, follow the same pattern

**Test Structure** (using xUnit, AutoFixture, NSubstitute, and Shouldly):
```csharp
[Fact]
public void MethodName_Scenario_ExpectedBehavior()
{
    // Arrange
    var input = /* setup test data */;
    
    // Act
    var result = _systemUnderTest.MethodName(input);
    
    // Assert
    result.ShouldBe(expectedValue);
}
```

### Other references

- [Liquid](https://shopify.github.io/liquid/)
- [Pico Css](https://picocss.com/) [jsDelivr](https://www.jsdelivr.com/package/npm/@picocss/pico)
- [Mermaid](https://mermaid.js.org/syntax/flowchart.html) [jsDelivr](https://www.jsdelivr.com/package/npm/mermaid)
