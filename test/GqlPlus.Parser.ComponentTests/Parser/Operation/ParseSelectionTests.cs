using GqlPlus.Abstractions.Operation;
using GqlPlus.Ast.Operation;

namespace GqlPlus.Parser.Operation;

public class ParseSelectionTests(
  IOneChecksParser<IGqlpSelection> checks
)
{
  [Theory]
  [RepeatInlineData("...")]
  [RepeatInlineData("|")]
  public void WithInline_ReturnsCorrectAst(string prefix, string[] fields)
    => checks.TrueExpected(
      prefix + " {" + fields.Joined() + "}",
      new InlineAst(AstNulls.At, fields.Fields()));

  [Theory]
  [RepeatInlineData("...", " on ")]
  [RepeatInlineData("|", " on ")]
  [RepeatInlineData("...", ":")]
  [RepeatInlineData("|", ":")]
  public void WithInlineType_ReturnsCorrectAst(string inlinePrefix, string typePrefix, string[] fields, string inlineType)
    => checks.TrueExpected(
      inlinePrefix + typePrefix + inlineType + "{" + fields.Joined() + "}",
      new InlineAst(AstNulls.At, fields.Fields()) { OnType = inlineType });

  [Theory, RepeatData]
  public void WithInlineDirective_ReturnsCorrectAst(string[] directives, string[] fields)
    => checks.TrueExpected(
      "|" + directives.Joined(s => "@" + s) + "{" + fields.Joined() + "}",
      new InlineAst(AstNulls.At, fields.Fields()) { Directives = directives.Directives() });

  [Theory, RepeatData]
  public void WithInlineAll_ReturnsCorrectAst(string inlineType, string[] directives, string[] fields)
    => checks.TrueExpected(
      $"|:" + inlineType + directives.Joined(s => "@" + s) + "{" + fields.Joined() + "}",
      new InlineAst(AstNulls.At, fields.Fields()) {
        OnType = inlineType,
        Directives = directives.Directives(),
      });

  [Theory]
  [RepeatInlineData("...")]
  [RepeatInlineData("|")]
  public void WithSpread_ReturnsCorrectAst(string prefix, string fragment)
    => checks
      .SkipWhitespace(fragment)
      .SkipIf(fragment.StartsWith("on", StringComparison.OrdinalIgnoreCase))
      .TrueExpected(
        prefix + fragment,
        new SpreadAst(AstNulls.At, fragment));

  [Theory, RepeatData]
  public void WithSpreadDirective_ReturnsCorrectAst(string fragment, string[] directives)
    => checks
      .SkipWhitespace(fragment)
      .SkipIf(fragment.StartsWith("on", StringComparison.OrdinalIgnoreCase))
      .TrueExpected(
        $"|" + fragment + directives.Joined(s => "@" + s),
        new SpreadAst(AstNulls.At, fragment) { Directives = directives.Directives() });

  [Fact]
  public void WithInvalidSelection_ReturnsFalse()
    => checks.FalseExpected("|?", CheckNull);

  [Fact]
  public void WithInvalidSpread_ReturnsFalse()
    => checks.FalseExpected("|:?", CheckNull);

  private void CheckNull(IGqlpSelection? result)
    => result.ShouldBeNull();
}
