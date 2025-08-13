using GqlPlus.Abstractions.Operation;
using GqlPlus.Ast.Operation;
using GqlPlus.Result;

namespace GqlPlus.Parsing.Operation;

public class ParseOperationTests(
  Parser<IGqlpOperation>.D operationParser
)
{
  [Theory]
  [InlineData(":Boolean")]
  [InlineData("query:Boolean?")]
  [InlineData("query Test{success}")]
  [InlineData("($name){person($name){name}}")]
  [InlineData("&person:Person{name}{...person}")]
  [InlineData("{...person}fragment person on Person{name}")]
  [InlineData("{...person}&person on Person{name}")]
  [InlineData("($test:Boolean):Boolean($test)")]
  [InlineData("{test}[]")]
  public void Parse_ShouldSucceed(string input)
  {
    OperationContext context = new(input);

    IGqlpOperation result = _parser.Parse(context, "Operation").Required();

    result.ShouldSatisfyAllConditions(
      r => r.ShouldBeOfType<OperationAst>(),
      r => r.Result.ShouldBe(ParseResultKind.Success),
      r => r.Errors.ShouldBeEmpty());
  }

  [Theory]
  [InlineData("")]
  public void Parse_ShouldFail(string input)
  {
    OperationContext context = new(input);

    IResult<IGqlpOperation> result = _parser.Parse(context, "Operation");
    result.Optional(ast =>
      result.ShouldSatisfyAllConditions(
        () => ast.ShouldBeNull(),
        () => result.IsError(err => err.Message.ShouldNotBeNullOrWhiteSpace())));
  }

  [Theory]
  [InlineData(":")]
  [InlineData("query")]
  [InlineData("query Test")]
  [InlineData("{")]
  [InlineData("{field")]
  [InlineData("{}")]
  [InlineData("(")]
  [InlineData("($")]
  [InlineData("($test")]
  [InlineData("($test[?])")]
  [InlineData("($test $more:)")]
  [InlineData("()")]
  [InlineData("($test)")]
  [InlineData(")")]
  [InlineData(":Boolean extra")]
  [InlineData(":Boolean($)")]
  [InlineData("{test}[?]")]
  public void Parse_ShouldPartiallySucceed(string input)
  {
    OperationContext context = new(input);

    IGqlpOperation? ast = _parser.Parse(context, "Operation").Optional();

    ast.ShouldSatisfyAllConditions(
      a => a.ShouldBeOfType<OperationAst>()
        .Result.ShouldBe(ParseResultKind.Failure),
      a => a.ThrowIfNull().Errors.ShouldNotBeEmpty());
  }

  private readonly Parser<IGqlpOperation>.L _parser = operationParser;
}
