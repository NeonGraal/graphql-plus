using GqlPlus.Verifier.Ast.Operation;

namespace GqlPlus.Verifier.Parse.Operation;

public class ParseVariablesTests
{
  private static VariableAst TestVar(string variable)
    => new(AstNulls.At, variable);

  [Theory, RepeatData(Repeats)]
  public void WithMinimum_ReturnsCorrectAst(string[] variables)
    => Test.TrueExpected("(" + variables.Joined(v => "$" + v) + ")",
      variables.Select(TestVar).ToArray());

  [Fact]
  public void WithNoVariables_ReturnsFalse()
    => Test.False("()");

  [Theory, RepeatData(Repeats)]
  public void WithNoEnd_ReturnsFalse(string variable)
    => Test.False("($" + variable);

  private static ManyChecks<OperationParser, VariableAst> Test => new(
    tokens => new OperationParser(tokens),
    (OperationParser parser, out VariableAst[] result) => parser.ParseVariables().Required(out result));
}
