namespace GqlPlus.Verifier;

public class OperationVerifierTests
{
  [Theory]
  [ClassData(typeof(ValidGraphQlPlusOperations))]
  public void Verify_ValidOperations_ReturnsValid(string operation)
  {
    var result = OperationVerifier.Verify(operation, out var errors);

    using var scope = new AssertionScope();

    result.Should().BeTrue();
    errors.Should().BeNullOrEmpty();
  }

  [Theory]
  [ClassData(typeof(InvalidGraphQlPlusOperations))]
  public void Verify_InvalidOperations_ReturnsInvalid(string operation)
  {
    var result = OperationVerifier.Verify(operation, out var errors);

    using var scope = new AssertionScope();

    result.Should().BeFalse();
    errors.Should().NotBeNullOrEmpty();
  }

  public class ValidGraphQlPlusOperations : TheoryData<string>
  {
    public ValidGraphQlPlusOperations()
    {
      Add("($var):Boolean($var)");
      Add("($var:Id?=null):Boolean($var)");
      Add("&named:Named{name}{|named}");
      Add("{...named}fragment named on Named{name}");
    }
  }

  public class InvalidGraphQlPlusOperations : TheoryData<string>
  {
    public InvalidGraphQlPlusOperations()
    {
      Add("($var):Boolean"); // Defined variables must be used at least once
      Add(":Boolean($var)"); // Used variables must be defined
      Add("($var:Id=null):Boolean($var)");
      Add("($var:Id[]={a:b}):Boolean($var)");
      Add("($var:Id[*]=[a]):Boolean($var)");
      Add("($var:Id[]?={a:b}):Boolean($var)");
      Add("($var:Id[*]?=[a]):Boolean($var)");
      Add("&named:Named{name}{name}");
      Add("{...named}");
    }
  }
}
