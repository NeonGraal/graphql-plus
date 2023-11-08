using GqlPlus.Verifier.Ast.Operation;

namespace GqlPlus.Verifier.Parse.Operation;

public class ParseVariableTests
{
  private static VariableAst TestVar(string variable)
    => new(AstNulls.At, variable);

  [Theory, RepeatData(Repeats)]
  public void WithMinimum_ReturnsCorrectAst(string variable)
    => Test.TrueExpected("$" + variable,
      TestVar(variable));

  [Theory, RepeatData(Repeats)]
  public void WithType_ReturnsCorrectAst(string variable, string varType)
    => Test.TrueExpected($"${variable}:{varType}",
      TestVar(variable) with { Type = varType });

  [Theory, RepeatData(Repeats)]
  public void WithGraphQlNotNull_ReturnsCorrectAst(string variable, string varType)
    => Test.TrueExpected($"${variable}:{varType}!",
      TestVar(variable) with { Type = varType + "!" });

  [Theory, RepeatData(Repeats)]
  public void WithGraphQlList_ReturnsCorrectAst(string variable, string varType)
    => Test.TrueExpected($"${variable}:[{varType}]",
      TestVar(variable) with { Type = "[" + varType + "]" });

  [Theory, RepeatData(Repeats)]
  public void WithGraphQlComplex_ReturnsCorrectAst(string variable, string varType)
    => Test.TrueExpected($"${variable}:[[{varType}]!]!",
      TestVar(variable) with { Type = "[[" + varType + "]!]!" });

  [Theory, RepeatData(Repeats)]
  public void WithModifiers_ReturnsCorrectAst(string variable)
    => Test.TrueExpected($"${variable}[]?",
      TestVar(variable) with { Modifers = TestMods() });

  [Theory, RepeatData(Repeats)]
  public void WithModifiersBad_ReturnsFalse(string variable)
    => Test.False($"${variable}[?]");

  [Theory, RepeatData(Repeats)]
  public void WithDefault_ReturnsCorrectAst(string variable, decimal number)
    => Test.TrueExpected($"${variable}={number}",
      TestVar(variable) with { Default = new FieldKeyAst(AstNulls.At, number) });

  [Theory, RepeatData(Repeats)]
  public void WithDefaultBad_ReturnsFalse(string variable)
    => Test.False($"${variable}=");

  [Theory, RepeatData(Repeats)]
  public void WithDirective_ReturnsCorrectAst(string variable, string[] directives)
    => Test.TrueExpected($"${variable}{directives.Joined("@")}",
      TestVar(variable) with { Directives = directives.Directives() });

  [Theory, RepeatData(Repeats)]
  public void WithDirectiveBad_ReturnsFalse(string variable)
    => Test.False($"${variable}@");

  [Theory, RepeatData(Repeats)]
  public void WithAll_ReturnsCorrectAst(string variable, string varType, decimal number, string[] directives)
    => Test.TrueExpected($"${variable}:{varType}[]?={number}{directives.Joined("@")}",
      TestVar(variable) with {
        Type = varType,
        Modifers = TestMods(),
        Default = new FieldKeyAst(AstNulls.At, number),
        Directives = directives.Directives()
      });

  private static OneChecks<OperationParser, VariableAst> Test => new(
    tokens => new OperationParser(tokens),
    parser => parser.ParseVariable());
}
