namespace GqlPlus.Ast.Schema.Objects;

public class OutputAstTests
  : AstAliasedTests
{
  [Theory, RepeatData(Repeats)]
  public void HashCode_WithAlternates(string name, AlternateInput[] alternates)
      => _checks.HashCode(
        () => new OutputDeclAst(AstNulls.At, name) { ObjAlternates = alternates.OutputAlternates() });

  [Theory, RepeatData(Repeats)]
  public void String_WithAlternates(string name, AlternateInput[] alternates)
    => _checks.Text(
      () => new OutputDeclAst(AstNulls.At, name) { ObjAlternates = alternates.OutputAlternates() },
      $"( !Ou {name} | {alternates.Joined(a => $"!OA {a.Type} [] ?")} )");

  [Theory, RepeatData(Repeats)]
  public void Equality_WithAlternates(string name, AlternateInput[] alternates)
    => _checks.Equality(
      () => new OutputDeclAst(AstNulls.At, name) { ObjAlternates = alternates.OutputAlternates() });

  [SkippableTheory, RepeatData(Repeats)]
  public void Inequality_BetweenAlternates(string name, AlternateInput[] alternates1, AlternateInput[] alternates2)
    => _checks.InequalityBetween(alternates1, alternates2,
      alternates => new OutputDeclAst(AstNulls.At, name) { ObjAlternates = alternates.OutputAlternates() },
      alternates1.OrderedEqual(alternates2));

  [Theory, RepeatData(Repeats)]
  public void HashCode_WithParent(string name, string parent)
      => _checks.HashCode(
        () => new OutputDeclAst(AstNulls.At, name) { Parent = NewBase(parent) });

  [Theory, RepeatData(Repeats)]
  public void String_WithParent(string name, string parent)
    => _checks.Text(
      () => new OutputDeclAst(AstNulls.At, name) { Parent = NewBase(parent) },
      $"( !Ou {name} : {parent} )");

  [Theory, RepeatData(Repeats)]
  public void Equality_WithParent(string name, string parent)
    => _checks.Equality(
      () => new OutputDeclAst(AstNulls.At, name) { Parent = NewBase(parent) });

  [SkippableTheory, RepeatData(Repeats)]
  public void Inequality_BetweenParent(string name, string parent1, string parent2)
    => _checks.InequalityBetween(parent1, parent2,
      parent => new OutputDeclAst(AstNulls.At, name) { Parent = NewBase(parent) },
      parent1 == parent2);

  [Theory, RepeatData(Repeats)]
  public void HashCode_WithFields(string name, FieldInput[] fields)
      => _checks.HashCode(
        () => new OutputDeclAst(AstNulls.At, name) { ObjFields = fields.OutputFields() });

  [Theory, RepeatData(Repeats)]
  public void String_WithFields(string name, FieldInput[] fields)
    => _checks.Text(
      () => new OutputDeclAst(AstNulls.At, name) { ObjFields = fields.OutputFields() },
      $"( !Ou {name} {{ {fields.Joined(fi => $"!OF {fi.Name} : {fi.Type}")} }} )");

  [Theory, RepeatData(Repeats)]
  public void Equality_WithFields(string name, FieldInput[] fields)
    => _checks.Equality(
      () => new OutputDeclAst(AstNulls.At, name) { ObjFields = fields.OutputFields() });

  [SkippableTheory, RepeatData(Repeats)]
  public void Inequality_BetweenFields(string name, FieldInput[] fields1, FieldInput[] fields2)
    => _checks.InequalityBetween(fields1, fields2,
      fields => new OutputDeclAst(AstNulls.At, name) { ObjFields = fields.OutputFields() },
      fields1.OrderedEqual(fields2));

  [Theory, RepeatData(Repeats)]
  public void HashCode_WithTypeParameters(string name, string[] typeParameters)
      => _checks.HashCode(
        () => new OutputDeclAst(AstNulls.At, name) { TypeParameters = typeParameters.TypeParameters() });

  [Theory, RepeatData(Repeats)]
  public void String_WithTypeParameters(string name, string[] typeParameters)
    => _checks.Text(
      () => new OutputDeclAst(AstNulls.At, name) { TypeParameters = typeParameters.TypeParameters() },
      $"( !Ou {name} < {typeParameters.Joined(s => "$" + s)} > )");

  [Theory, RepeatData(Repeats)]
  public void Equality_WithTypeParameters(string name, string[] typeParameters)
    => _checks.Equality(
      () => new OutputDeclAst(AstNulls.At, name) { TypeParameters = typeParameters.TypeParameters() });

  [SkippableTheory, RepeatData(Repeats)]
  public void Inequality_BetweenTypeParameterss(string name, string[] typeParameters1, string[] typeParameters2)
    => _checks.InequalityBetween(typeParameters1, typeParameters2,
      parameters => new OutputDeclAst(AstNulls.At, name) { TypeParameters = parameters.TypeParameters() },
      typeParameters1.SequenceEqual(typeParameters2));

  private static OutputBaseAst NewBase(string argument)
    => new(AstNulls.At, argument);

  protected override string AbbreviatedString(string input)
    => $"( !Ou {input} )";

  private readonly AstAliasedChecks<OutputDeclAst> _checks
    = new(regex => new OutputDeclAst(AstNulls.At, regex));

  internal override IAstAliasedChecks AliasedChecks => _checks;
}
