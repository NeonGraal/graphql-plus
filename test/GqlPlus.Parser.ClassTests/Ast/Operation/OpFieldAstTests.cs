namespace GqlPlus.Ast.Operation;

public partial class OpFieldAstTests
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
  public void Text_WithAlias(string name, string alias)
    => _checks.Text(
      () => CreateField(name) with { FieldAlias = alias },
      $"( !of {alias}: {name} )");

  [Theory, RepeatData]
  public void Text_WithArg(string variable, string name)
    => _checks.Text(
      () => CreateField(name) with { Arg = new ArgAst(AstNulls.At, variable) },
      $"( !of {name} ( !a ${variable} ) )");

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

  private readonly AstDirectivesChecks<OpFieldAst> _checks = new(CreateField);

  internal override IAstDirectivesChecks DirectivesChecks => _checks;

  [CheckTests]
  internal IModifiersChecks<string> ModifiersChecks { get; } = new ModifiersChecks<string, OpFieldAst>(
      CreateField,
      ast => ast with { Modifiers = TestMods() });

  [CheckTests]
  internal ICloneChecks<string> CloneChecks { get; }
    = new CloneChecks<string, OpFieldAst>(
      CreateField,
      (original, input) => original with { Identifier = input });

  private static OpFieldAst CreateField(string name)
    => new(AstNulls.At, name);
  private static OpFieldAst CreateField(string name, string[] directives)
    => new(AstNulls.At, name) { Directives = directives.Directives() };
}
