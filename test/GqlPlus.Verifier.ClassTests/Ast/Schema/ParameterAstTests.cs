namespace GqlPlus.Verifier.Ast.Schema;

public class ParameterAstTests : AstAbbreviatedTests
{

  [Theory, RepeatData(Repeats)]
  public void HashCode_WithModifiers(string name)
      => _checks.HashCode(
        () => new ParameterAst(AstNulls.At, name) { Modifiers = TestMods() });

  [Theory, RepeatData(Repeats)]
  public void String_WithModifiers(string name)
    => _checks.Text(
      () => new ParameterAst(AstNulls.At, name) { Modifiers = TestMods() },
      $"( !P {name} [] ? )");

  [Theory, RepeatData(Repeats)]
  public void Equality_WithModifiers(string name)
    => _checks.Equality(
      () => new ParameterAst(AstNulls.At, name) { Modifiers = TestMods() });

  [Theory, RepeatData(Repeats)]
  public void Inequality_WithModifiers(string name)
    => _checks.InequalityWith(name,
      () => new ParameterAst(AstNulls.At, name) { Modifiers = TestMods() });

  [Theory, RepeatData(Repeats)]
  public void HashCode_WithDefault(string name, string def)
      => _checks.HashCode(
        () => new ParameterAst(AstNulls.At, name) { Default = new FieldKeyAst(AstNulls.At, def) });

  [Theory, RepeatData(Repeats)]
  public void String_WithDefault(string name, string def)
    => _checks.Text(
      () => new ParameterAst(AstNulls.At, name) { Default = new FieldKeyAst(AstNulls.At, def) },
      $"( !P {name} =( !k '{def}' ) )");

  [Theory, RepeatData(Repeats)]
  public void Equality_WithDefault(string name, string def)
    => _checks.Equality(
      () => new ParameterAst(AstNulls.At, name) { Default = new FieldKeyAst(AstNulls.At, def) });

  [Theory, RepeatData(Repeats)]
  public void Inequality_BetweenDefaults(string name, string def1, string def2)
    => _checks.InequalityBetween(def1, def2,
      def => new ParameterAst(AstNulls.At, name) { Default = new FieldKeyAst(AstNulls.At, def) },
      def1 == def2);

  private readonly AstAbbreviatedChecks<ParameterAst> _checks
    = new(name => new ParameterAst(AstNulls.At, name));

  internal override IAstAbbreviatedChecks<string> AbbreviatedChecks => _checks;
}
