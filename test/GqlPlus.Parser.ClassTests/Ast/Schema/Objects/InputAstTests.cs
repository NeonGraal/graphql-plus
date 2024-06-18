namespace GqlPlus.Ast.Schema.Objects;

public class InputAstTests
  : AstAliasedTests
{
  [Theory, RepeatData(Repeats)]
  public void HashCode_WithAlternates(string name, AlternateInput[] alternates)
      => _checks.HashCode(
        () => new InputDeclAst(AstNulls.At, name) { Alternates = alternates.InputAlternates() });

  [Theory, RepeatData(Repeats)]
  public void String_WithAlternates(string name, AlternateInput[] alternates)
    => _checks.Text(
      () => new InputDeclAst(AstNulls.At, name) { Alternates = alternates.InputAlternates() },
      $"( !In {name} | {alternates.Joined(a => $"!IA {a.Type} [] ?")} )");

  [Theory, RepeatData(Repeats)]
  public void Equality_WithAlternates(string name, AlternateInput[] alternates)
    => _checks.Equality(
      () => new InputDeclAst(AstNulls.At, name) { Alternates = alternates.InputAlternates() });

  [SkippableTheory, RepeatData(Repeats)]
  public void Inequality_BetweenAlternates(string name, AlternateInput[] alternates1, AlternateInput[] alternates2)
    => _checks.InequalityBetween(alternates1, alternates2,
      alternates => new InputDeclAst(AstNulls.At, name) { Alternates = alternates.InputAlternates() },
      alternates1.OrderedEqual(alternates2));

  [Theory, RepeatData(Repeats)]
  public void HashCode_WithParent(string name, string parent)
      => _checks.HashCode(
        () => new InputDeclAst(AstNulls.At, name) { Parent = NewBase(parent) });

  [Theory, RepeatData(Repeats)]
  public void String_WithParent(string name, string parent)
    => _checks.Text(
      () => new InputDeclAst(AstNulls.At, name) { Parent = NewBase(parent) },
      $"( !In {name} : {parent} )");

  [Theory, RepeatData(Repeats)]
  public void Equality_WithParent(string name, string parent)
    => _checks.Equality(
      () => new InputDeclAst(AstNulls.At, name) { Parent = NewBase(parent) });

  [SkippableTheory, RepeatData(Repeats)]
  public void Inequality_BetweenParent(string name, string parent1, string parent2)
    => _checks.InequalityBetween(parent1, parent2,
      parent => new InputDeclAst(AstNulls.At, name) { Parent = NewBase(parent) },
      parent1 == parent2);

  [Theory, RepeatData(Repeats)]
  public void HashCode_WithFields(string name, FieldInput[] fields)
      => _checks.HashCode(
        () => new InputDeclAst(AstNulls.At, name) { Fields = fields.InputFields() });

  [Theory, RepeatData(Repeats)]
  public void String_WithFields(string name, FieldInput[] fields)
    => _checks.Text(
      () => new InputDeclAst(AstNulls.At, name) { Fields = fields.InputFields() },
      $"( !In {name} {{ {fields.Joined(fi => $"!IF {fi.Name} : {fi.Type}")} }} )");

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
      $"( !In {name} < {typeParameters.Joined(s => "$" + s)} > )");

  [Theory, RepeatData(Repeats)]
  public void Equality_WithTypeParameters(string name, string[] typeParameters)
    => _checks.Equality(
      () => new InputDeclAst(AstNulls.At, name) { TypeParameters = typeParameters.TypeParameters() });

  [SkippableTheory, RepeatData(Repeats)]
  public void Inequality_BetweenTypeParameterss(string name, string[] typeParameters1, string[] typeParameters2)
    => _checks.InequalityBetween(typeParameters1, typeParameters2,
      parameters => new InputDeclAst(AstNulls.At, name) { TypeParameters = parameters.TypeParameters() },
      typeParameters1.SequenceEqual(typeParameters2));

  private static InputBaseAst NewBase(string argument)
    => new(AstNulls.At, argument);

  protected override string AbbreviatedString(string input)
    => $"( !In {input} )";

  private readonly AstAliasedChecks<InputDeclAst> _checks
    = new(regex => new InputDeclAst(AstNulls.At, regex));

  internal override IAstAliasedChecks AliasedChecks => _checks;
}
