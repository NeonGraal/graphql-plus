using GqlPlus.Abstractions.Operation;
using GqlPlus.Ast.Operation;
using GqlPlus.Result;

namespace GqlPlus.Parsing.Operation;

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

    using AssertionScope scope = new();

    result.Should().BeOfType<OperationAst>();
    result.Result.Should().Be(ParseResultKind.Success);
    result.Errors.Should().BeEmpty();
  }

  [Theory]
  [InlineData("")]
  public void Parse_ShouldFail(string input)
  {
    OperationContext context = new(input);

    IResult<IGqlpOperation> result = _parser.Parse(context, "Operation");
    result.Optional(ast => {
      using AssertionScope scope = new();

      ast.Should().BeNull();
      result.IsError(err => err.Message.Should().NotBeNullOrWhiteSpace());
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

    using AssertionScope scope = new();

    ast.Should().BeOfType<OperationAst>()
      .Subject.Result.Should().Be(ParseResultKind.Failure);
    ast!.Errors.Should().NotBeEmpty();
  }

  private readonly Parser<IGqlpOperation>.L _parser = parser;
}
