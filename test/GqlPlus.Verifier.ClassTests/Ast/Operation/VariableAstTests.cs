namespace GqlPlus.Verifier.Ast.Operation;

public class VariableAstTests : AstDirectivesTests
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
    => _checks.Text(
      () => new(AstNulls.At, name) { Type = varType },
      $"( !v {name} :{varType} )");

  [Theory, RepeatData(Repeats)]
  public void String_WithModifiers(string name)
    => _checks.Text(
      () => new(AstNulls.At, name) { Modifers = TestMods() },
      $"( !v {name} [] ? )");

  [Theory, RepeatData(Repeats)]
  public void String_WithDefault(string name, string value)
    => _checks.Text(
      () => new(AstNulls.At, name) { Default = new FieldKeyAst(AstNulls.At, value) },
      $"( !v {name} =( !k '{value}' ) )");

  [Theory, RepeatData(Repeats)]
  public void Equality_WithType(string name, string varType)
    => _checks.Equality(() => new VariableAst(AstNulls.At, name) { Type = varType });

  [SkippableTheory, RepeatData(Repeats)]
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

  [SkippableTheory, RepeatData(Repeats)]
  public void Inequality_BetweenDefault(string name, string value1, string value2)
    => _checks.InequalityBetween(value1, value2,
      value => new VariableAst(AstNulls.At, name) { Default = new FieldKeyAst(AstNulls.At, value) },
      value1 == value2);

  [Theory, RepeatData(Repeats)]
  public void Inequality_WithDefault(string name, string value)
    => _checks.InequalityWith(name,
      () => new VariableAst(AstNulls.At, name) { Default = new FieldKeyAst(AstNulls.At, value) });

  internal AstDirectivesChecks<VariableAst> _checks
    = new(name => new VariableAst(AstNulls.At, name));

  internal override IAstDirectivesChecks DirectivesChecks => _checks;
}
