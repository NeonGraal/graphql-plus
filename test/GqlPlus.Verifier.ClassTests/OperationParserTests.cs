using GqlPlus.Verifier.Ast;
using static GqlPlus.Verifier.ClassTests.OperationTestsHelpers;

namespace GqlPlus.Verifier.ClassTests;

public class OperationParserTests
{
  [Theory]
  [InlineData("", ParseResult.Failure)]
  [InlineData(":Boolean", ParseResult.Success)]
  [InlineData("query Test { success }", ParseResult.Success)]
  [InlineData("($name) { person($name) { name } }", ParseResult.Success)]
  [InlineData("{...person}fragment person on Person{name}", ParseResult.Success)]
  [InlineData("($test)@test($test):Boolean", ParseResult.Success)]
  public void Parse(string input, ParseResult result)
  {
    var tokens = new Tokenizer(input);
    var parser = new OperationParser(tokens);

    OperationAst? ast = parser.Parse();

    ast.Should().NotBeNull();
    ast!.Result.Should().Be(result);
  }

  #region Variables tests

  [Theory, RepeatData(Repeats)]
  public void ParseVariables_WithMinimumInput_ReturnsCorrectAst(
    [RegularExpression(IdentifierPattern)] string variable)
  {
    var parser = new OperationParser(Tokens($"(${variable})"));

    parser.ParseVariables(out VariableAst[] result).Should().BeTrue();

    result.Should()
      .NotBeNull().And
      .Equal(new VariableAst(variable));
  }

  [Theory, RepeatData(Repeats)]
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

  [Theory, RepeatData(Repeats)]
  public void ParseVariables_WithModifiers_ReturnsCorrectAst(
    [RegularExpression(IdentifierPattern)] string variable)
  {
    var parser = new OperationParser(Tokens($"(${variable}[]?)"));

    parser.ParseVariables(out VariableAst[] result).Should().BeTrue();

    result.Should()
      .NotBeNull().And
      .Equal(new VariableAst(variable) { Modifers = new[] { ModifierAst.List, ModifierAst.Optional } });
  }

  [Theory(Skip = "WIP"), RepeatData(Repeats)]
  public void ParseVariables_WithConstant_ReturnsCorrectAst(
    [RegularExpression(IdentifierPattern)] string variable)
  {
    var parser = new OperationParser(Tokens($"(${variable}=10)"));

    parser.ParseVariables(out VariableAst[] result).Should().BeTrue();

    result.Should()
      .NotBeNull().And
      .Equal(new VariableAst(variable));
  }

  [Theory, RepeatData(Repeats)]
  public void ParseVariables_WithDirective_ReturnsCorrectAst(
    [RegularExpression(IdentifierPattern)] string variable,
    [RegularExpression(IdentifierPattern)] string directive)
  {
    var parser = new OperationParser(Tokens($"(${variable}@{directive})"));
    var expected = new VariableAst(variable) { Directives = directive.Directives() };

    parser.ParseVariables(out VariableAst[] result).Should().BeTrue();

    result.Should().NotBeNull().And.Equal(expected);
  }

  #endregion

  #region Directives tests

  [Theory, RepeatData(Repeats)]
  public void ParseDirectives_WithMinimumInput_ReturnsCorrectAst(
    [RegularExpression(IdentifierPattern)] string directive)
  {
    var parser = new OperationParser(Tokens("@" + directive));

    DirectiveAst[] result = parser.ParseDirectives();

    result.Should()
      .NotBeNull().And
      .Equal(new DirectiveAst(directive));
  }

  [Theory, RepeatData(Repeats)]
  public void ParseDirectives_WithArgument_ReturnsCorrectAst(
    [RegularExpression(IdentifierPattern)] string directive,
    [RegularExpression(IdentifierPattern)] string variable)
  {
    var parser = new OperationParser(Tokens("@" + directive + "($" + variable + ")"));
    var expected = new DirectiveAst(directive) { Argument = new ArgumentAst { Variable = variable } };

    DirectiveAst[] result = parser.ParseDirectives();

    result.Should().NotBeNull().And.Equal(expected);
  }

  #endregion

  #region Object tests

  [Theory, RepeatData(Repeats)]
  public void ParseSelections_WithMinimumInput_ReturnsCorrectAst(
    [RegularExpression(IdentifierPattern)] string field)
  {
    var parser = new OperationParser(Tokens("{" + field + "}"));

    parser.ParseObject(out SelectionAst[] result).Should().BeTrue();

    result.Should().NotBeNull();
    result!.Length.Should().Be(1);
  }

