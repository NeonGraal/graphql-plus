namespace GqlPlus.Ast.Operation;

[CheckTestsFor(nameof(Checks), Inherited = true)]
[CheckTestsFor(nameof(ModifiersChecks))]
[CheckTestsFor(nameof(CloneChecks))]
public partial class VariableAstTests
{
  internal IVariableAstChecks Checks { get; } = new VariableAstChecks();
  internal IModifiersChecks<string> ModifiersChecks { get; } = new VariableModifiersChecks();
  internal ICloneChecks<string> CloneChecks { get; } = new CloneChecks<string, VariableAst>(VariableAstFactory.Create, VariableAstFactory.Clone);
}

internal sealed class VariableAstChecks()
  : AstDirectivesChecks<VariableAst>(CreateVariable)
  , IVariableAstChecks
{
  public void HashCode_WithType(string name, string varType)
    => HashCode(() => new VariableAst(AstNulls.At, name) { Type = varType });

  public void HashCode_WithDefault(string name, string value)
    => HashCode(() => new VariableAst(AstNulls.At, name) { DefaultValue = new ConstantAst(new FieldKeyAst(AstNulls.At, value)) });

  public void Text_WithType(string name, string varType)
    => Text(
      () => new VariableAst(AstNulls.At, name) { Type = varType },
      $"( !v {name} :{varType} )");

  public void Text_WithDefault(string name, string value)
    => Text(
      () => new VariableAst(AstNulls.At, name) { DefaultValue = new ConstantAst(new FieldKeyAst(AstNulls.At, value)) },
      $"( !v {name} =( !k '{value}' ) )");

  public void Equality_WithType(string name, string varType)
    => Equality(() => new VariableAst(AstNulls.At, name) { Type = varType });

  public void Inequality_BetweenType(string name, string varType1, string varType2)
    => InequalityBetween(varType1, varType2,
      varType => new VariableAst(AstNulls.At, name) { Type = varType },
      varType1 == varType2);

  public void Inequality_WithType(string name, string varType)
    => InequalityWith(name,
      () => new VariableAst(AstNulls.At, name) { Type = varType });

  public void Equality_WithDefault(string name, string value)
    => Equality(() => new VariableAst(AstNulls.At, name) { DefaultValue = new ConstantAst(new FieldKeyAst(AstNulls.At, value)) });

  public void Inequality_BetweenDefault(string name, string value1, string value2)
    => InequalityBetween(value1, value2,
      value => new VariableAst(AstNulls.At, name) { DefaultValue = new ConstantAst(new FieldKeyAst(AstNulls.At, value)) },
      value1 == value2);

  public void Inequality_WithDefault(string name, string value)
    => InequalityWith(name,
      () => new VariableAst(AstNulls.At, name) { DefaultValue = new ConstantAst(new FieldKeyAst(AstNulls.At, value)) });

  private static VariableAst CreateVariable(string input, string[] directives)
    => VariableAstFactory.Create(input) with { Directives = directives.Directives() };
}

internal sealed class VariableModifiersChecks()
  : ModifiersChecks<string, VariableAst>(
      VariableAstFactory.Create, ast => ast with { Modifiers = TestMods() })
{
  protected override string InputString(string input)
    => $"( !v {input} )";
}

internal static class VariableAstFactory
{
  internal static VariableAst Clone(VariableAst original, string input)
    => original with { Identifier = input };
  internal static VariableAst Create(string input)
    => new(AstNulls.At, input);
}

internal interface IVariableAstChecks
  : IAstDirectivesChecks
{
  void HashCode_WithType(string name, string varType);
  void HashCode_WithDefault(string name, string value);
  void Text_WithType(string name, string varType);
  void Text_WithDefault(string name, string value);
  void Equality_WithType(string name, string varType);
  void Inequality_BetweenType(string name, string varType1, string varType2);
  void Inequality_WithType(string name, string varType);
  void Equality_WithDefault(string name, string value);
  void Inequality_BetweenDefault(string name, string value1, string value2);
  void Inequality_WithDefault(string name, string value);
}
