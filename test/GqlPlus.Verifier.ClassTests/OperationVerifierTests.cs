﻿namespace GqlPlus.Verifier.ClassTests;

public class OperationVerifierTests
{
  [Theory]
  [MemberData(nameof(ValidGraphQlPlusOperations))]
  public void Verify_ValidOperations_ReturnsValid(string operation)
  {
    var result = OperationVerifier.Verify(operation);

    _ = result.Should().BeTrue();
  }

  [Theory]
  [MemberData(nameof(InvalidGraphQlPlusOperations))]
  public void Verify_InvalidOperations_ReturnsInvalid(string operation)
  {
    var result = OperationVerifier.Verify(operation);

    _ = result.Should().BeFalse();
  }

  public static IEnumerable<object[]> ValidGraphQlPlusOperations => new[]
  {
    new[] { "Boolean" },
    new[] { "{ name }" },
    new[] { "Boolean[]?" },
    //new[] { "($var) Boolean($var)"}
  };

  public static IEnumerable<object[]> InvalidGraphQlPlusOperations => new[]
  {
    new[] { "" }, // Operation must have a Result
    new[] { "{}" }, // Selection must have at least one field
    new[] { "Boolean?[]" }, // Nullable Modifer must come last
    //new[] { "() Boolean" }, // Variables must define at least one variable
    //new[] { "($var) Boolean" }, // Defined variables must be used at least once
  };
}
