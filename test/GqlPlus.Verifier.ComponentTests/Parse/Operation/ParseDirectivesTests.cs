using GqlPlus.Verifier.Ast.Operation;

namespace GqlPlus.Verifier.Parse.Operation;

public class ParseDirectivesTests
{
  [Theory, RepeatData(Repeats)]
  public void WithMinimum_ReturnsCorrectAst(string directives)
    => _test.TrueExpected(
      "@" + directives,
      new DirectiveAst(AstNulls.At, directives));

  [Theory, RepeatData(Repeats)]
  public void WithArgument_ReturnsCorrectAst(string directives, string variable)
    => _test.TrueExpected(
      "@" + directives + "($" + variable + ")",
      new DirectiveAst(AstNulls.At, directives) { Argument = new ArgumentAst(AstNulls.At, variable) });

  [Theory, RepeatData(Repeats)]
  public void WithArgumentBad_ReturnsFalse(string directives)
    => _test.False("@" + directives + "($)");

  [Theory, RepeatData(Repeats)]
  public void WithSecondBad_ReturnsFalse(string directives)
    => _test.False("@" + directives + "@");

  private readonly ManyChecksParser<DirectiveAst> _test;

  public ParseDirectivesTests(Parser<DirectiveAst>.DA parser)
    => _test = new(parser);
}
