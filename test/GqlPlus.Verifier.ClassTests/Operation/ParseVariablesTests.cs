using GqlPlus.Verifier.Ast;

namespace GqlPlus.Verifier.Operation;

public class ParseVariablesTests
{
  [Theory, RepeatData(Repeats)]
  public void WithMinimum_ReturnsCorrectAst(string variable)
    => ParseVariablesTrueExpected($"(${variable})",
      new VariableAst(variable));

  [Theory, RepeatData(Repeats)]
  public void WithType_ReturnsCorrectAst(string variable, string varType)
    => ParseVariablesTrueExpected($"(${variable}:{varType})",
      new VariableAst(variable) { Type = varType });

  [Theory, RepeatData(Repeats)]
  public void WithModifiers_ReturnsCorrectAst(string variable)
    => ParseVariablesTrueExpected($"(${variable}[]?)",
    new VariableAst(variable) { Modifers = new[] { ModifierAst.List, ModifierAst.Optional } });

  [Theory, RepeatData(Repeats)]
  public void WithConstant_ReturnsCorrectAst(string variable, decimal number)
    => ParseVariablesTrueExpected($"(${variable}={number})",
      new VariableAst(variable) { Default = new FieldKeyAst(number) });

  [Theory, RepeatData(Repeats)]
  public void WithDirective_ReturnsCorrectAst(string variable, string directive)
    => ParseVariablesTrueExpected($"(${variable}@{directive})",
      new VariableAst(variable) { Directives = directive.Directives() });

  private void ParseVariablesTrueExpected(string input, params VariableAst[] expected)
  {
    var parser = new OperationParser(Tokens(input));

    parser.ParseVariables(out VariableAst[] result).Should().BeTrue();

    result.Should().Equal(expected);
  }
}
