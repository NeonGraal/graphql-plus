using GqlPlus.Ast.Operation;

namespace GqlPlus.Parser.Operation;

public class ParseObjectTests(
  IManyChecksParser<IAstSelection> checks
)
{
  [Theory, RepeatData]
  public void WithJustField_ReturnsCorrectAst(string field)
    => checks.ThrowIfNull().TrueExpected("{" + field + "}",
    new FieldAst(AstNulls.At, field));

  [Theory, RepeatData]
  public void WithBadField_ReturnsCorrectAst(string field)
    => checks.ThrowIfNull().FalseExpected("{" + field + "{}}");

  [Theory, RepeatData]
  public void WithJustInline_ReturnsCorrectAst(string inline)
    => checks.ThrowIfNull().TrueExpected("{|{" + inline + "}}",
      new InlineAst(AstNulls.At, new FieldAst(AstNulls.At, inline)));

  [Theory, RepeatData]
  public void WithJustSpread_ReturnsCorrectAst(string spread)
    => checks.ThrowIfNull()
      .SkipWhitespace(spread)
      .SkipIf(spread.ThrowIfNull().StartsWith("on", StringComparison.OrdinalIgnoreCase))
      .TrueExpected(
        "{|" + spread + "}",
        new SpreadAst(AstNulls.At, spread ?? ""));

  [Theory, RepeatData]
  public void WithAll_ReturnsCorrectAst(string field, string inline, string spread)
    => checks.ThrowIfNull()
      .SkipWhitespace(spread)
      .SkipIf(spread.ThrowIfNull().StartsWith("on", StringComparison.OrdinalIgnoreCase))
      .TrueExpected(
        "{" + field + "|{" + inline + "}|" + spread + "}",
        new FieldAst(AstNulls.At, field),
        new InlineAst(AstNulls.At, new FieldAst(AstNulls.At, inline)),
        new SpreadAst(AstNulls.At, spread ?? ""));

  [Fact]
  public void WithNoFields_ReturnsFalse()
    => checks.ThrowIfNull().FalseExpected("{}");

  [Fact]
  public void WithNotField_ReturnsFalse()
    => checks.ThrowIfNull().FalseExpected("{9");

  [Fact]
  public void WithBadSelection_ReturnsFalse()
    => checks.ThrowIfNull().FalseExpected("{|}");
}
