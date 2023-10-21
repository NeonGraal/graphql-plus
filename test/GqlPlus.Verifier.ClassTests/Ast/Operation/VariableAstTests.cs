namespace GqlPlus.Verifier.Ast.Operation;

public class VariableAstTests : BaseNamedDirectivesAstTests
{
  [Theory, RepeatData(Repeats)]
  public void HashCode_WithType(string name, string varType)
    => _checks.HashCode(() => new(AstNulls.At, name) { Type = varType });

  [Theory, RepeatData(Repeats)]
  public void HashCode_WithModifiers(string name)
    => _checks.HashCode(() => new(AstNulls.At, name) { Modifers = TestMods() });

  [Theory, RepeatData(Repeats)]
  public void HashCode_WithDefault(string name, string value)
    => _checks.HashCode(() => new(AstNulls.At, name) { Default = new FieldKeyAst(AstNulls.At, value) });

  [Theory, RepeatData(Repeats)]
  public void String_WithType(string name, string varType)
    => _checks.String(
      () => new(AstNulls.At, name) { Type = varType },
      $"( !V {name} :{varType} )");

  [Theory, RepeatData(Repeats)]
  public void String_WithModifiers(string name)
    => _checks.String(
      () => new(AstNulls.At, name) { Modifers = TestMods() },
      $"( !V {name} [] ? )");

  [Theory, RepeatData(Repeats)]
  public void String_WithDefault(string name, string value)
    => _checks.String(
      () => new(AstNulls.At, name) { Default = new FieldKeyAst(AstNulls.At, value) },
      $"( !V {name} =( !K '{value}' ) )");

  [Theory, RepeatData(Repeats)]
  public void Equality_WithType(string name, string varType)
    => _checks.Equality(() => new VariableAst(AstNulls.At, name) { Type = varType });

  [Theory, RepeatData(Repeats)]
  public void Inequality_BetweenType(string name, string varType1, string varType2)
    => _checks.InequalityBetween(varType1, varType2,
      varType => new VariableAst(AstNulls.At, name) { Type = varType },
      varType1 == varType2);

  [Theory, RepeatData(Repeats)]
  public void Inequality_WithType(string name, string varType)
    => _checks.InequalityWith(name,
      () => new VariableAst(AstNulls.At, name) { Type = varType });

  [Theory, RepeatData(Repeats)]
  public void Equality_WithModifiers(string name)
    => _checks.Equality(() => new VariableAst(AstNulls.At, name) { Modifers = TestMods() });

  [Theory, RepeatData(Repeats)]
  public void Inequality_WithModifiers(string name)
    => _checks.InequalityWith(name, () => new VariableAst(AstNulls.At, name) { Modifers = TestMods() });

  [Theory, RepeatData(Repeats)]
  public void Equality_WithDefault(string name, string value)
    => _checks.Equality(() => new VariableAst(AstNulls.At, name) { Default = new FieldKeyAst(AstNulls.At, value) });

  [Theory, RepeatData(Repeats)]
  public void Inequality_BetweenDefault(string name, string value1, string value2)
    => _checks.InequalityBetween(value1, value2,
      value => new VariableAst(AstNulls.At, name) { Default = new FieldKeyAst(AstNulls.At, value) },
      value1 == value2);

  [Theory, RepeatData(Repeats)]
  public void Inequality_WithDefault(string name, string value)
    => _checks.InequalityWith(name,
      () => new VariableAst(AstNulls.At, name) { Default = new FieldKeyAst(AstNulls.At, value) });

  internal BaseNamedDirectivesAstChecks<VariableAst> _checks
    = new(name => new VariableAst(AstNulls.At, name));

  internal override IBaseNamedDirectivesAstChecks DirectivesChecks => _checks;
}
