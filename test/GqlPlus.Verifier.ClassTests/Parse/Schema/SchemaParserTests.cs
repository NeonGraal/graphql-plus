using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Parse.Schema;

public class SchemaParserTests
{
  [Theory]
  [InlineData("category = Query")]
  public void Parse_ShouldSucceed(string input)
  {
    var parser = new SchemaParser(new Tokenizer(input));

    var ast = parser.Parse().Required();

    using var scope = new AssertionScope();

    ast.Should().BeOfType<SchemaAst>()
      .Subject.Result.Should().Be(ParseResultKind.Success);
    ast!.Errors.Should().BeEmpty();
  }

  [Theory]
  [InlineData("")]
  public void Parse_ShouldFail(string input)
  {
    var parser = new SchemaParser(new Tokenizer(input));

    var result = parser.Parse();
    result.Optional(ast => {
      using var scope = new AssertionScope();

      ast.Should().BeNull();
      result.IsError(err => err.Message.Should().NotBeNullOrWhiteSpace());
    });
  }

  [Theory]
  [InlineData("category = Query extra")]
  public void Parse_ShouldPartiallySucceed(string input)
  {
    var parser = new SchemaParser(new Tokenizer(input));

    var ast = parser.Parse().Optional();

    using var scope = new AssertionScope();

    ast.Should().BeOfType<SchemaAst>()
      .Subject.Result.Should().Be(ParseResultKind.Failure);
    ast!.Errors.Should().NotBeEmpty();
  }
}
