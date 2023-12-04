using GqlPlus.Verifier.Ast.Operation;
using GqlPlus.Verifier.Parse;

namespace GqlPlus.Verifier;

public class OperationVerifierTests
{
  [Theory]
  [ClassData(typeof(ValidGraphQlPlusOperations))]
  public void Verify_ValidOperations_ReturnsValid(string operation)
  {
    var result = OperationVerifier.Verify(operation, _parser, out var errors);

    using var scope = new AssertionScope();

    result.Should().BeTrue();
    errors.Should().BeNullOrEmpty();
  }

  [Theory]
  [ClassData(typeof(InvalidGraphQlPlusOperations))]
  public void Verify_InvalidOperations_ReturnsInvalid(string operation)
  {
    var result = OperationVerifier.Verify(operation, _parser, out var errors);

    using var scope = new AssertionScope();

    result.Should().BeFalse();
    errors.Should().NotBeNullOrEmpty();
  }

  private readonly Parser<OperationAst>.L _parser;

  public OperationVerifierTests(Parser<OperationAst>.D parser)
    => _parser = parser;

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
      Add(""); // Bad parse
      Add("($var):Boolean"); // Defined variables must be used at least once
      Add(":Boolean($var)"); // Used variables must be defined
      Add("($var:Id=null):Boolean($var)"); // Not nullable type can't have a null default value
      Add("($var:Id[]={a:b}):Boolean($var)"); // List type can't have a map default value
      Add("($var:Id[*]=[a]):Boolean($var)"); // Map type can't have a list default value
      Add("($var:Id[]?={a:b}):Boolean($var)"); // Nullable List type can't have a map default value
      Add("($var:Id[*]?=[a]):Boolean($var)"); // Nullable Map type can't have a list default value
      Add("&named:Named{name}{name}"); // Defined fragment must be used
      Add("{...named}"); // Used fragment must be defined
    }
  }
}
