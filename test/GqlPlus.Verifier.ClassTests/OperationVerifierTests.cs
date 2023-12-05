using GqlPlus.Verifier.Ast.Operation;
using GqlPlus.Verifier.Parse;
using GqlPlus.Verifier.Parse.Operation;
using GqlPlus.Verifier.Result;
using GqlPlus.Verifier.Token;
using GqlPlus.Verifier.Verification;

namespace GqlPlus.Verifier;

public class OperationVerifierTests
{
  [Theory]
  [ClassData(typeof(ValidGraphQlPlusOperations))]
  public void Verify_ValidOperations_ReturnsValid(string operation)
  {
    var parse = Parse(operation);
    if (parse is IResultError<OperationAst> error) {
      error.Message.Should().BeNull();
    }

    var result = _verifier.Verify(parse.Required());

    result.Should().BeNullOrEmpty();
  }

  [Theory]
  [ClassData(typeof(InvalidGraphQlPlusOperations))]
  public void Verify_InvalidOperations_ReturnsInvalid(string operation)
  {
    var parse = Parse(operation);

    var result = new List<TokenMessage>();
    if (parse.IsOk()) {
      result.AddRange(_verifier.Verify(parse.Required()));
    } else {
      parse.IsError(result.Add);
    }

    result.Should().NotBeNullOrEmpty();
  }

  private readonly Parser<OperationAst>.L _parser;
  private readonly IVerify<OperationAst> _verifier;

  public OperationVerifierTests(
    Parser<OperationAst>.D parser,
    IVerify<OperationAst> verifier)
  {
    _parser = parser;
    _verifier = verifier;
  }

  private IResult<OperationAst> Parse(string operation)
  {
    OperationContext tokens = new(operation);
    return _parser.Parse(tokens, "Operation");
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
