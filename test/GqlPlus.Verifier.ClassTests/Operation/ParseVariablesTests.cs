using GqlPlus.Verifier.Ast;

namespace GqlPlus.Verifier.Operation;

public class ParseVariablesTests
{
  [Theory, RepeatData(Repeats)]
  public void WithMinimumInput_ReturnsCorrectAst(string variable)
  {
    var parser = new OperationParser(Tokens($"(${variable})"));
    var expected = new VariableAst(variable);

    parser.ParseVariables(out VariableAst[] result).Should().BeTrue();

    result.Should().Equal(expected);
  }

  [Theory, RepeatData(Repeats)]
  public void WithType_ReturnsCorrectAst(string variable, string varType)
  {
    var parser = new OperationParser(Tokens($"(${variable}:{varType})"));
    var expected = new VariableAst(variable) { Type = varType };

    parser.ParseVariables(out VariableAst[] result).Should().BeTrue();

    result.Should().Equal(expected);
  }

  [Theory, RepeatData(Repeats)]
  public void WithModifiers_ReturnsCorrectAst(string variable)
  {
    var parser = new OperationParser(Tokens($"(${variable}[]?)"));

    parser.ParseVariables(out VariableAst[] result).Should().BeTrue();

    result.Should()
      .NotBeNull().And
      .Equal(new VariableAst(variable) { Modifers = new[] { ModifierAst.List, ModifierAst.Optional } });
  }

  [Theory, RepeatData(Repeats)]
  public void WithConstant_ReturnsCorrectAst(string variable,
    decimal number)
  {
    var parser = new OperationParser(Tokens($"(${variable}={number})"));
    var expected = new VariableAst(variable) { Default = new ConstantAst(number) };

    parser.ParseVariables(out VariableAst[] result).Should().BeTrue();

    result.Should().Equal(expected);
  }

  [Theory, RepeatData(Repeats)]
  public void WithDirective_ReturnsCorrectAst(string variable, string directive)
  {
    var parser = new OperationParser(Tokens($"(${variable}@{directive})"));
    var expected = new VariableAst(variable) { Directives = directive.Directives() };

    parser.ParseVariables(out VariableAst[] result).Should().BeTrue();

    result.Should().Equal(expected);
  }
}