  [Fact]
  public void ParseSelections_WithNoFields_ReturnsFalse()
  {
    var parser = new OperationParser(Tokens("{}"));

    parser.ParseObject(out SelectionAst[] result).Should().BeFalse();

    result.Should().NotBeNull();
    result!.Length.Should().Be(0);
  }

  #endregion

  #region Selection tests

  [Theory, RepeatInlineData(Repeats, "..."), RepeatInlineData(Repeats, "|")]
  public void ParseSelection_WithMinimumInline_ReturnsCorrectAst(
    string prefix, [RegularExpression(IdentifierPattern)] string field)
  {
    var parser = new OperationParser(Tokens(prefix + " {" + field + "}"));
    var expected = new InlineAst(field.Fields());

    parser.ParseSelection(out SelectionAst result).Should().BeTrue();

    result.Should().BeOfType<InlineAst>().Equals(expected);
  }

  [Theory]
  [RepeatInlineData(Repeats, "...", " on ")]
  [RepeatInlineData(Repeats, "|", " on ")]
  [RepeatInlineData(Repeats, "...", ":")]
  [RepeatInlineData(Repeats, "|", ":")]
  public void ParseSelection_WithInlineType_ReturnsCorrectAst(
    string inlinePrefix, string typePrefix,
    [RegularExpression(IdentifierPattern)] string field,
    [RegularExpression(IdentifierPattern)] string inlineType)
  {
    var parser = new OperationParser(Tokens(inlinePrefix + typePrefix + inlineType + "{" + field + "}"));
    var expected = new InlineAst(field.Fields()) {
      OnType = inlineType
    };

    parser.ParseSelection(out SelectionAst result).Should().BeTrue();

    result.Should().BeOfType<InlineAst>().Equals(expected);
  }

  [Theory, RepeatData(Repeats)]
  public void ParseSelection_WithInlineDirective_ReturnsCorrectAst(
    [RegularExpression(IdentifierPattern)] string directive,
    [RegularExpression(IdentifierPattern)] string field)
  {
    var parser = new OperationParser(Tokens("|@" + directive + "{" + field + "}"));
    var expected = new InlineAst(field.Fields()) { Directives = directive.Directives() };

    parser.ParseSelection(out SelectionAst result).Should().BeTrue();

    result.Should().BeOfType<InlineAst>().Equals(expected);
  }

  [Theory, RepeatInlineData(Repeats, "..."), RepeatInlineData(Repeats, "|")]
  public void ParseSelection_WithMinimumSpread_ReturnsCorrectAst(
    string prefix, [RegularExpression(IdentifierPattern)] string fragment)
  {
    var parser = new OperationParser(Tokens(prefix + fragment));
    var expected = new SpreadAst(fragment);

    parser.ParseSelection(out SelectionAst result).Should().BeTrue();

    result.Should().BeOfType<SpreadAst>()
      .Subject.Name.Should().Be(fragment);
    result.Should().BeOfType<SpreadAst>().Equals(expected);
  }

  [Theory, RepeatData(Repeats)]
  public void ParseSelection_WithSpreadDirective_ReturnsCorrectAst(
    [RegularExpression(IdentifierPattern)] string fragment,
    [RegularExpression(IdentifierPattern)] string directive)
  {
    var parser = new OperationParser(Tokens($"|{fragment}@{directive}"));
    var expected = new SpreadAst(fragment) { Directives = directive.Directives() };

    parser.ParseSelection(out SelectionAst result).Should().BeTrue();

    result.Should().BeOfType<SpreadAst>()
      .Subject.Name.Should().Be(fragment);
    result.Should().BeOfType<SpreadAst>().Equals(expected);
  }

  #endregion

  #region Field tests

  [Theory, RepeatData(Repeats)]
  public void ParseField_WithJustField_ReturnsCorrectAst(
    [RegularExpression(IdentifierPattern)] string field)
  {
    var parser = new OperationParser(Tokens(field));
    var expected = new FieldAst(field);

    parser.ParseField(out SelectionAst result).Should().BeTrue();

    result.Should().BeOfType<FieldAst>()
      .Subject.Name.Should().Be(field);
    result.Should().BeOfType<FieldAst>().Equals(expected);
  }

