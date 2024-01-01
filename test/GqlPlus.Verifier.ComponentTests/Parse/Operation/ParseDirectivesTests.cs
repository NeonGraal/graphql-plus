using GqlPlus.Verifier.Ast.Operation;

namespace GqlPlus.Verifier.Parse.Operation;

public class ParseDirectivesTests(Parser<DirectiveAst>.DA parser)
{
  [Theory, RepeatData(Repeats)]
  public void WithMinimum_ReturnsCorrectAst(string directives)
    => _checks.TrueExpected(
      "@" + directives,
      new DirectiveAst(AstNulls.At, directives));

  [Theory, RepeatData(Repeats)]
  public void WithArgument_ReturnsCorrectAst(string directives, string variable)
    => _checks.TrueExpected(
      "@" + directives + "($" + variable + ")",
      new DirectiveAst(AstNulls.At, directives) { Argument = new ArgumentAst(AstNulls.At, variable) });

  [Theory, RepeatData(Repeats)]
  public void WithArgumentBad_ReturnsFalse(string directives)
    => _checks.False("@" + directives + "($)");

  [Theory, RepeatData(Repeats)]
  public void WithSecondBad_ReturnsFalse(string directives)
    => _checks.False("@" + directives + "@");

  private readonly ManyChecksParser<DirectiveAst> _checks = new(parser);
}
