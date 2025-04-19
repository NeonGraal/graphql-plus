namespace GqlPlus.Ast.Schema.Objects;

public class ParamAstTests : AstAbbreviatedTests
{
  [Theory, RepeatData]
  public void HashCode_WithModifiers(string name)
      => _checks.HashCode(
        () => new InputParamAst(AstNulls.At, name) { Modifiers = TestMods() });

  [Theory, RepeatData]
  public void String_WithModifiers(string name)
    => _checks.Text(
      () => new InputParamAst(AstNulls.At, name) { Modifiers = TestMods() },
      $"( !Pa {name} [] ? )");

  [Theory, RepeatData]
  public void Equality_WithModifiers(string name)
    => _checks.Equality(
      () => new InputParamAst(AstNulls.At, name) { Modifiers = TestMods() });

  [Theory, RepeatData]
  public void Inequality_WithModifiers(string name)
    => _checks.InequalityWith(name,
      () => new InputParamAst(AstNulls.At, name) { Modifiers = TestMods() });

  [Theory, RepeatData]
  public void HashCode_WithDefault(string name, string def)
      => _checks.HashCode(
        () => new InputParamAst(AstNulls.At, name) { DefaultValue = new(new FieldKeyAst(AstNulls.At, def)) });

  [Theory, RepeatData]
  public void String_WithDefault(string name, string def)
    => _checks.Text(
      () => new InputParamAst(AstNulls.At, name) { DefaultValue = new(new FieldKeyAst(AstNulls.At, def)) },
      $"( !Pa {name} =( !k '{def}' ) )");

  [Theory, RepeatData]
  public void Equality_WithDefault(string name, string def)
    => _checks.Equality(
      () => new InputParamAst(AstNulls.At, name) { DefaultValue = new(new FieldKeyAst(AstNulls.At, def)) });

  [Theory, RepeatData]
  public void Inequality_BetweenDefaults(string name, string def1, string def2)
    => _checks.InequalityBetween(def1, def2,
      def => new InputParamAst(AstNulls.At, name) { DefaultValue = new(new FieldKeyAst(AstNulls.At, def)) },
      def1 == def2);

  private readonly AstAbbreviatedChecks<InputParamAst> _checks
    = new(name => new InputParamAst(AstNulls.At, name));

  internal override IAstAbbreviatedChecks<string> AbbreviatedChecks => _checks;
}
