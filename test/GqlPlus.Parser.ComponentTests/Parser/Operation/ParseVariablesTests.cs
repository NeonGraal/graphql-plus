using GqlPlus.Ast.Operation;

namespace GqlPlus.Parser.Operation;

public class ParseVariablesTests(ComponentFixture<OperationParserTestServices> fixture)
  : IClassFixture<ComponentFixture<OperationParserTestServices>>
{
  private readonly IManyChecksParser<IAstVariable> checks = fixture.GetService<IManyChecksParser<IAstVariable>>();

  private static VariableAst TestVar(string variable)
    => new(AstNulls.At, variable);

  [Theory, RepeatData]
  public void WithMinimum_ReturnsCorrectAst(string[] variables)
    => checks.TrueExpected(
      "(" + variables.Joined(v => "$" + v) + ")",
      [.. variables.Select(TestVar)]);

  [Fact]
  public void WithNoVariables_ReturnsFalse()
    => checks.FalseExpected("()");

  [Theory, RepeatData]
  public void WithNoEnd_ReturnsFalse(string variable)
    => checks.FalseExpected("($" + variable);
}
