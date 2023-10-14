namespace GqlPlus.Verifier.Operation;

public class VerifierTests
{
  [Theory]
  [MemberData(nameof(ValidGraphQlPlusOperations))]
  public void Verify_ValidOperations_ReturnsValid(string operation)
  {
    var result = OperationVerifier.Verify(operation, out var errors);

    result.Should().BeTrue();
    errors.Should().BeNullOrEmpty();
  }

  [Theory]
  [MemberData(nameof(InvalidGraphQlPlusOperations))]
  public void Verify_InvalidOperations_ReturnsInvalid(string operation)
  {
    var result = OperationVerifier.Verify(operation, out var errors);

    result.Should().BeFalse();
    errors.Should().NotBeNullOrEmpty();
  }

  public static IEnumerable<object[]> ValidGraphQlPlusOperations
    => new[] {
        new[] { "($var):Boolean($var)"}
      };

  public static IEnumerable<object[]> InvalidGraphQlPlusOperations
    => new[]
      {
        new[] { "($var):Boolean" }, // Defined variables must be used at least once
        new[] { ":Boolean($var)" }, // Used variables must be defined
      };
}
