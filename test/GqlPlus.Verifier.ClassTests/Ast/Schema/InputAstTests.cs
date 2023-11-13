namespace GqlPlus.Verifier.Ast.Schema;

public class InputAstTests : BaseAliasedAstTests
{
  [Theory, RepeatData(Repeats)]
  public void HashCode_WithAlternates(string name, string alternate)
      => _checks.HashCode(
        () => new InputAst(AstNulls.At, name) { Alternates = alternate.Alternates(Reference) });

  [Theory, RepeatData(Repeats)]
  public void String_WithAlternates(string name, string alternate)
    => _checks.String(
      () => new InputAst(AstNulls.At, name) { Alternates = alternate.Alternates(Reference) },
      $"( !I {name} | !AI {alternate} [] ? )");

  [Theory, RepeatData(Repeats)]
  public void Equality_WithAlternates(string name, string alternate)
    => _checks.Equality(
      () => new InputAst(AstNulls.At, name) { Alternates = alternate.Alternates(Reference) });

  [Theory, RepeatData(Repeats)]
  public void Inequality_BetweenAlternates(string name, string alternate1, string alternate2)
    => _checks.InequalityBetween(alternate1, alternate2,
      alternate => new InputAst(AstNulls.At, name) { Alternates = alternate.Alternates(Reference) },
      alternate1 == alternate2);

  [Theory, RepeatData(Repeats)]
  public void HashCode_WithExtends(string name, string extends)
      => _checks.HashCode(
        () => new InputAst(AstNulls.At, name) { Extends = new(AstNulls.At, extends) });

  [Theory, RepeatData(Repeats)]
  public void String_WithExtends(string name, string extends)
    => _checks.String(
      () => new InputAst(AstNulls.At, name) { Extends = new(AstNulls.At, extends) },
      $"( !I {name} {extends} )");

  [Theory, RepeatData(Repeats)]
  public void Equality_WithExtends(string name, string extends)
    => _checks.Equality(
      () => new InputAst(AstNulls.At, name) { Extends = new(AstNulls.At, extends) });

  [Theory, RepeatData(Repeats)]
  public void Inequality_BetweenExtends(string name, string extends1, string extends2)
    => _checks.InequalityBetween(extends1, extends2,
      extends => new InputAst(AstNulls.At, name) { Extends = new(AstNulls.At, extends) },
      extends1 == extends2);

  [Theory, RepeatData(Repeats)]
  public void HashCode_WithFields(string name, string field)
      => _checks.HashCode(
        () => new InputAst(AstNulls.At, name) { Fields = field.InputFields("String") });

  [Theory, RepeatData(Repeats)]
  public void String_WithFields(string name, string field)
    => _checks.String(
      () => new InputAst(AstNulls.At, name) { Fields = field.InputFields("String") },
      $"( !I {name} {{ !IF {field} : String }} )");

  [Theory, RepeatData(Repeats)]
  public void Equality_WithFields(string name, string field)
    => _checks.Equality(
      () => new InputAst(AstNulls.At, name) { Fields = field.InputFields("String") });

  [Theory, RepeatData(Repeats)]
  public void Inequality_BetweenFields(string name, string field1, string field2)
    => _checks.InequalityBetween(field1, field2,
      field => new InputAst(AstNulls.At, name) { Fields = field.InputFields("String") },
      field1 == field2);

  [Theory, RepeatData(Repeats)]
  public void HashCode_WithParameters(string name, string parameter)
      => _checks.HashCode(
        () => new InputAst(AstNulls.At, name) { Parameters = parameter.TypeParameters() });

  [Theory, RepeatData(Repeats)]
  public void String_WithParameters(string name, string parameter)
    => _checks.String(
      () => new InputAst(AstNulls.At, name) { Parameters = parameter.TypeParameters() },
      $"( !I {name} < ${parameter} > )");

  [Theory, RepeatData(Repeats)]
  public void Equality_WithParameters(string name, string parameter)
    => _checks.Equality(
      () => new InputAst(AstNulls.At, name) { Parameters = parameter.TypeParameters() });

  [Theory, RepeatData(Repeats)]
  public void Inequality_BetweenParameterss(string name, string parameter1, string parameter2)
    => _checks.InequalityBetween(parameter1, parameter2,
      parameter => new InputAst(AstNulls.At, name) { Parameters = parameter.TypeParameters() },
      parameter1 == parameter2);

  private static InputReferenceAst Reference(string argument)
    => new(AstNulls.At, argument);

  protected override string InputString(string input)
    => $"( !I {input} )";

  private readonly BaseAliasedAstChecks<InputAst> _checks
    = new(regex => new InputAst(AstNulls.At, regex));

  internal override IBaseAliasedAstChecks AliasedChecks => _checks;
}
