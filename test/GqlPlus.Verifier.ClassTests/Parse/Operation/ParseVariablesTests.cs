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

  private ManyChecks<VariableAst> Test;

  public ParseVariablesTests(IParserArray<VariableAst> parser)
    => Test = new(parser);
}
