using GqlPlus.Verifier.Ast;

namespace GqlPlus.Verifier.Operation.Parsing;

public class ParserTests
{
  [Theory]
  [InlineData(":Boolean")]
  [InlineData("query:Boolean?")]
  [InlineData("query Test{success}")]
  [InlineData("($name){person($name){name}}")]
  [InlineData("&person:Person{name}{...person}")]
  [InlineData("{...person}fragment person on Person{name}")]
  [InlineData("{...person}&person on Person{name}")]
  [InlineData("($test)@test($test):Boolean")]
  [InlineData("($test):Boolean($test)")]
  [InlineData("{test}[]")]
  public void Parse_ShouldSucceed(string input)
  {
    var parser = new OperationParser(new Tokenizer(input));

    OperationAst? ast = parser.Parse();

    ast.Should().BeOfType<OperationAst>()
      .Subject.Result.Should().Be(ParseResult.Success);
    ast!.Errors.Should().BeEmpty();
  }

  [Theory]
  [InlineData("")]
  [InlineData(":")]
  [InlineData("query")]
  [InlineData("query Test")]
  [InlineData("{")]
  [InlineData("{field")]
  [InlineData("{}")]
  [InlineData("(")]
  [InlineData("($")]
  [InlineData("($test")]
  [InlineData("()")]
  [InlineData("($test)")]
  [InlineData(")")]
  public void Parse_ShouldFail(string input)
  {
    var parser = new OperationParser(new Tokenizer(input));

    OperationAst? ast = parser.Parse();

    ast.Should().BeOfType<OperationAst>()
      .Subject.Result.Should().Be(ParseResult.Failure);
    ast!.Errors.Should().NotBeEmpty();
  }
}
