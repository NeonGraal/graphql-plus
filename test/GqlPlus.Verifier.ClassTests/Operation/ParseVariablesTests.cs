using GqlPlus.Verifier.Ast;

namespace GqlPlus.Verifier.Operation;

public class ParseVariablesTests
{
  [Theory, RepeatData(Repeats)]
  public void WithMinimum_ReturnsCorrectAst(string variable)
    => Test.TrueExpected($"(${variable})",
      new VariableAst(variable));

  [Theory, RepeatData(Repeats)]
  public void WithType_ReturnsCorrectAst(string variable, string varType)
    => Test.TrueExpected($"(${variable}:{varType})",
      new VariableAst(variable) { Type = varType });

  [Theory, RepeatData(Repeats)]
  public void WithModifiers_ReturnsCorrectAst(string variable)
    => Test.TrueExpected($"(${variable}[]?)",
    new VariableAst(variable) { Modifers = TestMods() });

  [Theory, RepeatData(Repeats)]
  public void WithDefault_ReturnsCorrectAst(string variable, decimal number)
    => Test.TrueExpected($"(${variable}={number})",
      new VariableAst(variable) { Default = new FieldKeyAst(number) });

  [Theory, RepeatData(Repeats)]
  public void WithDirective_ReturnsCorrectAst(string variable, string directive)
    => Test.TrueExpected($"(${variable}@{directive})",
      new VariableAst(variable) { Directives = directive.Directives() });

  [Theory, RepeatData(Repeats)]
  public void WithAll_ReturnsCorrectAst(string variable, string varType, decimal number, string directive)
    => Test.TrueExpected($"(${variable}:{varType}[]?={number}@{directive})",
      new VariableAst(variable) {
        Type = varType,
        Modifers = TestMods(),
        Default = new FieldKeyAst(number),
        Directives = directive.Directives()
      });

  [Fact]
  public void WithNoVariables_ReturnsFalse()
    => Test.False("()");

  [Fact]
  public void WithNoEnd_ReturnsFalse()
    => Test.False("(test");

  private static BaseManyChecks<VariableAst> Test => new((ref OperationParser parser, out VariableAst[] result)
    => parser.ParseVariables(out result));
}
