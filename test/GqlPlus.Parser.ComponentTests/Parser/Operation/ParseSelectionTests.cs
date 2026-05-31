using GqlPlus.Ast.Operation;

namespace GqlPlus.Parser.Operation;

public class ParseSelectionTests(
  IOneChecksParser<IAstSelection> checks
)
{
  [Theory]
  [RepeatInlineData("...")]
  [RepeatInlineData("|")]
  public void WithInline_ReturnsCorrectAst(string prefix, string[] fields)
    => checks.ThrowIfNull().TrueExpected(
      prefix + " {" + fields.ThrowIfNull().Joined() + "}",
      new InlineAst(AstNulls.At, fields.ThrowIfNull().Fields()));

  [Theory]
  [RepeatInlineData("...", " on ")]
  [RepeatInlineData("|", " on ")]
  [RepeatInlineData("...", ":")]
  [RepeatInlineData("|", ":")]
  public void WithInlineType_ReturnsCorrectAst(string inlinePrefix, string typePrefix, string[] fields, string inlineType)
    => checks.ThrowIfNull().TrueExpected(
      inlinePrefix + typePrefix + inlineType + "{" + fields.ThrowIfNull().Joined() + "}",
      new InlineAst(AstNulls.At, fields.ThrowIfNull().Fields()) { OnType = inlineType });

  [Theory, RepeatData]
  public void WithInlineDirective_ReturnsCorrectAst(string[] directives, string[] fields)
    => checks.ThrowIfNull().TrueExpected(
      "|" + directives.ThrowIfNull().Joined(s => "@" + s) + "{" + fields.ThrowIfNull().Joined() + "}",
      new InlineAst(AstNulls.At, fields.ThrowIfNull().Fields()) { Directives = directives.ThrowIfNull().Directives() });

  [Theory, RepeatData]
  public void WithInlineAll_ReturnsCorrectAst(string inlineType, string[] directives, string[] fields)
    => checks.ThrowIfNull().TrueExpected(
      $"|:" + inlineType + directives.ThrowIfNull().Joined(s => "@" + s) + "{" + fields.ThrowIfNull().Joined() + "}",
      new InlineAst(AstNulls.At, fields.ThrowIfNull().Fields()) {
        OnType = inlineType,
        Directives = directives.ThrowIfNull().Directives(),
      });

  [Theory]
  [RepeatInlineData("...")]
  [RepeatInlineData("|")]
  public void WithSpread_ReturnsCorrectAst(string prefix, string fragment)
    => checks.ThrowIfNull()
      .SkipWhitespace(fragment)
      .SkipIf(fragment.ThrowIfNull().StartsWith("on", StringComparison.OrdinalIgnoreCase))
      .TrueExpected(
        prefix + fragment,
        new SpreadAst(AstNulls.At, fragment));

  [Theory, RepeatData]
  public void WithSpreadDirective_ReturnsCorrectAst(string fragment, string[] directives)
    => checks.ThrowIfNull()
      .SkipWhitespace(fragment)
      .SkipIf(fragment.ThrowIfNull().StartsWith("on", StringComparison.OrdinalIgnoreCase))
      .TrueExpected(
        $"|" + fragment + directives.ThrowIfNull().Joined(s => "@" + s),
        new SpreadAst(AstNulls.At, fragment) { Directives = directives.ThrowIfNull().Directives() });

  [Theory, RepeatData]
  public void WithSpreadModifier_ReturnsCorrectAst(string fragment)
    => checks.ThrowIfNull()
      .SkipWhitespace(fragment)
      .SkipIf(fragment.ThrowIfNull().StartsWith("on", StringComparison.OrdinalIgnoreCase))
      .TrueExpected(
        $"|" + fragment + "[]?",
        new SpreadAst(AstNulls.At, fragment) { Modifiers = TestMods() });

  [Theory, RepeatData]
  public void WithInlineModifier_ReturnsCorrectAst(string[] fields)
    => checks.ThrowIfNull().TrueExpected(
      "|[]?{" + fields.ThrowIfNull().Joined() + "}",
      new InlineAst(AstNulls.At, fields.ThrowIfNull().Fields()) { Modifiers = TestMods() });

  [Fact]
  public void WithInvalidSelection_ReturnsFalse()
    => checks.ThrowIfNull().FalseExpected("|?", CheckNull);

  [Fact]
  public void WithInvalidSpread_ReturnsFalse()
    => checks.ThrowIfNull().FalseExpected("|:?", CheckNull);

  private void CheckNull(IAstSelection? result)
    => result.ThrowIfNull().ShouldBeNull();
}
