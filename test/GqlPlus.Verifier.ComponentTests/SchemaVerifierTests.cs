using GqlPlus.Verifier.Ast.Schema;
using GqlPlus.Verifier.Parse;
using GqlPlus.Verifier.Result;
using GqlPlus.Verifier.Token;
using GqlPlus.Verifier.Verification;

namespace GqlPlus.Verifier;

public class SchemaVerifierTests(
    Parser<SchemaAst>.D parser,
    IVerify<SchemaAst> verifier)
{
  private readonly Parser<SchemaAst>.L _parser = parser;

  [Theory]
  [ClassData(typeof(ValidGraphQlPlusSchemas))]
  public void Verify_ValidSchemas_ReturnsValid(string schema)
  {
    var parse = Parse(schema);
    if (parse is IResultError<SchemaAst> error) {
      error.Message.Should().BeNull();
    }

    var result = verifier.Verify(parse.Required());

    result.Should().BeNullOrEmpty();
  }

  [Theory]
  [ClassData(typeof(InvalidGraphQlPlusSchemas))]
  public void Verify_InvalidSchemas_ReturnsInvalid(string schema)
  {
    var parse = Parse(schema);

    var result = new TokenMessages();
    if (parse.IsOk()) {
      result.AddRange(verifier.Verify(parse.Required()));
    } else {
      parse.IsError(result.Add);
    }

    result.Should().NotBeNullOrEmpty();
  }

  private IResult<SchemaAst> Parse(string schema)
  {
    Tokenizer tokens = new(schema);
    return _parser.Parse(tokens, "Schema");
  }

  public class ValidGraphQlPlusSchemas : TheoryData<string>
  {
    public ValidGraphQlPlusSchemas()
    {
      Add("category { Test } output Test { }");
      Add("output Test { } output Test { }");
    }
  }

  public class InvalidGraphQlPlusSchemas : TheoryData<string>
  {
    public InvalidGraphQlPlusSchemas()
    {
      Add(""); // Bad parse
      Add("enum Test { Value } output Test { }"); // Type names must be unique
      Add("category { Test }"); // Category output not defined
      Add("category { Test } category test { Output } output Test { } output Output { }"); // Duplicate Category names
      Add("category [a] { Test } category [a] { Output } output Test { } output Output { }"); // Duplicate Category aliases
    }
  }
}
