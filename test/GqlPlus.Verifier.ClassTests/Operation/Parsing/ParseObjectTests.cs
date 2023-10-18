using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Common;

namespace GqlPlus.Verifier.Operation.Parsing;

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

  private static BaseManyChecks<OperationParser, AstSelection> Test => new(
    tokens => new OperationParser(tokens),
    (OperationParser parser, out AstSelection[] result) => parser.ParseObject(out result));
}
