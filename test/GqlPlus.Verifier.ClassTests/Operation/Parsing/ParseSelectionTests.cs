using GqlPlus.Verifier.Ast.Operation;

namespace GqlPlus.Verifier.Operation.Parsing;

public class ParseSelectionTests
{
  [Theory, RepeatInlineData(Repeats, "..."), RepeatInlineData(Repeats, "|")]
  public void WithInline_ReturnsCorrectAst(string prefix, string field)
    => Test.TrueExpected(
      prefix + " {" + field + "}",
      new InlineAst(AstNulls.At, field.Fields()));

  [Theory]
  [RepeatInlineData(Repeats, "...", " on ")]
  [RepeatInlineData(Repeats, "|", " on ")]
  [RepeatInlineData(Repeats, "...", ":")]
  [RepeatInlineData(Repeats, "|", ":")]
  public void WithInlineType_ReturnsCorrectAst(string inlinePrefix, string typePrefix, string field, string inlineType)
    => Test.TrueExpected(
      inlinePrefix + typePrefix + inlineType + "{" + field + "}",
      new InlineAst(AstNulls.At, field.Fields()) { OnType = inlineType });

  [Theory, RepeatData(Repeats)]
  public void WithInlineDirective_ReturnsCorrectAst(string directive, string field)
    => Test.TrueExpected(
      "|@" + directive + "{" + field + "}",
      new InlineAst(AstNulls.At, field.Fields()) { Directives = directive.Directives() });

  [Theory, RepeatData(Repeats)]
  public void WithInlineAll_ReturnsCorrectAst(string inlineType, string directive, string field)
    => Test.TrueExpected(
      $"|:{inlineType}@" + directive + "{" + field + "}",
      new InlineAst(AstNulls.At, field.Fields()) {
        OnType = inlineType,
        Directives = directive.Directives(),
      });

  [Theory, RepeatInlineData(Repeats, "..."), RepeatInlineData(Repeats, "|")]
  public void WithSpread_ReturnsCorrectAst(string prefix, string fragment)
    => Test.TrueExpected(
      prefix + fragment,
      new SpreadAst(AstNulls.At, fragment),
      fragment == "on");

  [Theory, RepeatData(Repeats)]
  public void WithSpreadDirective_ReturnsCorrectAst(string fragment, string directive)
    => Test.TrueExpected(
      $"|{fragment}@{directive}",
      new SpreadAst(AstNulls.At, fragment) { Directives = directive.Directives() },
      fragment == "on");

  [Fact]
  public void WithInvalidSelection_ReturnsFalse()
    => Test.False("|?", CheckDefault);

  [Fact]
  public void WithInvalidSpread_ReturnsFalse()
    => Test.False("|:?", CheckDefault);

  private void CheckDefault(AstSelection result)
    => result.Should().BeOfType<AstNulls.NullSelectionAst>();

  private static OneChecks<OperationParser, AstSelection> Test => new(
    tokens => new OperationParser(tokens),
    (OperationParser parser, out AstSelection result) => parser.ParseSelection(out result));
}
