using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Ast.Schema.Objects;

public class DualAstTests
  : AstAliasedTests
{
  [Theory, RepeatData(Repeats)]
  public void HashCode_WithAlternates(string name, AlternateInput[] alternates)
      => _checks.HashCode(
        () => new DualDeclAst(AstNulls.At, name) { Alternates = alternates.DualAlternates() });

  [Theory, RepeatData(Repeats)]
  public void String_WithAlternates(string name, AlternateInput[] alternates)
    => _checks.Text(
      () => new DualDeclAst(AstNulls.At, name) { Alternates = alternates.DualAlternates() },
      $"( !Du {name} | {alternates.Joined(a => $"!DA {a.Type} [] ?")} )");

  [Theory, RepeatData(Repeats)]
  public void Equality_WithAlternates(string name, AlternateInput[] alternates)
    => _checks.Equality(
      () => new DualDeclAst(AstNulls.At, name) { Alternates = alternates.DualAlternates() });

  [SkippableTheory, RepeatData(Repeats)]
  public void Inequality_BetweenAlternates(string name, AlternateInput[] alternates1, AlternateInput[] alternates2)
    => _checks.InequalityBetween(alternates1, alternates2,
      alternates => new DualDeclAst(AstNulls.At, name) { Alternates = alternates.DualAlternates() },
      alternates1.OrderedEqual(alternates2));

  [Theory, RepeatData(Repeats)]
  public void HashCode_WithParent(string name, string parent)
      => _checks.HashCode(
        () => new DualDeclAst(AstNulls.At, name) { Parent = Base(parent) });

  [Theory, RepeatData(Repeats)]
  public void String_WithParent(string name, string parent)
    => _checks.Text(
      () => new DualDeclAst(AstNulls.At, name) { Parent = Base(parent) },
      $"( !Du {name} : {parent} )");

  [Theory, RepeatData(Repeats)]
  public void Equality_WithParent(string name, string parent)
    => _checks.Equality(
      () => new DualDeclAst(AstNulls.At, name) { Parent = Base(parent) });

  [SkippableTheory, RepeatData(Repeats)]
  public void Inequality_BetweenParent(string name, string parent1, string parent2)
    => _checks.InequalityBetween(parent1, parent2,
      parent => new DualDeclAst(AstNulls.At, name) { Parent = Base(parent) },
      parent1 == parent2);

  [Theory, RepeatData(Repeats)]
  public void HashCode_WithFields(string name, FieldInput[] fields)
      => _checks.HashCode(
        () => new DualDeclAst(AstNulls.At, name) { Fields = fields.DualFields() });

  [Theory, RepeatData(Repeats)]
  public void String_WithFields(string name, FieldInput[] fields)
    => _checks.Text(
      () => new DualDeclAst(AstNulls.At, name) { Fields = fields.DualFields() },
      $"( !Du {name} {{ {fields.Joined(fi => $"!DF {fi.Name} : {fi.Type}")} }} )");

  [Theory, RepeatData(Repeats)]
  public void Equality_WithFields(string name, FieldInput[] fields)
    => _checks.Equality(
      () => new DualDeclAst(AstNulls.At, name) { Fields = fields.DualFields() });

  [SkippableTheory, RepeatData(Repeats)]
  public void Inequality_BetweenFields(string name, FieldInput[] fields1, FieldInput[] fields2)
    => _checks.InequalityBetween(fields1, fields2,
      fields => new DualDeclAst(AstNulls.At, name) { Fields = fields.DualFields() },
      fields1.OrderedEqual(fields2));

  [Theory, RepeatData(Repeats)]
  public void HashCode_WithTypeParameters(string name, string[] typeParameters)
      => _checks.HashCode(
        () => new DualDeclAst(AstNulls.At, name) { TypeParameters = typeParameters.TypeParameters() });

  [Theory, RepeatData(Repeats)]
  public void String_WithTypeParameters(string name, string[] typeParameters)
    => _checks.Text(
      () => new DualDeclAst(AstNulls.At, name) { TypeParameters = typeParameters.TypeParameters() },
      $"( !Du {name} < {typeParameters.Joined(s => "$" + s)} > )");

  [Theory, RepeatData(Repeats)]
  public void Equality_WithTypeParameters(string name, string[] typeParameters)
    => _checks.Equality(
      () => new DualDeclAst(AstNulls.At, name) { TypeParameters = typeParameters.TypeParameters() });

  [SkippableTheory, RepeatData(Repeats)]
  public void Inequality_BetweenTypeParameterss(string name, string[] typeParameters1, string[] typeParameters2)
    => _checks.InequalityBetween(typeParameters1, typeParameters2,
      parameters => new DualDeclAst(AstNulls.At, name) { TypeParameters = parameters.TypeParameters() },
      typeParameters1.SequenceEqual(typeParameters2));

  private static DualBaseAst Base(string argument)
    => new(AstNulls.At, argument);

  protected override string AbbreviatedString(string input)
    => $"( !Du {input} )";

  private readonly AstAliasedChecks<DualDeclAst> _checks
    = new(regex => new DualDeclAst(AstNulls.At, regex));

  internal override IAstAliasedChecks AliasedChecks => _checks;
}
