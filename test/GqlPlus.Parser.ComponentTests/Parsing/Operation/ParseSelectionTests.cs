using GqlPlus.Abstractions.Operation;
using GqlPlus.Ast.Operation;

namespace GqlPlus.Parsing.Operation;

public class ParseSelectionTests(Parser<IGqlpSelection>.D parser)
{
  [Theory, RepeatInlineData(Repeats, "..."), RepeatInlineData(Repeats, "|")]
  public void WithInline_ReturnsCorrectAst(string prefix, string[] fields)
    => _checks.TrueExpected(
      prefix + " {" + fields.Joined() + "}",
      new InlineAst(AstNulls.At, fields.Fields()));

  [Theory]
  [RepeatInlineData(Repeats, "...", " on ")]
  [RepeatInlineData(Repeats, "|", " on ")]
  [RepeatInlineData(Repeats, "...", ":")]
  [RepeatInlineData(Repeats, "|", ":")]
  public void WithInlineType_ReturnsCorrectAst(string inlinePrefix, string typePrefix, string[] fields, string inlineType)
    => _checks.TrueExpected(
      inlinePrefix + typePrefix + inlineType + "{" + fields.Joined() + "}",
      new InlineAst(AstNulls.At, fields.Fields()) { OnType = inlineType });

  [Theory, RepeatData(Repeats)]
  public void WithInlineDirective_ReturnsCorrectAst(string[] directives, string[] fields)
    => _checks.TrueExpected(
      "|" + directives.Joined(s => "@" + s) + "{" + fields.Joined() + "}",
      new InlineAst(AstNulls.At, fields.Fields()) { Directives = directives.Directives() });

  [Theory, RepeatData(Repeats)]
  public void WithInlineAll_ReturnsCorrectAst(string inlineType, string[] directives, string[] fields)
    => _checks.TrueExpected(
      $"|:" + inlineType + directives.Joined(s => "@" + s) + "{" + fields.Joined() + "}",
      new InlineAst(AstNulls.At, fields.Fields()) {
        OnType = inlineType,
        Directives = directives.Directives(),
      });

  [SkippableTheory, RepeatInlineData(Repeats, "..."), RepeatInlineData(Repeats, "|")]
  public void WithSpread_ReturnsCorrectAst(string prefix, string fragment)
    => _checks.TrueExpected(
      prefix + fragment,
      new SpreadAst(AstNulls.At, fragment),
      fragment is null || fragment.StartsWith("on", StringComparison.OrdinalIgnoreCase));

  [SkippableTheory, RepeatData(Repeats)]
  public void WithSpreadDirective_ReturnsCorrectAst(string fragment, string[] directives)
    => _checks.TrueExpected(
      $"|" + fragment + directives.Joined(s => "@" + s),
      new SpreadAst(AstNulls.At, fragment) { Directives = directives.Directives() },
      fragment is null || fragment.StartsWith("on", StringComparison.OrdinalIgnoreCase));

  [Fact]
  public void WithInvalidSelection_ReturnsFalse()
    => _checks.False("|?", CheckNull);

  [Fact]
  public void WithInvalidSpread_ReturnsFalse()
    => _checks.False("|:?", CheckNull);

  private void CheckNull(IGqlpSelection? result)
    => result.Should().BeNull();

  private readonly OneChecksParser<IGqlpSelection> _checks = new(parser);
}
