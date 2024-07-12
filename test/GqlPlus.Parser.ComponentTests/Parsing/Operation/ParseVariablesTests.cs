using GqlPlus.Abstractions.Operation;
using GqlPlus.Ast.Operation;

namespace GqlPlus.Parsing.Operation;

public class ParseVariablesTests(
  IManyChecksParser<IGqlpVariable> checks
)
{
  private static VariableAst TestVar(string variable)
    => new(AstNulls.At, variable);

  [Theory, RepeatData(Repeats)]
  public void WithMinimum_ReturnsCorrectAst(string[] variables)
    => checks.TrueExpected(
      "(" + variables.Joined(v => "$" + v) + ")",
      [.. variables.Select(TestVar)]);

  [Fact]
  public void WithNoVariables_ReturnsFalse()
    => checks.FalseExpected("()");

  [Theory, RepeatData(Repeats)]
  public void WithNoEnd_ReturnsFalse(string variable)
    => checks.FalseExpected("($" + variable);
}
