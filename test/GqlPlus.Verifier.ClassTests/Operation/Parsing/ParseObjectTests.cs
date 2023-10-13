using GqlPlus.Verifier.Ast;

namespace GqlPlus.Verifier.Operation.Parsing;

public class ParseObjectTests
{
  [Theory, RepeatData(Repeats)]
  public void WithJustField_ReturnsCorrectAst(string field)
    => Test.TrueExpected("{" + field + "}",
    new FieldAst(field));

  [Theory, RepeatData(Repeats)]
  public void WithJustInline_ReturnsCorrectAst(string inline)
    => Test.TrueExpected("{|{" + inline + "}}",
      new InlineAst(new FieldAst(inline)));

  [Theory, RepeatData(Repeats)]
  public void WithJustSpread_ReturnsCorrectAst(string spread)
    => Test.TrueExpected("{|" + spread + "}",
      new SpreadAst(spread));

  [Theory, RepeatData(Repeats)]
  public void WithAll_ReturnsCorrectAst(string field, string inline, string spread)
    => Test.TrueExpected("{" + field + "|{" + inline + "}|" + spread + "}",
          new FieldAst(field),
          new InlineAst(new FieldAst(inline)),
          new SpreadAst(spread));

  [Fact]
  public void WithNoFields_ReturnsFalse()
    => Test.False("{}");

  [Fact]
  public void WithNotField_ReturnsFalse()
    => Test.False("{9");

  private static BaseManyChecks<AstSelection> Test => new((ref OperationParser parser, out AstSelection[] result)
    => parser.ParseObject(out result));
}
