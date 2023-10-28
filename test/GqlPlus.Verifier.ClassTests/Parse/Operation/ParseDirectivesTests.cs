using GqlPlus.Verifier.Ast.Operation;

namespace GqlPlus.Verifier.Parse.Operation;

public class ParseDirectivesTests
{
  [Theory, RepeatData(Repeats)]
  public void WithMinimum_ReturnsCorrectAst(string directives)
    => Test.Expected(
      "@" + directives,
      new DirectiveAst(AstNulls.At, directives));

  [Theory, RepeatData(Repeats)]
  public void WithArgument_ReturnsCorrectAst(string directives, string variable)
    => Test.Expected(
      "@" + directives + "($" + variable + ")",
      new DirectiveAst(AstNulls.At, directives) { Argument = new ArgumentAst(AstNulls.At, variable) });

  private static ArrayChecks<OperationParser, DirectiveAst> Test => new(
    tokens => new OperationParser(tokens),
    parser => parser.ParseDirectives());
}
