namespace GqlPlus.Verifier.Ast.Operation;

public class FieldAstTests : AstDirectivesTests
{
  [Theory, RepeatData(Repeats)]
  public void HashCode_WithAlias(string name, string alias)
    => _checks.HashCode(
      () => Field(name) with { Alias = alias });

  [Theory, RepeatData(Repeats)]
  public void HashCode_WithArgument(string variable, string name)
    => _checks.HashCode(
      () => Field(name) with { Argument = new ArgumentAst(AstNulls.At, variable) });

  [Theory, RepeatData(Repeats)]
  public void HashCode_WithModifiers(string name)
    => _checks.HashCode(
      () => Field(name) with { Modifiers = TestMods() });

  [Theory, RepeatData(Repeats)]
  public void HashCode_WithSelection(string name, string[] fields)
  => _checks.HashCode(
    () => Field(name) with { Selections = fields.Fields() });

  [Theory, RepeatData(Repeats)]
  public void String_WithAlias(string name, string alias)
    => _checks.Text(
      () => Field(name) with { Alias = alias },
      $"( !f {alias}: {name} )");

  [Theory, RepeatData(Repeats)]
  public void String_WithArgument(string variable, string name)
    => _checks.Text(
      () => Field(name) with { Argument = new ArgumentAst(AstNulls.At, variable) },
      $"( !f {name} ( !a ${variable} ) )");

  [Theory, RepeatData(Repeats)]
  public void String_WithModifiers(string name)
    => _checks.Text(
      () => Field(name) with { Modifiers = TestMods() },
      $"( !f {name} []? )");

  [Theory, RepeatData(Repeats)]
  public void String_WithSelection(string name, string[] fields)
  => _checks.Text(
      () => Field(name) with { Selections = fields.Fields() },
      $"( !f {name} {{ {fields.Joined("!f ")} }} )");

  [Theory, RepeatData(Repeats)]
  public void Equality_WithAlias(string name, string alias)
    => _checks.Equality(
      () => Field(name) with { Alias = alias });

  [Theory, RepeatData(Repeats)]
  public void Inequality_WithAlias(string name, string alias)
    => _checks.InequalityWith(name,
      () => Field(name) with { Alias = alias });

  [Theory, RepeatData(Repeats)]
  public void Equality_WithArgument(string variable, string name)
    => _checks.Equality(
      () => Field(name) with { Argument = new ArgumentAst(AstNulls.At, variable) });

  [Theory, RepeatData(Repeats)]
  public void Inequality_WithArgument(string variable, string name)
    => _checks.InequalityWith(name,
      () => Field(name) with { Argument = new ArgumentAst(AstNulls.At, variable) });

  [Theory, RepeatData(Repeats)]
  public void Equality_WithModifiers(string name)
    => _checks.Equality(
      () => Field(name) with { Modifiers = TestMods() });

  [Theory, RepeatData(Repeats)]
  public void Inequality_WithModifiers(string name)
    => _checks.InequalityWith(name,
      () => Field(name) with { Modifiers = TestMods() });

  [Theory, RepeatData(Repeats)]
  public void Equality_WithSelection(string name, string[] fields)
    => _checks.Equality(
      () => Field(name) with { Selections = fields.Fields() });

  [Theory, RepeatData(Repeats)]
  public void Inequality_WithSelection(string name, string[] fields)
    => _checks.InequalityWith(name,
      () => Field(name) with { Selections = fields.Fields() });

  private readonly AstDirectivesChecks<FieldAst> _checks = new(Field);

  internal override IAstDirectivesChecks DirectivesChecks => _checks;

  private static FieldAst Field(string name)
    => new(AstNulls.At, name);
}
