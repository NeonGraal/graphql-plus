
namespace GqlPlus.Ast.Schema.Objects;

public class ParamAstTests : AstAbbreviatedBaseTests
{
  [Theory, RepeatData]
  public void HashCode_WithModifiers(string name)
      => _checks.HashCode(
        () => new InputParamAst(AstNulls.At, name) { Modifiers = TestMods() });

  [Theory, RepeatData]
  public void Text_WithModifiers(string name)
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
        () => new InputParamAst(AstNulls.At, name) { DefaultValue = new ConstantAst(new FieldKeyAst(AstNulls.At, def)) });

  [Theory, RepeatData]
  public void Text_WithDefault(string name, string def)
    => _checks.Text(
      () => new InputParamAst(AstNulls.At, name) { DefaultValue = new ConstantAst(new FieldKeyAst(AstNulls.At, def)) },
      $"( !Pa {name} =( !k '{def}' ) )");

  [Theory, RepeatData]
  public void Equality_WithDefault(string name, string def)
    => _checks.Equality(
      () => new InputParamAst(AstNulls.At, name) { DefaultValue = new ConstantAst(new FieldKeyAst(AstNulls.At, def)) });

  [Theory, RepeatData]
  public void Inequality_BetweenDefaults(string name, string def1, string def2)
    => _checks.InequalityBetween(def1, def2,
      def => new InputParamAst(AstNulls.At, name) { DefaultValue = new ConstantAst(new FieldKeyAst(AstNulls.At, def)) },
      def1 == def2);

  private readonly AstAbbreviatedChecks<InputParamAst> _checks
    = new(CreateInputParam);

  private static InputParamAst CloneInputParam(InputParamAst original, string input)
    => original with { Type = new ObjBaseAst(AstNulls.At, input, string.Empty) };
  private static InputParamAst CreateInputParam(string input)
    => new(AstNulls.At, input);

  internal override IAstAbbreviatedChecks<string> AbbreviatedChecks => _checks;
}
