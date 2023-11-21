using GqlPlus.Verifier.Ast.Operation;

namespace GqlPlus.Verifier.Parse.Operation;

public class OperationParserTests
{
  private readonly IParser<OperationAst> _parser;

  public OperationParserTests(IParser<OperationAst> parser)
    => _parser = parser;

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
    var context = new OperationContext(input);

    var ast = _parser.Parse(context).Required();

    using var scope = new AssertionScope();

    ast.Should().BeOfType<OperationAst>()
      .Subject.Result.Should().Be(ParseResultKind.Success);
    ast!.Errors.Should().BeEmpty();
  }

  [Theory]
  [InlineData("")]
  public void Parse_ShouldFail(string input)
  {
    var context = new OperationContext(input);

    var result = _parser.Parse(context);
    result.Optional(ast => {
      using var scope = new AssertionScope();

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
    var context = new OperationContext(input);

    var ast = _parser.Parse(context).Optional();

    using var scope = new AssertionScope();

    ast.Should().BeOfType<OperationAst>()
      .Subject.Result.Should().Be(ParseResultKind.Failure);
    ast!.Errors.Should().NotBeEmpty();
  }
}
