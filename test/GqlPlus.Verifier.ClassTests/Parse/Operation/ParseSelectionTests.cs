using GqlPlus.Verifier.Ast.Operation;

namespace GqlPlus.Verifier.Parse.Operation;

public class ParseSelectionTests
{
  [Theory, RepeatInlineData(Repeats, "..."), RepeatInlineData(Repeats, "|")]
  public void WithInline_ReturnsCorrectAst(string prefix, string[] fields)
    => Test.TrueExpected(
      prefix + " {" + fields.Joined() + "}",
      new InlineAst(AstNulls.At, fields.Fields()));

  [Theory]
  [RepeatInlineData(Repeats, "...", " on ")]
  [RepeatInlineData(Repeats, "|", " on ")]
  [RepeatInlineData(Repeats, "...", ":")]
  [RepeatInlineData(Repeats, "|", ":")]
  public void WithInlineType_ReturnsCorrectAst(string inlinePrefix, string typePrefix, string[] fields, string inlineType)
    => Test.TrueExpected(
      inlinePrefix + typePrefix + inlineType + "{" + fields.Joined() + "}",
      new InlineAst(AstNulls.At, fields.Fields()) { OnType = inlineType });

  [Theory, RepeatData(Repeats)]
  public void WithInlineDirective_ReturnsCorrectAst(string[] directives, string[] fields)
    => Test.TrueExpected(
      "|" + directives.Joined("@") + "{" + fields.Joined() + "}",
      new InlineAst(AstNulls.At, fields.Fields()) { Directives = directives.Directives() });

  [Theory, RepeatData(Repeats)]
  public void WithInlineAll_ReturnsCorrectAst(string inlineType, string[] directives, string[] fields)
    => Test.TrueExpected(
      $"|:" + inlineType + directives.Joined("@") + "{" + fields.Joined() + "}",
      new InlineAst(AstNulls.At, fields.Fields()) {
        OnType = inlineType,
        Directives = directives.Directives(),
      });

  [Theory, RepeatInlineData(Repeats, "..."), RepeatInlineData(Repeats, "|")]
  public void WithSpread_ReturnsCorrectAst(string prefix, string fragment)
    => Test.TrueExpected(
      prefix + fragment,
      new SpreadAst(AstNulls.At, fragment),
      fragment.StartsWith("on", StringComparison.OrdinalIgnoreCase));

  [Theory, RepeatData(Repeats)]
  public void WithSpreadDirective_ReturnsCorrectAst(string fragment, string[] directives)
    => Test.TrueExpected(
      $"|" + fragment + directives.Joined("@"),
      new SpreadAst(AstNulls.At, fragment) { Directives = directives.Directives() },
      fragment.StartsWith("on", StringComparison.OrdinalIgnoreCase));

  [Fact]
  public void WithInvalidSelection_ReturnsFalse()
    => Test.False("|?", CheckNull);

  [Fact]
  public void WithInvalidSpread_ReturnsFalse()
    => Test.False("|:?", CheckNull);

  private void CheckNull(IAstSelection? result)
    => result.Should().BeNull();

  private readonly OneChecksParser<IAstSelection> Test;

  public ParseSelectionTests(Parser<IAstSelection>.D parser)
    => Test = new(parser);
}
