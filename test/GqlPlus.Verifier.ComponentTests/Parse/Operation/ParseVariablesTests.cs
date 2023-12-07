using GqlPlus.Verifier.Ast.Operation;

namespace GqlPlus.Verifier.Parse.Operation;

public class ParseVariablesTests
{
  private static VariableAst TestVar(string variable)
    => new(AstNulls.At, variable);

  [Theory, RepeatData(Repeats)]
  public void WithMinimum_ReturnsCorrectAst(string[] variables)
    => _test.TrueExpected("(" + variables.Joined(v => "$" + v) + ")",
      variables.Select(TestVar).ToArray());

  [Fact]
  public void WithNoVariables_ReturnsFalse()
    => _test.False("()");

  [Theory, RepeatData(Repeats)]
  public void WithNoEnd_ReturnsFalse(string variable)
    => _test.False("($" + variable);

  private readonly ManyChecksParser<VariableAst> _test;

  public ParseVariablesTests(Parser<VariableAst>.DA parser)
    => _test = new(parser);
}
