using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema;
using GqlPlus.Result;
using GqlPlus.Token;

namespace GqlPlus.Parsing.Schema;

public class ParseSchemaTests(
  Parser<IGqlpSchema>.D parser
)
{
  private readonly Parser<IGqlpSchema>.L _parser = parser;

  [Theory]
  [InlineData("category { Query }")]
  [InlineData("enum Test { Value }")]
  [InlineData("category { Query } enum Test { Value }")]
  [InlineData("'Description' enum Test { Value }")]
  [InlineData("category { Query } 'Description' enum Test { Value }")]
  public void Parse_ShouldSucceed(string input)
  {
    Tokenizer tokens = new(input);

    IGqlpSchema result = _parser.Parse(tokens, "Schema").Required();

    result.ShouldSatisfyAllConditions(
      r => r.ShouldBeOfType<SchemaAst>()
      .Result.ShouldBe(ParseResultKind.Success),
      r => r.Errors.ShouldBeEmpty());
  }

  [Theory]
  [InlineData("")]
  public void Parse_ShouldFail(string input)
  {
    Tokenizer tokens = new(input);

    IResult<IGqlpSchema> result = _parser.Parse(tokens, "Schema");
    result.Optional(ast =>
      result.ShouldSatisfyAllConditions(
        () => ast.ShouldBeNull(),
        () => result.IsError(err => err.Message.ShouldNotBeNullOrWhiteSpace())));
  }

  [Theory]
  [InlineData("enum Test Value }")]
  [InlineData("category { Query } extra")]
  public void Parse_ShouldPartiallySucceed(string input)
  {
    Tokenizer tokens = new(input);

    IGqlpSchema? ast = _parser.Parse(tokens, "Schema").Optional();

    ast.ShouldSatisfyAllConditions(
      a => a.ShouldBeOfType<SchemaAst>()
        .Result.ShouldBe(ParseResultKind.Failure),
      a => a.ThrowIfNull().Errors.ShouldNotBeEmpty());
  }
}
