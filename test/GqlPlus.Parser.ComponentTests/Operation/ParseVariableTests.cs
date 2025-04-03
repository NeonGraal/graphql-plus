using GqlPlus.Abstractions.Operation;
using GqlPlus.Ast.Operation;

namespace GqlPlus.Operation;

public class ParseVariableTests(
  IOneChecksParser<IGqlpVariable> checks
)
{
  [Theory, RepeatData]
  public void WithMinimum_ReturnsCorrectAst(string variable)
    => checks.TrueExpected("$" + variable,
      TestVar(variable));

  [Theory, RepeatData]
  public void WithType_ReturnsCorrectAst(string variable, string varType)
    => checks.TrueExpected($"${variable}:{varType}",
      TestVar(variable) with { Type = varType });

  [Theory, RepeatData]
  public void WithGraphQlNotNull_ReturnsCorrectAst(string variable, string varType)
    => checks.TrueExpected($"${variable}:{varType}!",
      TestVar(variable) with { Type = varType + "!" });

  [Theory, RepeatData]
  public void WithGraphQlList_ReturnsCorrectAst(string variable, string varType)
    => checks.TrueExpected($"${variable}:[{varType}]",
      TestVar(variable) with { Type = "[" + varType + "]" });

  [Theory, RepeatData]
  public void WithGraphQlComplex_ReturnsCorrectAst(string variable, string varType)
    => checks.TrueExpected($"${variable}:[[{varType}]!]!",
      TestVar(variable) with { Type = "[[" + varType + "]!]!" });

  [Theory, RepeatData]
  public void WithModifiers_ReturnsCorrectAst(string variable)
    => checks.TrueExpected($"${variable}[]?",
      TestVar(variable) with { Modifiers = TestMods() });

  [Theory, RepeatData]
  public void WithModifiersBad_ReturnsFalse(string variable)
    => checks.FalseExpected($"${variable}[?]");

  [Theory, RepeatData]
  public void WithDefault_ReturnsCorrectAst(string variable, decimal number)
    => checks.TrueExpected($"${variable}={number}",
      TestVar(variable) with { DefaultValue = new(new FieldKeyAst(AstNulls.At, number)) });

  [Theory, RepeatData]
  public void WithDefaultBad_ReturnsFalse(string variable)
    => checks.FalseExpected($"${variable}=");

  [Theory, RepeatData]
  public void WithDirective_ReturnsCorrectAst(string variable, string[] directives)
    => checks.TrueExpected($"${variable}{directives.Joined(s => "@" + s)}",
      TestVar(variable) with { Directives = directives.Directives() });

  [Theory, RepeatData]
  public void WithDirectiveBad_ReturnsFalse(string variable)
    => checks.FalseExpected($"${variable}@");

  [Theory, RepeatData]
  public void WithAll_ReturnsCorrectAst(string variable, string varType, decimal number, string[] directives)
    => checks.TrueExpected($"${variable}:{varType}[]?={number}{directives.Joined(s => "@" + s)}",
      TestVar(variable) with {
        Type = varType,
        Modifiers = TestMods(),
        DefaultValue = new(new FieldKeyAst(AstNulls.At, number)),
        Directives = directives.Directives()
      });

  private static VariableAst TestVar(string variable)
    => new(AstNulls.At, variable);
}
