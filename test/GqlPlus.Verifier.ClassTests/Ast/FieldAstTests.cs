namespace GqlPlus.Verifier.Ast;

public class FieldAstTests : BaseNamedDirectivesAstTests
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
  public void HashCode_WithSelection(string name, string field)
  => _checks.HashCode(
    () => new FieldAst(AstNulls.At, name) { Selections = field.Fields() });

  [Theory, RepeatData(Repeats)]
  public void String_WithAlias(string name, string alias)
    => _checks.String(
      () => new FieldAst(AstNulls.At, name) { Alias = alias },
      $"( !F {alias}: {name} )");

  [Theory, RepeatData(Repeats)]
  public void String_WithArgument(string variable, string name)
    => _checks.String(
      () => new FieldAst(AstNulls.At, name) { Argument = new ArgumentAst(AstNulls.At, variable) },
      $"( !F {name} ( !A ${variable} ) )");

  [Theory, RepeatData(Repeats)]
  public void String_WithModifiers(string name)
    => _checks.String(
      () => new FieldAst(AstNulls.At, name) { Modifiers = TestMods() },
      $"( !F {name} []? )");

  [Theory, RepeatData(Repeats)]
  public void String_WithSelection(string name, string field)
  => _checks.String(
      () => new FieldAst(AstNulls.At, name) { Selections = field.Fields() },
      $"( !F {name} {{ !F {field} }} )");

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
  public void Equality_WithSelection(string name, string field)
    => _checks.Equality(
      () => new FieldAst(AstNulls.At, name) { Selections = field.Fields() });

  [Theory, RepeatData(Repeats)]
  public void Inequality_WithSelection(string name, string field)
    => _checks.InequalityWith(name,
      () => new FieldAst(AstNulls.At, name) { Selections = field.Fields() });

  private readonly BaseNamedDirectivesAstChecks<FieldAst> _checks = new(name => new FieldAst(AstNulls.At, name));

  internal override BaseNamedDirectivesAstChecks DirectivesChecks => _checks;
}
