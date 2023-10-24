﻿namespace GqlPlus.Verifier.Ast.Schema;

public class ParameterAstTests : BaseNamedAstTests
{

  [Theory, RepeatData(Repeats)]
  public void HashCode_WithModifiers(string name)
      => _checks.HashCode(
        () => new ParameterAst(AstNulls.At, name) { Modifiers = TestMods() });

  [Theory, RepeatData(Repeats)]
  public void String_WithModifiers(string name)
    => _checks.String(
      () => new ParameterAst(AstNulls.At, name) { Modifiers = TestMods() },
      $"( !P {name} [] ? )");

  [Theory, RepeatData(Repeats)]
  public void Equality_WithModifiers(string name)
    => _checks.Equality(
      () => new ParameterAst(AstNulls.At, name) { Modifiers = TestMods() });

  [Theory, RepeatData(Repeats)]
  public void HashCode_WithDefault(string name, string def)
      => _checks.HashCode(
        () => new ParameterAst(AstNulls.At, name) { Default = new FieldKeyAst(AstNulls.At, def) });

  [Theory, RepeatData(Repeats)]
  public void String_WithDefault(string name, string def)
    => _checks.String(
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

  protected override string InputString(string input)
    => $"( !P {input} )";

  private readonly BaseNamedAstChecks<ParameterAst> _checks
    = new(name => new ParameterAst(AstNulls.At, name));

  internal override IBaseNamedAstChecks NamedChecks => _checks;
}
