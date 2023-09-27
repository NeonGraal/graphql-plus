namespace GqlPlus.Verifier.ClassTests;

public class OperationParserTests
{
  [Theory]
  [InlineData("", ParseResult.Failure)]
  [InlineData("Boolean", ParseResult.Success)]
  public void Parse(string input, ParseResult result)
  {
    var tokens = new OperationTokens(input);
    var parser = new OperationParser(tokens);

    OperationAst? ast = parser.Parse();

    ast.Should().NotBeNull();
    ast!.Result.Should().Be(result);
  }

  [Fact(Skip ="WIP")]
  public void ParseDirectives_WithMinimumInput_ReturnsCorrectAst()
  {
    var tokens = new OperationTokens("");
    var parser = new OperationParser(tokens);

    DirectiveAst[] result = parser.ParseDirectives();

    result.Should().NotBeNull();
  }

  [Fact(Skip = "WIP")]
  public void ParseVariables_WithMinimumInput_ReturnsCorrectAst()
  {
    var tokens = new OperationTokens("");
    var parser = new OperationParser(tokens);

    VariableAst[] result = parser.ParseVariables();

    result.Should().NotBeNull();
  }

  [Fact()]
  public void ParseObject_WithMinimumInput_ReturnsCorrectAst()
  {
    var tokens = new OperationTokens("{a}");
    tokens.Read();
    var parser = new OperationParser(tokens);

    SelectionAst[]? result = parser.ParseObject();

    result.Should().NotBeNull();
    result!.Length.Should().Be(1);
  }

  [Fact(Skip = "WIP")]
  public void ParseFragment_WithMinimumInput_ReturnsCorrectAst()
  {
    var tokens = new OperationTokens("");
    var parser = new OperationParser(tokens);

    FragmentAst? result = parser.ParseFragment();

    result.Should().NotBeNull();
  }

  [Fact()]
  public void ParseField_WithMinimumInput_ReturnsCorrectAst()
  {
    var tokens = new OperationTokens("a");
    tokens.Read();
    var parser = new OperationParser(tokens);

    FieldAst? result = parser.ParseField();

    result.Should().NotBeNull();
    result!.Name.Should().Be("a");
  }

  [Fact()]
  public void ParseModifiers_WithMinimumInput_ReturnsCorrectAst()
  {
    var tokens = new OperationTokens("");
    var parser = new OperationParser(tokens);

    ModifierAst[] result = parser.ParseModifiers();

    result.Should().NotBeNull();
    result.Length.Should().Be(0);
  }

  [Fact(Skip = "WIP")]
  public void ParseDefinitions_WithMinimumInput_ReturnsCorrectAst()
  {
    var tokens = new OperationTokens("");
    var parser = new OperationParser(tokens);

    DefinitionAst[] result = parser.ParseDefinitions();

    result.Should().NotBeNull();
  }
}
