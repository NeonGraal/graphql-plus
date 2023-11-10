using GqlPlus.Verifier.Ast.Operation;

namespace GqlPlus.Verifier.Parse.Operation;

public class ParseDirectivesTests
{
  [Theory, RepeatData(Repeats)]
  public void WithMinimum_ReturnsCorrectAst(string directives)
    => Test.TrueExpected(
      "@" + directives,
      new DirectiveAst(AstNulls.At, directives));

  [Theory, RepeatData(Repeats)]
  public void WithArgument_ReturnsCorrectAst(string directives, string variable)
    => Test.TrueExpected(
      "@" + directives + "($" + variable + ")",
      new DirectiveAst(AstNulls.At, directives) { Argument = new ArgumentAst(AstNulls.At, variable) });

  [Theory, RepeatData(Repeats)]
  public void WithArgumentBad_ReturnsFalse(string directives)
    => Test.False("@" + directives + "($)");

  [Theory, RepeatData(Repeats)]
  public void WithSecondBad_ReturnsFalse(string directives)
    => Test.False("@" + directives + "@");

  private static ManyChecks<OperationParser, DirectiveAst> Test => new(
    tokens => new OperationParser(tokens),
    parser => parser.ParseDirectives());
}