  [Theory, RepeatData(Repeats)]
  public void ParseField_WithAlias_ReturnsCorrectAst(
    [RegularExpression(IdentifierPattern)] string alias,
    [RegularExpression(IdentifierPattern)] string field)
  {
    var parser = new OperationParser(Tokens(alias + ":" + field));
    var expected = new FieldAst(field) { Alias = alias };

    parser.ParseField(out SelectionAst result).Should().BeTrue();

    result.Should().BeOfType<FieldAst>()
      .Subject.Alias.Should().Be(alias);
    result.As<FieldAst>().Name.Should().Be(field);
    result.Should().BeOfType<FieldAst>().Equals(expected);
  }

  [Theory, RepeatData(Repeats)]
  public void ParseField_WithArgument_ReturnsCorrectAst(
    [RegularExpression(IdentifierPattern)] string field,
    [RegularExpression(IdentifierPattern)] string variable)
  {
    var parser = new OperationParser(Tokens(field + "($" + variable + ")"));
    var expected = new FieldAst(field) { Argument = new ArgumentAst { Variable = variable } };

    parser.ParseField(out SelectionAst result).Should().BeTrue();

    result.Should().BeOfType<FieldAst>().Equals(expected);
  }

  [Theory, RepeatData(Repeats)]
  public void ParseField_WithSelection_ReturnsCorrectAst(
    [RegularExpression(IdentifierPattern)] string field,
    [RegularExpression(IdentifierPattern)] string selection)
  {
    var parser = new OperationParser(Tokens(field + "{" + selection + "}"));
    var expected = new FieldAst(field) { Selections = selection.Fields() };

    parser.ParseField(out SelectionAst result).Should().BeTrue();

    result.Should().BeOfType<FieldAst>().Equals(expected);
  }

  [Theory, RepeatData(Repeats)]
  public void ParseField_WithDirective_ReturnsCorrectAst(
    [RegularExpression(IdentifierPattern)] string field,
    [RegularExpression(IdentifierPattern)] string directive)
  {
    var parser = new OperationParser(Tokens(field + "@" + directive));
    var expected = new FieldAst(field) { Directives = directive.Directives() };

    parser.ParseField(out SelectionAst result).Should().BeTrue();

    result.Should().BeOfType<FieldAst>().Equals(expected);
  }

  #endregion

  #region Modifers tests

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

  #endregion

  #region Fragments tests

  [Theory]
  [RepeatInlineData(Repeats, "fragment ", " on ")]
  [RepeatInlineData(Repeats, "&", " on ")]
  [RepeatInlineData(Repeats, "fragment ", ":")]
  [RepeatInlineData(Repeats, "&", ":")]
  public void ParseFragments_WithMinimumInput_ReturnsCorrectAst(
    string fragmentPrefix, string typePrefix,
    [RegularExpression(IdentifierPattern)] string fragment,
    [RegularExpression(IdentifierPattern)] string onType,
    [RegularExpression(IdentifierPattern)] string field)
  {
    var parser = new OperationParser(Tokens(fragmentPrefix + fragment + typePrefix + onType + "{" + field + "}"));
    var expected = new FragmentAst(fragment, onType, field.Fields());

    FragmentAst[] result = parser.ParseFragments();

    result.Should().Equal(expected);
  }

  [Theory, RepeatData(Repeats)]
  public void ParseFragments_Directive_ReturnsCorrectAst(
    [RegularExpression(IdentifierPattern)] string fragment,
    [RegularExpression(IdentifierPattern)] string onType,
    [RegularExpression(IdentifierPattern)] string field,
    [RegularExpression(IdentifierPattern)] string directive)
  {
    var parser = new OperationParser(Tokens("&" + fragment + ":" + onType + "@" + directive + "{" + field + "}"));
    var expected = new FragmentAst(fragment, onType, field.Fields()) { Directives = directive.Directives() };

    FragmentAst[] result = parser.ParseFragments();

    result.Should().Equal(expected);
  }

  #endregion

  #region Argument tests

  [Theory, RepeatData(Repeats)]
  public void ParseArgument_WithVariable_ReturnsCorrectAst(
    [RegularExpression(IdentifierPattern)] string variable)
  {
    var parser = new OperationParser(Tokens("($" + variable + ")"));
    var expected = new ArgumentAst { Variable = variable };

    parser.ParseArgument(out ArgumentAst result).Should().BeTrue();

    result.Should().Be(expected);
  }

  #endregion

  private Tokenizer Tokens(string input)
  {
    var tokens = new Tokenizer(input);
    tokens.Read();
    return tokens;
  }
}
