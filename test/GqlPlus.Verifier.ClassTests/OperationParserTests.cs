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
  [InlineData(":Boolean", ParseResult.Success)]
  [InlineData("query Test { success }", ParseResult.Success)]
  [InlineData("($name) { person($name) { name } }", ParseResult.Success)]
  [InlineData("{...person}fragment person on Person{name}", ParseResult.Success)]
  public void Parse(string input, ParseResult result)
  {
    var tokens = new OperationTokens(input);
    var parser = new OperationParser(tokens);

    OperationAst? ast = parser.Parse();

    ast.Should().NotBeNull();
    ast!.Result.Should().Be(result);
  }

  [Theory, RepeatData(10)]
  public void ParseDirectives_WithMinimumInput_ReturnsCorrectAst(
    [RegularExpression(IdentifierPattern)] string directive)
  {
    var parser = new OperationParser(Tokens("@" + directive));

    DirectiveAst[] result = parser.ParseDirectives();

    result.Should()
      .NotBeNull().And
      .Equal(new DirectiveAst(directive));
  }

  [Theory, RepeatData(10)]
  public void ParseDirectives_WithArgument_ReturnsCorrectAst(
    [RegularExpression(IdentifierPattern)] string directive,
    [RegularExpression(IdentifierPattern)] string variable)
  {
    var parser = new OperationParser(Tokens("@" + directive + "($" + variable + ")"));
    var expected = new DirectiveAst(directive) { Argument = new ArgumentAst { Variable = variable } };

    DirectiveAst[] result = parser.ParseDirectives();

    result.Should().NotBeNull().And.Equal(expected);
  }

  [Theory, RepeatData(10)]
  public void ParseVariables_WithMinimumInput_ReturnsCorrectAst(
    [RegularExpression(IdentifierPattern)] string variable)
  {
    var parser = new OperationParser(Tokens($"(${variable})"));

    parser.ParseVariables(out VariableAst[] result).Should().BeTrue();

    result.Should()
      .NotBeNull().And
      .Equal(new VariableAst(variable));
  }

  [Theory, RepeatData(10)]
  public void ParseVariables_WithType_ReturnsCorrectAst(
    [RegularExpression(IdentifierPattern)] string variable,
    [RegularExpression(IdentifierPattern)] string varType)
  {
    var parser = new OperationParser(Tokens($"(${variable}:{varType})"));

    parser.ParseVariables(out VariableAst[] result).Should().BeTrue();

    result.Should()
      .NotBeNull().And
      .Equal(new VariableAst(variable) { Type = varType });
  }

  [Theory, RepeatData(10)]
  public void ParseVariables_WithModifiers_ReturnsCorrectAst(
    [RegularExpression(IdentifierPattern)] string variable)
  {
    var parser = new OperationParser(Tokens($"(${variable}[]?)"));

    parser.ParseVariables(out VariableAst[] result).Should().BeTrue();

    result.Should()
      .NotBeNull().And
      .Equal(new VariableAst(variable) { Modifers = new[] { ModifierAst.List, ModifierAst.Optional } });
  }

  [Theory, RepeatData(10)]
  public void ParseSelections_WithMinimumInput_ReturnsCorrectAst(
    [RegularExpression(IdentifierPattern)] string field)
  {
    var parser = new OperationParser(Tokens("{" + field + "}"));

    parser.ParseSelections(out SelectionAst[] result).Should().BeTrue();

    result.Should().NotBeNull();
    result!.Length.Should().Be(1);
  }

  [Fact]
  public void ParseSelections_WithNoFields_ReturnsFalse()
  {
    var parser = new OperationParser(Tokens("{}"));

    parser.ParseSelections(out SelectionAst[] result).Should().BeFalse();

    result.Should().NotBeNull();
    result!.Length.Should().Be(0);
  }

  [Theory, RepeatInlineData(10, "..."), RepeatInlineData(10, "|")]
  public void ParseFragment_WithMinimumSpread_ReturnsCorrectAst(
    string prefix, [RegularExpression(IdentifierPattern)] string fragment)
  {
    var parser = new OperationParser(Tokens(prefix + fragment));

    parser.ParseFragment(out SelectionAst result).Should().BeTrue();

    result.Should().BeOfType<SpreadAst>()
      .Subject.Name.Should().Be(fragment);
  }

  [Theory, RepeatInlineData(10, "..."), RepeatInlineData(10, "|")]
  public void ParseFragment_WithMinimumInline_ReturnsCorrectAst(
    string prefix, [RegularExpression(IdentifierPattern)] string field)
  {
    var parser = new OperationParser(Tokens(prefix + " {" + field + "}"));
    var expected = new FieldAst(field);

    parser.ParseFragment(out SelectionAst result).Should().BeTrue();

    result.Should().BeOfType<InlineAst>()
      .Subject.OnType.Should().BeNull();
    result.As<InlineAst>().Selections.Should().Equal(expected);
  }

  [Theory, RepeatData(10)]
  public void ParseField_WithJustField_ReturnsCorrectAst(
    [RegularExpression(IdentifierPattern)] string field)
  {
    var parser = new OperationParser(Tokens(field));

    parser.ParseField(out SelectionAst result).Should().BeTrue();

    result.Should().BeOfType<FieldAst>()
      .Subject.Name.Should().Be(field);
  }

  [Theory, RepeatData(10)]
  public void ParseField_WithAlias_ReturnsCorrectAst(
    [RegularExpression(IdentifierPattern)] string alias,
    [RegularExpression(IdentifierPattern)] string field)
  {
    var parser = new OperationParser(Tokens(alias + ":" + field));

    parser.ParseField(out SelectionAst result).Should().BeTrue();

    result.Should().BeOfType<FieldAst>()
      .Subject.Alias.Should().Be(alias);
    result.As<FieldAst>().Name.Should().Be(field);
  }

  [Theory, RepeatData(10)]
  public void ParseField_WithArgument_ReturnsCorrectAst(
    [RegularExpression(IdentifierPattern)] string field,
    [RegularExpression(IdentifierPattern)] string variable)
  {
    var parser = new OperationParser(Tokens(field + "($" + variable + ")"));
    var expected = new ArgumentAst { Variable = variable };

    parser.ParseField(out SelectionAst result).Should().BeTrue();

    result.Should().BeOfType<FieldAst>()
      .Subject.Name.Should().Be(field);
    result.As<FieldAst>().Argument.Should().Be(expected);
  }

  [Theory, RepeatData(10)]
  public void ParseField_WithSelection_ReturnsCorrectAst(
    [RegularExpression(IdentifierPattern)] string field,
    [RegularExpression(IdentifierPattern)] string selection)
  {
    var parser = new OperationParser(Tokens(field + "{" + selection + "}"));
    var expected = new FieldAst(selection);

    parser.ParseField(out SelectionAst result).Should().BeTrue();

    result.Should().BeOfType<FieldAst>()
      .Subject.Name.Should().Be(field);
    result.As<FieldAst>().Selections.Should().Equal(expected);
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
        new() { Key = "_", KeyOptional = true},
        ModifierAst.List,
        ModifierAst.Optional
      });
  }

  [Theory]
  [RepeatInlineData(10, "fragment ", " on ")]
  [RepeatInlineData(10, "&", " on ")]
  [RepeatInlineData(10, "fragment ", ":")]
  [RepeatInlineData(10, "&", ":")]
  public void ParseDefinitions_WithMinimumInput_ReturnsCorrectAst(
    string definitionPrefix, string typePrefix,
    [RegularExpression(IdentifierPattern)] string fragment,
    [RegularExpression(IdentifierPattern)] string onType,
    [RegularExpression(IdentifierPattern)] string field)
  {
    var parser = new OperationParser(Tokens(definitionPrefix + fragment + typePrefix + onType + "{" + field + "}"));
    var expected = new DefinitionAst(fragment, onType) {
      Selections = new[] { new FieldAst(field) }
    };

    DefinitionAst[] result = parser.ParseDefinitions();

    result.Should()
      .NotBeNull().And
      .Equal(expected);
  }

  [Theory, RepeatData(10)]
  public void ParseArgument_WithVariable_ReturnsCorrectAst(
    [RegularExpression(IdentifierPattern)] string variable)
  {
    var parser = new OperationParser(Tokens("($" + variable + ")"));
    var expected = new ArgumentAst { Variable = variable };

    parser.ParseArgument(out ArgumentAst result).Should().BeTrue();

    result.Should().Be(expected);
  }
}
