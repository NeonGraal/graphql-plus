namespace GqlPlus.Verifier.ClassTests;

public class OperationVerifierTests
{
  [Theory]
  [MemberData(nameof(ValidGraphQlPlusOperations))]
  public void Verify_ValidOperations_ReturnsValid(string operation)
  {
    var result = OperationVerifier.Verify(operation, out var errors);

    using var scope = new AssertionScope();

    result.Should().BeTrue();
    errors.Should().BeNullOrEmpty();
  }

  [Theory]
  [MemberData(nameof(InvalidGraphQlPlusOperations))]
  public void Verify_InvalidOperations_ReturnsInvalid(string operation)
  {
    var result = OperationVerifier.Verify(operation, out var errors);

    using var scope = new AssertionScope();

    result.Should().BeFalse();
    errors.Should().NotBeNullOrEmpty();
  }

  public static IEnumerable<object[]> ValidGraphQlPlusOperations
    => new[] {
        new[] { "($var):Boolean($var)" },
        new[] { "($var:Id?=null):Boolean($var)" },
        new[] { "&named:Named{name}{|named}" },
        new[] { "{...named}fragment named on Named{name}" },
      };

  public static IEnumerable<object[]> InvalidGraphQlPlusOperations
    => new[]
      {
        new[] { "($var):Boolean" }, // Defined variables must be used at least once
        new[] { ":Boolean($var)" }, // Used variables must be defined
        new[] { "($var:Id=null):Boolean($var)" },
        new[] { "($var:Id[]={a:b}):Boolean($var)" },
        new[] { "($var:Id[*]=[a]):Boolean($var)" },
        new[] { "($var:Id[]?={a:b}):Boolean($var)" },
        new[] { "($var:Id[*]?=[a]):Boolean($var)" },
        new[] { "&named:Named{name}{name}" },
        new[] { "{...named}" },
      };
}
