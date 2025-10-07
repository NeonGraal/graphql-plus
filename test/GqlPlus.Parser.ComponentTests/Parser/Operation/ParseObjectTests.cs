using GqlPlus.Abstractions.Operation;
using GqlPlus.Ast.Operation;

namespace GqlPlus.Parser.Operation;

public class ParseObjectTests(
  IManyChecksParser<IGqlpSelection> checks
)
{
  [Theory, RepeatData]
  public void WithJustField_ReturnsCorrectAst(string field)
    => checks.TrueExpected("{" + field + "}",
    new FieldAst(AstNulls.At, field));

  [Theory, RepeatData]
  public void WithBadField_ReturnsCorrectAst(string field)
    => checks.FalseExpected("{" + field + "{}}");

  [Theory, RepeatData]
  public void WithJustInline_ReturnsCorrectAst(string inline)
    => checks.TrueExpected("{|{" + inline + "}}",
      new InlineAst(AstNulls.At, new FieldAst(AstNulls.At, inline)));

  [Theory, RepeatData]
  public void WithJustSpread_ReturnsCorrectAst(string spread)
    => checks
      .SkipWhitespace(spread)
      .SkipIf(spread.StartsWith("on", StringComparison.OrdinalIgnoreCase))
      .TrueExpected(
        "{|" + spread + "}",
        new SpreadAst(AstNulls.At, spread ?? ""));

  [Theory, RepeatData]
  public void WithAll_ReturnsCorrectAst(string field, string inline, string spread)
    => checks
      .SkipWhitespace(spread)
      .SkipIf(spread.StartsWith("on", StringComparison.OrdinalIgnoreCase))
      .TrueExpected(
        "{" + field + "|{" + inline + "}|" + spread + "}",
        new FieldAst(AstNulls.At, field),
        new InlineAst(AstNulls.At, new FieldAst(AstNulls.At, inline)),
        new SpreadAst(AstNulls.At, spread ?? ""));

  [Fact]
  public void WithNoFields_ReturnsFalse()
    => checks.FalseExpected("{}");

  [Fact]
  public void WithNotField_ReturnsFalse()
    => checks.FalseExpected("{9");

  [Fact]
  public void WithBadSelection_ReturnsFalse()
    => checks.FalseExpected("{|}");
}
