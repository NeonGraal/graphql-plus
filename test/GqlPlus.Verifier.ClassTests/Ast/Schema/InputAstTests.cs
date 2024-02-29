namespace GqlPlus.Verifier.Ast.Schema;

public class InputAstTests : AstAliasedTests
{
  [Theory, RepeatData(Repeats)]
  public void HashCode_WithAlternates(string name, string[] alternates)
      => _checks.HashCode(
        () => new InputDeclAst(AstNulls.At, name) { Alternates = alternates.Alternates(Reference) });

  [Theory, RepeatData(Repeats)]
  public void String_WithAlternates(string name, string[] alternates)
    => _checks.Text(
      () => new InputDeclAst(AstNulls.At, name) { Alternates = alternates.Alternates(Reference) },
      $"( !I {name} | {alternates.Joined(a => $"!AI {a} [] ?")} )");

  [Theory, RepeatData(Repeats)]
  public void Equality_WithAlternates(string name, string[] alternates)
    => _checks.Equality(
      () => new InputDeclAst(AstNulls.At, name) { Alternates = alternates.Alternates(Reference) });

  [SkippableTheory, RepeatData(Repeats)]
  public void Inequality_BetweenAlternates(string name, string[] alternates1, string[] alternates2)
    => _checks.InequalityBetween(alternates1, alternates2,
      alternates => new InputDeclAst(AstNulls.At, name) { Alternates = alternates.Alternates(Reference) },
      alternates1.OrderedEqual(alternates2));

  [Theory, RepeatData(Repeats)]
  public void HashCode_WithParent(string name, string parent)
      => _checks.HashCode(
        () => new InputDeclAst(AstNulls.At, name) { Parent = new(AstNulls.At, parent) });

  [Theory, RepeatData(Repeats)]
  public void String_WithParent(string name, string parent)
    => _checks.Text(
      () => new InputDeclAst(AstNulls.At, name) { Parent = new(AstNulls.At, parent) },
      $"( !I {name} : {parent} )");

  [Theory, RepeatData(Repeats)]
  public void Equality_WithParent(string name, string parent)
    => _checks.Equality(
      () => new InputDeclAst(AstNulls.At, name) { Parent = new(AstNulls.At, parent) });

  [SkippableTheory, RepeatData(Repeats)]
  public void Inequality_BetweenParent(string name, string parent1, string parent2)
    => _checks.InequalityBetween(parent1, parent2,
      parent => new InputDeclAst(AstNulls.At, name) { Parent = new(AstNulls.At, parent) },
      parent1 == parent2);

  [Theory, RepeatData(Repeats)]
  public void HashCode_WithFields(string name, FieldInput[] fields)
      => _checks.HashCode(
        () => new InputDeclAst(AstNulls.At, name) { Fields = fields.InputFields() });

  [Theory, RepeatData(Repeats)]
  public void String_WithFields(string name, FieldInput[] fields)
    => _checks.Text(
      () => new InputDeclAst(AstNulls.At, name) { Fields = fields.InputFields() },
      $"( !I {name} {{ {fields.Joined(fi => $"!IF {fi.Name} : {fi.Type}")} }} )");

  [Theory, RepeatData(Repeats)]
  public void Equality_WithFields(string name, FieldInput[] fields)
    => _checks.Equality(
      () => new InputDeclAst(AstNulls.At, name) { Fields = fields.InputFields() });

  [SkippableTheory, RepeatData(Repeats)]
  public void Inequality_BetweenFields(string name, FieldInput[] fields1, FieldInput[] fields2)
    => _checks.InequalityBetween(fields1, fields2,
      fields => new InputDeclAst(AstNulls.At, name) { Fields = fields.InputFields() },
      fields1.OrderedEqual(fields2));

  [Theory, RepeatData(Repeats)]
  public void HashCode_WithTypeParameters(string name, string[] typeParameters)
      => _checks.HashCode(
        () => new InputDeclAst(AstNulls.At, name) { TypeParameters = typeParameters.TypeParameters() });

  [Theory, RepeatData(Repeats)]
  public void String_WithTypeParameters(string name, string[] typeParameters)
    => _checks.Text(
      () => new InputDeclAst(AstNulls.At, name) { TypeParameters = typeParameters.TypeParameters() },
      $"( !I {name} < {typeParameters.Joined("$")} > )");

  [Theory, RepeatData(Repeats)]
  public void Equality_WithTypeParameters(string name, string[] typeParameters)
    => _checks.Equality(
      () => new InputDeclAst(AstNulls.At, name) { TypeParameters = typeParameters.TypeParameters() });

  [SkippableTheory, RepeatData(Repeats)]
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
