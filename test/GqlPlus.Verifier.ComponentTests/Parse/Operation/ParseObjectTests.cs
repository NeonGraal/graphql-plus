using GqlPlus.Verifier.Ast.Operation;

namespace GqlPlus.Verifier.Parse.Operation;

public class ParseObjectTests
{
  [Theory, RepeatData(Repeats)]
  public void WithJustField_ReturnsCorrectAst(string field)
    => _test.TrueExpected("{" + field + "}",
    new FieldAst(AstNulls.At, field));

  [Theory, RepeatData(Repeats)]
  public void WithBadField_ReturnsCorrectAst(string field)
    => _test.False("{" + field + "{}}");

  [Theory, RepeatData(Repeats)]
  public void WithJustInline_ReturnsCorrectAst(string inline)
    => _test.TrueExpected("{|{" + inline + "}}",
      new InlineAst(AstNulls.At, new FieldAst(AstNulls.At, inline)));

  [Theory, RepeatData(Repeats)]
  public void WithJustSpread_ReturnsCorrectAst(string spread)
    => _test.TrueExpected("{|" + spread + "}",
      spread.StartsWith("on", StringComparison.OrdinalIgnoreCase),
      new SpreadAst(AstNulls.At, spread));

  [Theory, RepeatData(Repeats)]
  public void WithAll_ReturnsCorrectAst(string field, string inline, string spread)
    => _test.TrueExpected("{" + field + "|{" + inline + "}|" + spread + "}",
          spread.StartsWith("on", StringComparison.OrdinalIgnoreCase),
          new FieldAst(AstNulls.At, field),
          new InlineAst(AstNulls.At, new FieldAst(AstNulls.At, inline)),
          new SpreadAst(AstNulls.At, spread));

  [Fact]
  public void WithNoFields_ReturnsFalse()
    => _test.False("{}");

  [Fact]
  public void WithNotField_ReturnsFalse()
    => _test.False("{9");

  [Fact]
  public void WithBadSelection_ReturnsFalse()
    => _test.False("{|}");

  private readonly ManyChecksParser<IAstSelection> _test;

  public ParseObjectTests(Parser<IAstSelection>.DA parser)
    => _test = new(parser);
}
