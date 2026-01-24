# GraphQL+ Development Conventions

This document outlines the conventions and standards used in the GraphQL+ project.

## Testing Conventions

### Test Method Naming

All new and updated test methods should follow the **`MethodUnderTest_StateUnderTest_ExpectedResult`** naming convention.

**Note**: Tests using snapshot testing frameworks (e.g., Verify) typically don't follow this convention as their method names are used in snapshot file naming.

**Format**: `{MethodName}_{Scenario}_{ExpectedBehavior}`

**Common Scenario Patterns**:
- `NullInput` / `EmptyInput` - Testing with null or empty values
- `ValidInput` / `InvalidInput` - Testing with valid or invalid data
- `GivenType` / `GivenValue` - Testing with specific parameters (often used with `[Theory]`)
- `Default` - Testing default behavior without special conditions
- `WhenCalled` / `WhenChecked` - Testing general execution path
- `DifferentX` / `MatchingY` - Testing comparisons or relationships

**Examples**:
- `ArrayOf_NullInput_ReturnsEmptyArray()` - Tests the `ArrayOf` method with null input, expects empty array
- `ThrowIfNull_NullValue_ThrowsArgumentNullException()` - Tests `ThrowIfNull` with null, expects exception
- `Verify_UndefinedInput_ReturnsError()` - Tests `Verify` with undefined input, expects error result
- `Parse_ValidSyntax_ReturnsAst()` - Tests `Parse` with valid syntax, expects AST returned
- `ModelBasicTypes_GivenType_SucceedsWithoutErrors()` - Tests `ModelBasicTypes` with a specific type parameter, expects success
- `HashCode_Default_ReturnsExpectedValue()` - Tests `HashCode` in default scenario, expects valid hash
- `Inequality_DifferentModifiers_AreNotEqual()` - Tests `Inequality` with different modifiers, expects inequality

**Guidelines**:
- Use PascalCase for each segment
- Separate segments with underscores (`_`)
- Be descriptive but concise
- Focus on the behavior being tested, not implementation details
- For parameterized tests with `[Theory]`, follow the same pattern
- The first segment should clearly identify the method or property being tested

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

### Test Framework Usage

**When writing tests use Xunit and AutoData.**

**Class tests** use NSubstitute and Shouldly:
- Use fields or properties for the instance being tested
- Store any constructor parameters of the instance being tested in private fields
- NSubstitute Returns should always use a local variable
- String and other primitive constants should be specified via test parameters
- Tests with parameters should have Theory and RepeatData attributes

**Component tests** use Shouldly or Verify.

**Renderer class tests**:
- Should inherit from RendererClassTestBase
- Use its Renderer property for the instance being tested
- Check the Structured output using `.ToLines(false)`
