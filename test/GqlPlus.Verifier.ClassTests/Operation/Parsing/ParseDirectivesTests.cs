using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Common;

namespace GqlPlus.Verifier.Operation.Parsing;

public class ParseDirectivesTests
{
  [Theory, RepeatData(Repeats)]
  public void WithMinimum_ReturnsCorrectAst(string directive)
    => Test.Expected(
      "@" + directive,
      new DirectiveAst(AstNulls.At, directive));

  [Theory, RepeatData(Repeats)]
  public void WithArgument_ReturnsCorrectAst(string directive, string variable)
    => Test.Expected(
      "@" + directive + "($" + variable + ")",
      new DirectiveAst(AstNulls.At, directive) { Argument = new ArgumentAst(AstNulls.At, variable) });

  private static BaseArrayChecks<OperationParser, DirectiveAst> Test => new(
    tokens => new OperationParser(tokens),
    parser => parser.ParseDirectives());
}
