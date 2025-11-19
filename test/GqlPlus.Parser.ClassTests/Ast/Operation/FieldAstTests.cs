namespace GqlPlus.Ast.Operation;

public partial class FieldAstTests
  : AstDirectivesBaseTests<string>
{
  [Theory, RepeatData]
  public void HashCode_WithAlias(string name, string alias)
    => _checks.HashCode(
      () => CreateField(name) with { FieldAlias = alias });

  [Theory, RepeatData]
  public void HashCode_WithArg(string variable, string name)
    => _checks.HashCode(
      () => CreateField(name) with { Arg = new ArgAst(AstNulls.At, variable) });

  [Theory, RepeatData]
  public void HashCode_WithSelection(string name, string[] fields)
  => _checks.HashCode(
    () => CreateField(name) with { Selections = fields.Fields() });

  [Theory, RepeatData]
  public void Text_WithAlias(string name, string alias)
    => _checks.Text(
      () => CreateField(name) with { FieldAlias = alias },
      $"( !f {alias}: {name} )");

  [Theory, RepeatData]
  public void Text_WithArg(string variable, string name)
    => _checks.Text(
      () => CreateField(name) with { Arg = new ArgAst(AstNulls.At, variable) },
      $"( !f {name} ( !a ${variable} ) )");

  [Theory, RepeatData]
  public void Text_WithSelection(string name, string[] fields)
  => _checks.Text(
      () => CreateField(name) with { Selections = fields.Fields() },
      $"( !f {name} {{ {fields.Joined(s => "!f " + s)} }} )");

  [Theory, RepeatData]
  public void Equality_WithAlias(string name, string alias)
    => _checks.Equality(
      () => CreateField(name) with { FieldAlias = alias });

  [Theory, RepeatData]
  public void Inequality_WithAlias(string name, string alias)
    => _checks.InequalityWith(name,
      () => CreateField(name) with { FieldAlias = alias });

  [Theory, RepeatData]
  public void Equality_WithArg(string variable, string name)
    => _checks.Equality(
      () => CreateField(name) with { Arg = new ArgAst(AstNulls.At, variable) });

  [Theory, RepeatData]
  public void Inequality_WithArg(string variable, string name)
    => _checks.InequalityWith(name,
      () => CreateField(name) with { Arg = new ArgAst(AstNulls.At, variable) });

  [Theory, RepeatData]
  public void Equality_WithSelection(string name, string[] fields)
    => _checks.Equality(
      () => CreateField(name) with { Selections = fields.Fields() });

  [Theory, RepeatData]
  public void Inequality_WithSelection(string name, string[] fields)
    => _checks.InequalityWith(name,
      () => CreateField(name) with { Selections = fields.Fields() });

  private readonly AstDirectivesChecks<FieldAst> _checks = new(CreateField);

  internal override IAstDirectivesChecks DirectivesChecks => _checks;

  [CheckTests]
  internal IModifiersChecks<string> ModifiersChecks { get; } = new ModifiersChecks<string, FieldAst>(
      CreateField,
      ast => ast with { Modifiers = TestMods() });

  [CheckTests]
  internal ICloneChecks<string> CloneChecks { get; }
    = new CloneChecks<string, FieldAst>(
      CreateField,
      (original, input) => original with { Identifier = input });

  private static FieldAst CreateField(string name)
    => new(AstNulls.At, name);
  private static FieldAst CreateField(string name, string[] directives)
    => new(AstNulls.At, name) { Directives = directives.Directives() };
}
