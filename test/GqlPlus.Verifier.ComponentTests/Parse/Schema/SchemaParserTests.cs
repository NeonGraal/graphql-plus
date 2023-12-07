using GqlPlus.Verifier.Ast.Schema;
using GqlPlus.Verifier.Result;
using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Parse.Schema;

public class SchemaParserTests(Parser<SchemaAst>.D parser)
{
  private readonly Parser<SchemaAst>.L _parser = parser;

  [Theory]
  [InlineData("category { Query }")]
  [InlineData("enum Test { Label }")]
  public void Parse_ShouldSucceed(string input)
  {
    var tokens = new Tokenizer(input);

    var ast = _parser.Parse(tokens, "Schema").Required();

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

    var result = _parser.Parse(tokens, "Schema");
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

    var ast = _parser.Parse(tokens, "Schema").Optional();

    using var scope = new AssertionScope();

    ast.Should().BeOfType<SchemaAst>()
      .Subject.Result.Should().Be(ParseResultKind.Failure);
    ast!.Errors.Should().NotBeEmpty();
  }
}
