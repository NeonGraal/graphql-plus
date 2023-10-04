using GqlPlus.Verifier.Ast;

namespace GqlPlus.Verifier.Operation;

public class ParserTests
{
  [Theory]
  [InlineData("", ParseResult.Failure)]
  [InlineData(":Boolean", ParseResult.Success)]
  [InlineData("query Test { success }", ParseResult.Success)]
  [InlineData("($name) { person($name) { name } }", ParseResult.Success)]
  [InlineData("{...person}fragment person on Person{name}", ParseResult.Success)]
  [InlineData("($test)@test($test):Boolean", ParseResult.Success)]
  [InlineData("($test):Boolean($test)", ParseResult.Success)]
  [InlineData("{test}[]", ParseResult.Success)]
  public void Parse(string input, ParseResult result)
  {
    var tokens = new Tokenizer(input);
    var parser = new OperationParser(tokens);

    OperationAst? ast = parser.Parse();

    ast.Should().NotBeNull();
    ast!.Result.Should().Be(result);
  }
}
