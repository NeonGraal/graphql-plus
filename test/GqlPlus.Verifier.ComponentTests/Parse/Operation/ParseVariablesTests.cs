using GqlPlus.Verifier.Ast.Operation;

namespace GqlPlus.Verifier.Parse.Operation;

public class ParseVariablesTests(Parser<VariableAst>.DA parser)
{
  private static VariableAst TestVar(string variable)
    => new(AstNulls.At, variable);

  [Theory, RepeatData(Repeats)]
  public void WithMinimum_ReturnsCorrectAst(string[] variables)
    => _checks.TrueExpected(
      "(" + variables.Joined(v => "$" + v) + ")",
      [.. variables.Select(TestVar)]);

  [Fact]
  public void WithNoVariables_ReturnsFalse()
    => _checks.False("()");

  [Theory, RepeatData(Repeats)]
  public void WithNoEnd_ReturnsFalse(string variable)
    => _checks.False("($" + variable);

  private readonly ManyChecksParser<VariableAst> _checks = new(parser);
}
