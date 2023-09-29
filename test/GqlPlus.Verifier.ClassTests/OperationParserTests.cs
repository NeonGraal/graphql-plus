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

  [Theory, RepeatAutoData(10)]
  public void ParseDirectives_WithMinimumInput_ReturnsCorrectAst(
    [RegularExpression(IdentifierPattern)] string directive)
  {
    var parser = new OperationParser(Tokens("@" + directive));

    DirectiveAst[] result = parser.ParseDirectives();

    result.Should()
      .NotBeNull().And
      .Equal(new DirectiveAst(directive));
  }

  [Theory, RepeatAutoData(10)]
  public void ParseVariables_WithMinimumInput_ReturnsCorrectAst(
    [RegularExpression(IdentifierPattern)] string variable)
  {
    var parser = new OperationParser(Tokens($"(${variable})"));

    VariableAst[] result = parser.ParseVariables();

    result.Should()
      .NotBeNull().And
      .Equal(new VariableAst(variable));
  }

  [Theory, RepeatAutoData(10)]
  public void ParseObject_WithMinimumInput_ReturnsCorrectAst(
    [RegularExpression(IdentifierPattern)] string field)
  {
    var parser = new OperationParser(Tokens("{" + field + "}"));

    parser.ParseObject(out var result).Should().BeTrue();

    result.Should().NotBeNull();
    result!.Length.Should().Be(1);
  }

  [Fact]
  public void ParseObject_WithNoFields_ReturnsFalse()
  {
    var parser = new OperationParser(Tokens("{}"));

    parser.ParseObject(out var result).Should().BeFalse();

    result.Should().NotBeNull();
    result!.Length.Should().Be(0);
  }

  [Theory, RepeatAutoData(10)]
  public void ParseFragment_WithMinimumSpread_ReturnsCorrectAst(
    [RegularExpression(IdentifierPattern)] string fragment)
  {
    var parser = new OperationParser(Tokens("..." + fragment));

    parser.ParseFragment(out var result).Should().BeTrue();

    result.Should().BeOfType<SpreadAst>()
      .Subject.Name.Should().Be(fragment);
  }

  [Theory, RepeatAutoData(10)]
  public void ParseFragment_WithMinimumInline_ReturnsCorrectAst(
    [RegularExpression(IdentifierPattern)] string field)
  {
    var parser = new OperationParser(Tokens("... {" + field + "}"));
    var expected = new FieldAst(field);

    parser.ParseFragment(out var result).Should().BeTrue();

    result.Should().BeOfType<InlineAst>()
      .Subject.OnType.Should().BeNull();
    result.As<InlineAst>().Selections.Should().Equal(expected);
  }

  [Theory, RepeatAutoData(10)]
  public void ParseField_WithJustField_ReturnsCorrectAst(
    [RegularExpression(IdentifierPattern)] string field)
  {
    var parser = new OperationParser(Tokens(field));

    parser.ParseField(out var result).Should().BeTrue();

    result.Should().BeOfType<FieldAst>()
      .Subject.Name.Should().Be(field);
  }

  [Theory, RepeatAutoData(10)]
  public void ParseField_WithAlias_ReturnsCorrectAst(
    [RegularExpression(IdentifierPattern)] string alias,
    [RegularExpression(IdentifierPattern)] string field)
  {
    var parser = new OperationParser(Tokens(alias + ":" + field));

    parser.ParseField(out var result).Should().BeTrue();

    result.Should().BeOfType<FieldAst>()
      .Subject.Alias.Should().Be(alias);
    result.As<FieldAst>().Name.Should().Be(field);
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

  [Theory, RepeatAutoData(10)]
  public void ParseDefinitions_WithMinimumInput_ReturnsCorrectAst(
    [RegularExpression(IdentifierPattern)] string fragment,
    [RegularExpression(IdentifierPattern)] string onType,
    [RegularExpression(IdentifierPattern)] string field)
  {
    var parser = new OperationParser(Tokens("fragment " + fragment + " on " + onType + "{" + field + "}"));
    var expected = new DefinitionAst(fragment, onType) {
      Selections = new[] { new FieldAst(field) }
    };

    DefinitionAst[] result = parser.ParseDefinitions();

    result.Should()
      .NotBeNull().And
      .Equal(expected);
  }
}
