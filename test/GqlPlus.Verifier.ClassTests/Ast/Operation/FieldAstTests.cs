namespace GqlPlus.Verifier.Ast.Operation;

public class FieldAstTests : AstDirectivesTests
{
  [Theory, RepeatData(Repeats)]
  public void HashCode_WithAlias(string name, string alias)
    => _checks.HashCode(
      () => new FieldAst(AstNulls.At, name) { Alias = alias });

  [Theory, RepeatData(Repeats)]
  public void HashCode_WithArgument(string variable, string name)
    => _checks.HashCode(
      () => new FieldAst(AstNulls.At, name) { Argument = new ArgumentAst(AstNulls.At, variable) });

  [Theory, RepeatData(Repeats)]
  public void HashCode_WithModifiers(string name)
    => _checks.HashCode(
      () => new FieldAst(AstNulls.At, name) { Modifiers = TestMods() });

  [Theory, RepeatData(Repeats)]
  public void HashCode_WithSelection(string name, string[] fields)
  => _checks.HashCode(
    () => new FieldAst(AstNulls.At, name) { Selections = fields.Fields() });

  [Theory, RepeatData(Repeats)]
  public void String_WithAlias(string name, string alias)
    => _checks.String(
      () => new FieldAst(AstNulls.At, name) { Alias = alias },
      $"( !f {alias}: {name} )");

  [Theory, RepeatData(Repeats)]
  public void String_WithArgument(string variable, string name)
    => _checks.String(
      () => new FieldAst(AstNulls.At, name) { Argument = new ArgumentAst(AstNulls.At, variable) },
      $"( !f {name} ( !a ${variable} ) )");

  [Theory, RepeatData(Repeats)]
  public void String_WithModifiers(string name)
    => _checks.String(
      () => new FieldAst(AstNulls.At, name) { Modifiers = TestMods() },
      $"( !f {name} []? )");

  [Theory, RepeatData(Repeats)]
  public void String_WithSelection(string name, string[] fields)
  => _checks.String(
      () => new FieldAst(AstNulls.At, name) { Selections = fields.Fields() },
      $"( !f {name} {{ {fields.Joined("!f ")} }} )");

  [Theory, RepeatData(Repeats)]
  public void Equality_WithAlias(string name, string alias)
    => _checks.Equality(
      () => new FieldAst(AstNulls.At, name) { Alias = alias });

  [Theory, RepeatData(Repeats)]
  public void Inequality_WithAlias(string name, string alias)
    => _checks.InequalityWith(name,
      () => new FieldAst(AstNulls.At, name) { Alias = alias });

  [Theory, RepeatData(Repeats)]
  public void Equality_WithArgument(string variable, string name)
    => _checks.Equality(
      () => new FieldAst(AstNulls.At, name) { Argument = new ArgumentAst(AstNulls.At, variable) });

  [Theory, RepeatData(Repeats)]
  public void Inequality_WithArgument(string variable, string name)
    => _checks.InequalityWith(name,
      () => new FieldAst(AstNulls.At, name) { Argument = new ArgumentAst(AstNulls.At, variable) });

  [Theory, RepeatData(Repeats)]
  public void Equality_WithModifiers(string name)
    => _checks.Equality(
      () => new FieldAst(AstNulls.At, name) { Modifiers = TestMods() });

  [Theory, RepeatData(Repeats)]
  public void Inequality_WithModifiers(string name)
    => _checks.InequalityWith(name,
      () => new FieldAst(AstNulls.At, name) { Modifiers = TestMods() });

  [Theory, RepeatData(Repeats)]
  public void Equality_WithSelection(string name, string[] fields)
    => _checks.Equality(
      () => new FieldAst(AstNulls.At, name) { Selections = fields.Fields() });

  [Theory, RepeatData(Repeats)]
  public void Inequality_WithSelection(string name, string[] fields)
    => _checks.InequalityWith(name,
      () => new FieldAst(AstNulls.At, name) { Selections = fields.Fields() });

  private readonly AstDirectivesChecks<FieldAst> _checks = new(name => new FieldAst(AstNulls.At, name));

  internal override IAstDirectivesChecks DirectivesChecks => _checks;
}
