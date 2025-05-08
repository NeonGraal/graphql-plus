namespace GqlPlus.Ast.Operation;

public class FieldAstTests : AstDirectivesTests
{
  [Theory, RepeatData]
  public void HashCode_WithAlias(string name, string alias)
    => _checks.HashCode(
      () => Field(name) with { FieldAlias = alias });

  [Theory, RepeatData]
  public void HashCode_WithArg(string variable, string name)
    => _checks.HashCode(
      () => Field(name) with { Arg = new ArgAst(AstNulls.At, variable) });

  [Theory, RepeatData]
  public void HashCode_WithModifiers(string name)
    => _checks.HashCode(
      () => Field(name) with { Modifiers = TestMods() });

  [Theory, RepeatData]
  public void HashCode_WithSelection(string name, string[] fields)
  => _checks.HashCode(
    () => Field(name) with { Selections = fields.Fields() });

  [Theory, RepeatData]
  public void String_WithAlias(string name, string alias)
    => _checks.Text(
      () => Field(name) with { FieldAlias = alias },
      $"( !f {alias}: {name} )");

  [Theory, RepeatData]
  public void String_WithArg(string variable, string name)
    => _checks.Text(
      () => Field(name) with { Arg = new ArgAst(AstNulls.At, variable) },
      $"( !f {name} ( !a ${variable} ) )");

  [Theory, RepeatData]
  public void String_WithModifiers(string name)
    => _checks.Text(
      () => Field(name) with { Modifiers = TestMods() },
      $"( !f {name} []? )");

  [Theory, RepeatData]
  public void String_WithSelection(string name, string[] fields)
  => _checks.Text(
      () => Field(name) with { Selections = fields.Fields() },
      $"( !f {name} {{ {fields.Joined(s => "!f " + s)} }} )");

  [Theory, RepeatData]
  public void Equality_WithAlias(string name, string alias)
    => _checks.Equality(
      () => Field(name) with { FieldAlias = alias });

  [Theory, RepeatData]
  public void Inequality_WithAlias(string name, string alias)
    => _checks.InequalityWith(name,
      () => Field(name) with { FieldAlias = alias });

  [Theory, RepeatData]
  public void Equality_WithArg(string variable, string name)
    => _checks.Equality(
      () => Field(name) with { Arg = new ArgAst(AstNulls.At, variable) });

  [Theory, RepeatData]
  public void Inequality_WithArg(string variable, string name)
    => _checks.InequalityWith(name,
      () => Field(name) with { Arg = new ArgAst(AstNulls.At, variable) });

  [Theory, RepeatData]
  public void Equality_WithModifiers(string name)
    => _checks.Equality(
      () => Field(name) with { Modifiers = TestMods() });

  [Theory, RepeatData]
  public void Inequality_WithModifiers(string name)
    => _checks.InequalityWith(name,
      () => Field(name) with { Modifiers = TestMods() });

  [Theory, RepeatData]
  public void Equality_WithSelection(string name, string[] fields)
    => _checks.Equality(
      () => Field(name) with { Selections = fields.Fields() });

  [Theory, RepeatData]
  public void Inequality_WithSelection(string name, string[] fields)
    => _checks.InequalityWith(name,
      () => Field(name) with { Selections = fields.Fields() });

  private readonly AstDirectivesChecks<FieldAst> _checks = new(Field);

  internal override IAstDirectivesChecks DirectivesChecks => _checks;

  private static FieldAst Field(string name)
    => new(AstNulls.At, name);
  private static FieldAst Field(string name, string[] directives)
    => new(AstNulls.At, name) { Directives = directives.Directives() };
}
