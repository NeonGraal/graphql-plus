using GqlPlus.Abstractions.Operation;
using GqlPlus.Ast.Operation;

namespace GqlPlus.Parsing.Operation;

public class ParseVariablesTests(Parser<IGqlpVariable>.DA parser)
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

  private readonly ManyChecksParser<IGqlpVariable> _checks = new(parser);
}
