namespace GqlPlus.Ast.Schema.Objects;

public class ParameterAstTests : AstAbbreviatedTests
{

  [Theory, RepeatData(Repeats)]
  public void HashCode_WithModifiers(string name)
      => _checks.HashCode(
        () => new InputParameterAst(AstNulls.At, name) { Modifiers = TestMods() });

  [Theory, RepeatData(Repeats)]
  public void String_WithModifiers(string name)
    => _checks.Text(
      () => new InputParameterAst(AstNulls.At, name) { Modifiers = TestMods() },
      $"( !Pa {name} [] ? )");

  [Theory, RepeatData(Repeats)]
  public void Equality_WithModifiers(string name)
    => _checks.Equality(
      () => new InputParameterAst(AstNulls.At, name) { Modifiers = TestMods() });

  [Theory, RepeatData(Repeats)]
  public void Inequality_WithModifiers(string name)
    => _checks.InequalityWith(name,
      () => new InputParameterAst(AstNulls.At, name) { Modifiers = TestMods() });

  [Theory, RepeatData(Repeats)]
  public void HashCode_WithDefault(string name, string def)
      => _checks.HashCode(
        () => new InputParameterAst(AstNulls.At, name) { DefaultValue = new(new FieldKeyAst(AstNulls.At, def)) });

  [Theory, RepeatData(Repeats)]
  public void String_WithDefault(string name, string def)
    => _checks.Text(
      () => new InputParameterAst(AstNulls.At, name) { DefaultValue = new(new FieldKeyAst(AstNulls.At, def)) },
      $"( !Pa {name} =( !k '{def}' ) )");

  [Theory, RepeatData(Repeats)]
  public void Equality_WithDefault(string name, string def)
    => _checks.Equality(
      () => new InputParameterAst(AstNulls.At, name) { DefaultValue = new(new FieldKeyAst(AstNulls.At, def)) });

  [SkippableTheory, RepeatData(Repeats)]
  public void Inequality_BetweenDefaults(string name, string def1, string def2)
    => _checks.InequalityBetween(def1, def2,
      def => new InputParameterAst(AstNulls.At, name) { DefaultValue = new(new FieldKeyAst(AstNulls.At, def)) },
      def1 == def2);

  private readonly AstAbbreviatedChecks<InputParameterAst> _checks
    = new(name => new InputParameterAst(AstNulls.At, name));

  internal override IAstAbbreviatedChecks<string> AbbreviatedChecks => _checks;
}
