namespace GqlPlus.Ast.Operation;

public class VariableAstTests
  : AstDirectivesBaseTests
{
  [Theory, RepeatData]
  public void HashCode_WithType(string name, string varType)
    => _checks.HashCode(() => new VariableAst(AstNulls.At, name) { Type = varType });

  [Theory, RepeatData]
  public void HashCode_WithModifiers(string name)
    => _checks.HashCode(() => new VariableAst(AstNulls.At, name) { Modifiers = TestMods() });

  [Theory, RepeatData]
  public void HashCode_WithDefault(string name, string value)
    => _checks.HashCode(() => new VariableAst(AstNulls.At, name) { DefaultValue = new ConstantAst(new FieldKeyAst(AstNulls.At, value)) });

  [Theory, RepeatData]
  public void Text_WithType(string name, string varType)
    => _checks.Text(
      () => new VariableAst(AstNulls.At, name) { Type = varType },
      $"( !v {name} :{varType} )");

  [Theory, RepeatData]
  public void Text_WithModifiers(string name)
    => _checks.Text(
      () => new VariableAst(AstNulls.At, name) { Modifiers = TestMods() },
      $"( !v {name} [] ? )");

  [Theory, RepeatData]
  public void Text_WithDefault(string name, string value)
    => _checks.Text(
      () => new VariableAst(AstNulls.At, name) { DefaultValue = new ConstantAst(new FieldKeyAst(AstNulls.At, value)) },
      $"( !v {name} =( !k '{value}' ) )");

  [Theory, RepeatData]
  public void Equality_WithType(string name, string varType)
    => _checks.Equality(() => new VariableAst(AstNulls.At, name) { Type = varType });

  [Theory, RepeatData]
  public void Inequality_BetweenType(string name, string varType1, string varType2)
    => _checks.InequalityBetween(varType1, varType2,
      varType => new VariableAst(AstNulls.At, name) { Type = varType },
      varType1 == varType2);

  [Theory, RepeatData]
  public void Inequality_WithType(string name, string varType)
    => _checks.InequalityWith(name,
      () => new VariableAst(AstNulls.At, name) { Type = varType });

  [Theory, RepeatData]
  public void Equality_WithModifiers(string name)
    => _checks.Equality(() => new VariableAst(AstNulls.At, name) { Modifiers = TestMods() });

  [Theory, RepeatData]
  public void Inequality_WithModifiers(string name)
    => _checks.InequalityWith(name, () => new VariableAst(AstNulls.At, name) { Modifiers = TestMods() });

  [Theory, RepeatData]
  public void Equality_WithDefault(string name, string value)
    => _checks.Equality(() => new VariableAst(AstNulls.At, name) { DefaultValue = new ConstantAst(new FieldKeyAst(AstNulls.At, value)) });

  [Theory, RepeatData]
  public void Inequality_BetweenDefault(string name, string value1, string value2)
    => _checks.InequalityBetween(value1, value2,
      value => new VariableAst(AstNulls.At, name) { DefaultValue = new ConstantAst(new FieldKeyAst(AstNulls.At, value)) },
      value1 == value2);

  [Theory, RepeatData]
  public void Inequality_WithDefault(string name, string value)
    => _checks.InequalityWith(name,
      () => new VariableAst(AstNulls.At, name) { DefaultValue = new ConstantAst(new FieldKeyAst(AstNulls.At, value)) });

  internal AstDirectivesChecks<VariableAst> _checks = new(CreateVariable, CloneVariable);

  private static VariableAst CloneVariable(VariableAst original, string input)
    => original with { Identifier = input };
  private static VariableAst CreateVariable(string input, string[] directives)
    => new(AstNulls.At, input) { Directives = directives.Directives() };

  internal override IAstDirectivesChecks DirectivesChecks => _checks;
}
