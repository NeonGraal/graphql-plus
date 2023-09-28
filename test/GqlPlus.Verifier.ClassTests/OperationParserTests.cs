using GqlPlus.Verifier.Ast;
using static GqlPlus.Verifier.ClassTests.OperationTestsHelpers;

namespace GqlPlus.Verifier.ClassTests;

public class OperationParserTests
{
  private OperationTokens Tokens(string input)
  {
    var tokens = new OperationTokens(input);
    tokens.Read();
    return tokens;
  }

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

  [Fact(Skip = "WIP")]
  public void ParseDirectives_WithMinimumInput_ReturnsCorrectAst()
  {
    var parser = new OperationParser(Tokens(""));

    DirectiveAst[] result = parser.ParseDirectives();

    result.Should().NotBeNull();
  }

  [Fact(Skip = "WIP")]
  public void ParseVariables_WithMinimumInput_ReturnsCorrectAst()
  {
    var parser = new OperationParser(Tokens(""));

    VariableAst[] result = parser.ParseVariables();

    result.Should().NotBeNull();
  }

  [Fact()]
  public void ParseObject_WithMinimumInput_ReturnsCorrectAst()
  {
    var parser = new OperationParser(Tokens("{a}"));

    SelectionAst[]? result = parser.ParseObject();

    result.Should().NotBeNull();
    result!.Length.Should().Be(1);
  }

  [Fact(Skip = "WIP")]
  public void ParseFragment_WithMinimumInput_ReturnsCorrectAst()
  {
    var parser = new OperationParser(Tokens(""));

    FragmentAst? result = parser.ParseFragment();

    result.Should().NotBeNull();
  }

  [Fact]
  public void ParseField_WithMinimumInput_ReturnsCorrectAst()
  {
    var parser = new OperationParser(Tokens("a"));

    FieldAst? result = parser.ParseField();

    result.Should().NotBeNull();
    result!.Name.Should().Be("a");
  }

  [Theory]
  [InlineData("", 0)]
  [InlineData("?", 1)]
  [InlineData("[]", 1)]
  [InlineData("[String]", 1)]
  [InlineData("[~?]", 1)]
  [InlineData("[]?", 2)]
  [InlineData("[_?][]?", 3)]
  public void ParseModifiers_WithInput_ReturnsGivenNumber(string input, int count)
  {
    var parser = new OperationParser(Tokens(input));

    ModifierAst[] result = parser.ParseModifiers();

    result.Should().NotBeNull();
    result.Length.Should().Be(count);
  }

  [Fact]
  public void ParseModifiers_WithThree_ReturnsSpecific()
  {
    var parser = new OperationParser(Tokens("[_?][]?"));

    ModifierAst[] result = parser.ParseModifiers();

    result.Should()
      .NotBeNull().And
      .Equal(new ModifierAst[] {
      new(ModifierKind.Dict) { Key = "_", KeyOptional = true},
      new(ModifierKind.List),
      new(ModifierKind.Optional),
    });
  }

  [Fact(Skip = "WIP")]
  public void ParseDefinitions_WithMinimumInput_ReturnsCorrectAst()
  {
    var parser = new OperationParser(Tokens(""));

    DefinitionAst[] result = parser.ParseDefinitions();

    result.Should().NotBeNull();
  }
}
