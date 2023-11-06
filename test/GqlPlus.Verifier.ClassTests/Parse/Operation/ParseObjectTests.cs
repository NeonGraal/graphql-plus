using GqlPlus.Verifier.Ast.Operation;

namespace GqlPlus.Verifier.Parse.Operation;

public class ParseObjectTests
{
  [Theory, RepeatData(Repeats)]
  public void WithJustField_ReturnsCorrectAst(string field)
    => Test.TrueExpected("{" + field + "}",
    new FieldAst(AstNulls.At, field));

  [Theory, RepeatData(Repeats)]
  public void WithJustInline_ReturnsCorrectAst(string inline)
    => Test.TrueExpected("{|{" + inline + "}}",
      new InlineAst(AstNulls.At, new FieldAst(AstNulls.At, inline)));

  [Theory, RepeatData(Repeats)]
  public void WithJustSpread_ReturnsCorrectAst(string spread)
    => Test.TrueExpected("{|" + spread + "}",
      spread.StartsWith("on", StringComparison.OrdinalIgnoreCase),
      new SpreadAst(AstNulls.At, spread));

  [Theory, RepeatData(Repeats)]
  public void WithAll_ReturnsCorrectAst(string field, string inline, string spread)
    => Test.TrueExpected("{" + field + "|{" + inline + "}|" + spread + "}",
          new FieldAst(AstNulls.At, field),
          new InlineAst(AstNulls.At, new FieldAst(AstNulls.At, inline)),
          new SpreadAst(AstNulls.At, spread));

  [Fact]
  public void WithNoFields_ReturnsFalse()
    => Test.False("{}");

  [Fact]
  public void WithNotField_ReturnsFalse()
    => Test.False("{9");

  private static ManyChecks<OperationParser, IAstSelection> Test => new(
    tokens => new OperationParser(tokens),
    parser => parser.ParseObject());
}
