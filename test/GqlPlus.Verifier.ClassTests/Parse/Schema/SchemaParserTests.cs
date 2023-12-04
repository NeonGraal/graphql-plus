using GqlPlus.Verifier.Ast.Schema;
using GqlPlus.Verifier.Result;

namespace GqlPlus.Verifier.Parse.Schema;

public class SchemaParserTests
{
  private readonly IParser<SchemaAst> _parser;

  public SchemaParserTests(IParser<SchemaAst> parser)
    => _parser = parser.ThrowIfNull();

  [Theory]
  [InlineData("category { Query }")]
  [InlineData("enum Test { Label }")]
  public void Parse_ShouldSucceed(string input)
  {
    var tokens = new Tokenizer(input);

    var ast = _parser.Parse(tokens).Required();

    using var scope = new AssertionScope();

    ast.Should().BeOfType<SchemaAst>()
      .Subject.Result.Should().Be(ParseResultKind.Success);
    ast!.Errors.Should().BeEmpty();
  }

  [Theory]
  [InlineData("")]
  public void Parse_ShouldFail(string input)
  {
    var tokens = new Tokenizer(input);

    var result = _parser.Parse(tokens);
    result.Optional(ast => {
      using var scope = new AssertionScope();

      ast.Should().BeNull();
      result.IsError(err => err.Message.Should().NotBeNullOrWhiteSpace());
    });
  }

  [Theory]
  [InlineData("enum Test Label }")]
  [InlineData("category { Query } extra")]
  public void Parse_ShouldPartiallySucceed(string input)
  {
    var tokens = new Tokenizer(input);

    var ast = _parser.Parse(tokens).Optional();

    using var scope = new AssertionScope();

    ast.Should().BeOfType<SchemaAst>()
      .Subject.Result.Should().Be(ParseResultKind.Failure);
    ast!.Errors.Should().NotBeEmpty();
  }
}
