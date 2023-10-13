using GqlPlus.Verifier.Ast;

namespace GqlPlus.Verifier.Operation.Parsing;

public class ParseDirectivesTests
{
  [Theory, RepeatData(Repeats)]
  public void WithMinimum_ReturnsCorrectAst(string directive)
    => Test.Expected(
      "@" + directive,
      new DirectiveAst(directive));

  [Theory, RepeatData(Repeats)]
  public void WithArgument_ReturnsCorrectAst(string directive, string variable)
    => Test.Expected(
      "@" + directive + "($" + variable + ")",
      new DirectiveAst(directive) { Argument = new ArgumentAst(variable) });

  private static BaseArrayChecks<DirectiveAst> Test => new((ref OperationParser parser)
    => parser.ParseDirectives());
}
