using GqlPlus.Verifier.Ast.Schema;
using GqlPlus.Verifier.Parse;

namespace GqlPlus.Verifier;

public class SchemaVerifierTests
{
  [Theory]
  [ClassData(typeof(ValidGraphQlPlusSchemas))]
  public void Verify_ValidSchemas_ReturnsValid(string operation)
  {
    var result = SchemaVerifier.Verify(operation, _parser, out var errors);

    using var scope = new AssertionScope();

    result.Should().BeTrue();
    errors.Should().BeNullOrEmpty();
  }

  [Theory]
  [ClassData(typeof(InvalidGraphQlPlusSchemas))]
  public void Verify_InvalidSchemas_ReturnsInvalid(string operation)
  {
    var result = SchemaVerifier.Verify(operation, _parser, out var errors);

    using var scope = new AssertionScope();

    result.Should().BeFalse();
    errors.Should().NotBeNullOrEmpty();
  }

  private readonly IParser<SchemaAst> _parser;

  public SchemaVerifierTests(IParser<SchemaAst> parser)
    => _parser = parser.ThrowIfNull();

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
      Add("enum Test { Label } output Test { }"); // Type names must be unique
      Add("category { Test }"); // Category output not defined
    }
  }
}
