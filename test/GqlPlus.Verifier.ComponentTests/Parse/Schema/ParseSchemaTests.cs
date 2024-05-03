using GqlPlus.Ast.Schema;
using GqlPlus.Result;
using GqlPlus.Token;

namespace GqlPlus.Parse.Schema;

public class ParseSchemaTests(Parser<SchemaAst>.D parser)
{
  private readonly Parser<SchemaAst>.L _parser = parser;

  [Theory]
  [InlineData("category { Query }")]
  [InlineData("enum Test { Value }")]
  [InlineData("category { Query } enum Test { Value }")]
  [InlineData("'Description' enum Test { Value }")]
  [InlineData("category { Query } 'Description' enum Test { Value }")]
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
  [InlineData("enum Test Value }")]
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
