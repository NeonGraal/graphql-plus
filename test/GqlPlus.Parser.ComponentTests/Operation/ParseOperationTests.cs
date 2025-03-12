using GqlPlus.Abstractions.Operation;
using GqlPlus.Ast.Operation;
using GqlPlus.Parsing;
using GqlPlus.Parsing.Operation;
using GqlPlus.Result;

namespace GqlPlus.Operation;

public class ParseOperationTests(Parser<IGqlpOperation>.D parser)
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

    // using AssertionScope scope = new();

    result.ShouldBeOfType<OperationAst>();
    result.Result.ShouldBe(ParseResultKind.Success);
    result.Errors.ShouldBeEmpty();
  }

  [Theory]
  [InlineData("")]
  public void Parse_ShouldFail(string input)
  {
    OperationContext context = new(input);

    IResult<IGqlpOperation> result = _parser.Parse(context, "Operation");
    result.Optional(ast => {
      // using AssertionScope scope = new();

      ast.ShouldBeNull();
      result.IsError(err => err.Message.ShouldNotBeNullOrWhiteSpace());
    });
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

    // using AssertionScope scope = new();

    ast.ShouldBeOfType<OperationAst>()
      .Result.ShouldBe(ParseResultKind.Failure);
    ast.ThrowIfNull().Errors.ShouldNotBeEmpty();
  }

  private readonly Parser<IGqlpOperation>.L _parser = parser;
}
