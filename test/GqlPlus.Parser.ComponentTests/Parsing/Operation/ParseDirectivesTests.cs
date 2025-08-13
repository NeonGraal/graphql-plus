using GqlPlus.Abstractions.Operation;
using GqlPlus.Ast.Operation;

namespace GqlPlus.Parsing.Operation;

public class ParseDirectivesTests(
  IManyChecksParser<IGqlpDirective> checks
)
{
  [Theory, RepeatData]
  public void WithMinimum_ReturnsCorrectAst(string directives)
    => checks.TrueExpected(
      "@" + directives,
      new DirectiveAst(AstNulls.At, directives));

  [Theory, RepeatData]
  public void WithArg_ReturnsCorrectAst(string directives, string variable)
    => checks.TrueExpected(
      "@" + directives + "($" + variable + ")",
      new DirectiveAst(AstNulls.At, directives) { Arg = new ArgAst(AstNulls.At, variable) });

  [Theory, RepeatData]
  public void WithArgBad_ReturnsFalse(string directives)
    => checks.FalseExpected("@" + directives + "($)");

  [Theory, RepeatData]
  public void WithSecondBad_ReturnsFalse(string directives)
    => checks.FalseExpected("@" + directives + "@");
}
