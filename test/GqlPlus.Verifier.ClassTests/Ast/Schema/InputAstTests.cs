namespace GqlPlus.Verifier.Ast.Schema;

public class InputAstTests : AstAliasedTests
{
  [Theory, RepeatData(Repeats)]
  public void HashCode_WithAlternates(string name, string alternate)
      => _checks.HashCode(
        () => new InputDeclAst(AstNulls.At, name) { Alternates = alternate.Alternates(Reference) });

  [Theory, RepeatData(Repeats)]
  public void String_WithAlternates(string name, string alternate)
    => _checks.String(
      () => new InputDeclAst(AstNulls.At, name) { Alternates = alternate.Alternates(Reference) },
      $"( !I {name} | !AI {alternate} [] ? )");

  [Theory, RepeatData(Repeats)]
  public void Equality_WithAlternates(string name, string alternate)
    => _checks.Equality(
      () => new InputDeclAst(AstNulls.At, name) { Alternates = alternate.Alternates(Reference) });

  [Theory, RepeatData(Repeats)]
  public void Inequality_BetweenAlternates(string name, string alternate1, string alternate2)
    => _checks.InequalityBetween(alternate1, alternate2,
      alternate => new InputDeclAst(AstNulls.At, name) { Alternates = alternate.Alternates(Reference) },
      alternate1 == alternate2);

  [Theory, RepeatData(Repeats)]
  public void HashCode_WithExtends(string name, string parent)
      => _checks.HashCode(
        () => new InputDeclAst(AstNulls.At, name) { Parent = new(AstNulls.At, parent) });

  [Theory, RepeatData(Repeats)]
  public void String_WithExtends(string name, string parent)
    => _checks.String(
      () => new InputDeclAst(AstNulls.At, name) { Parent = new(AstNulls.At, parent) },
      $"( !I {name} : {parent} )");

  [Theory, RepeatData(Repeats)]
  public void Equality_WithExtends(string name, string parent)
    => _checks.Equality(
      () => new InputDeclAst(AstNulls.At, name) { Parent = new(AstNulls.At, parent) });

  [Theory, RepeatData(Repeats)]
  public void Inequality_BetweenExtends(string name, string extends1, string extends2)
    => _checks.InequalityBetween(extends1, extends2,
      parent => new InputDeclAst(AstNulls.At, name) { Parent = new(AstNulls.At, parent) },
      extends1 == extends2);

  [Theory, RepeatData(Repeats)]
  public void HashCode_WithFields(string name, string field)
      => _checks.HashCode(
        () => new InputDeclAst(AstNulls.At, name) { Fields = field.InputFields("String") });

  [Theory, RepeatData(Repeats)]
  public void String_WithFields(string name, string field)
    => _checks.String(
      () => new InputDeclAst(AstNulls.At, name) { Fields = field.InputFields("String") },
      $"( !I {name} {{ !IF {field} : String }} )");

  [Theory, RepeatData(Repeats)]
  public void Equality_WithFields(string name, string field)
    => _checks.Equality(
      () => new InputDeclAst(AstNulls.At, name) { Fields = field.InputFields("String") });

  [Theory, RepeatData(Repeats)]
  public void Inequality_BetweenFields(string name, string field1, string field2)
    => _checks.InequalityBetween(field1, field2,
      field => new InputDeclAst(AstNulls.At, name) { Fields = field.InputFields("String") },
      field1 == field2);

  [Theory, RepeatData(Repeats)]
  public void HashCode_WithTypeParameters(string name, string[] typeParameters)
      => _checks.HashCode(
        () => new InputDeclAst(AstNulls.At, name) { TypeParameters = typeParameters.TypeParameters() });

  [Theory, RepeatData(Repeats)]
  public void String_WithTypeParameters(string name, string[] typeParameters)
    => _checks.String(
      () => new InputDeclAst(AstNulls.At, name) { TypeParameters = typeParameters.TypeParameters() },
      $"( !I {name} < {typeParameters.Joined("$")} > )");

  [Theory, RepeatData(Repeats)]
  public void Equality_WithTypeParameters(string name, string[] typeParameters)
    => _checks.Equality(
      () => new InputDeclAst(AstNulls.At, name) { TypeParameters = typeParameters.TypeParameters() });

  [Theory, RepeatData(Repeats)]
  public void Inequality_BetweenTypeParameterss(string name, string[] typeParameters1, string[] typeParameters2)
    => _checks.InequalityBetween(typeParameters1, typeParameters2,
      parameters => new InputDeclAst(AstNulls.At, name) { TypeParameters = parameters.TypeParameters() },
      typeParameters1.SequenceEqual(typeParameters2));

  private static InputReferenceAst Reference(string argument)
    => new(AstNulls.At, argument);

  protected override string AbbreviatedString(string input)
    => $"( !I {input} )";

  private readonly AstAliasedChecks<InputDeclAst> _checks
    = new(regex => new InputDeclAst(AstNulls.At, regex));

  internal override IAstAliasedChecks AliasedChecks => _checks;
}
