﻿namespace GqlPlus.Verifier.Ast.Schema;

public class DualAstTests
  : AstAliasedTests
{
  [Theory, RepeatData(Repeats)]
  public void HashCode_WithAlternates(string name, string[] alternates)
      => _checks.HashCode(
        () => new DualDeclAst(AstNulls.At, name) { Alternates = alternates.Alternates(Reference) });

  [Theory, RepeatData(Repeats)]
  public void String_WithAlternates(string name, string[] alternates)
    => _checks.Text(
      () => new DualDeclAst(AstNulls.At, name) { Alternates = alternates.Alternates(Reference) },
      $"( !D {name} | {alternates.Joined(a => $"!AD {a} [] ?")} )");

  [Theory, RepeatData(Repeats)]
  public void Equality_WithAlternates(string name, string[] alternates)
    => _checks.Equality(
      () => new DualDeclAst(AstNulls.At, name) { Alternates = alternates.Alternates(Reference) });

  [SkippableTheory, RepeatData(Repeats)]
  public void Inequality_BetweenAlternates(string name, string[] alternates1, string[] alternates2)
    => _checks.InequalityBetween(alternates1, alternates2,
      alternates => new DualDeclAst(AstNulls.At, name) { Alternates = alternates.Alternates(Reference) },
      alternates1.OrderedEqual(alternates2));

  [Theory, RepeatData(Repeats)]
  public void HashCode_WithParent(string name, string parent)
      => _checks.HashCode(
        () => new DualDeclAst(AstNulls.At, name) { Parent = new(AstNulls.At, parent) });

  [Theory, RepeatData(Repeats)]
  public void String_WithParent(string name, string parent)
    => _checks.Text(
      () => new DualDeclAst(AstNulls.At, name) { Parent = new(AstNulls.At, parent) },
      $"( !D {name} : {parent} )");

  [Theory, RepeatData(Repeats)]
  public void Equality_WithParent(string name, string parent)
    => _checks.Equality(
      () => new DualDeclAst(AstNulls.At, name) { Parent = new(AstNulls.At, parent) });

  [SkippableTheory, RepeatData(Repeats)]
  public void Inequality_BetweenParent(string name, string parent1, string parent2)
    => _checks.InequalityBetween(parent1, parent2,
      parent => new DualDeclAst(AstNulls.At, name) { Parent = new(AstNulls.At, parent) },
      parent1 == parent2);

  [Theory, RepeatData(Repeats)]
  public void HashCode_WithFields(string name, FieldInput[] fields)
      => _checks.HashCode(
        () => new DualDeclAst(AstNulls.At, name) { Fields = fields.DualFields() });

  [Theory, RepeatData(Repeats)]
  public void String_WithFields(string name, FieldInput[] fields)
    => _checks.Text(
      () => new DualDeclAst(AstNulls.At, name) { Fields = fields.DualFields() },
      $"( !D {name} {{ {fields.Joined(fi => $"!DF {fi.Name} : {fi.Type}")} }} )");

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
      $"( !D {name} < {typeParameters.Joined(s => "$" + s)} > )");

  [Theory, RepeatData(Repeats)]
  public void Equality_WithTypeParameters(string name, string[] typeParameters)
    => _checks.Equality(
      () => new DualDeclAst(AstNulls.At, name) { TypeParameters = typeParameters.TypeParameters() });

  [SkippableTheory, RepeatData(Repeats)]
  public void Inequality_BetweenTypeParameterss(string name, string[] typeParameters1, string[] typeParameters2)
    => _checks.InequalityBetween(typeParameters1, typeParameters2,
      parameters => new DualDeclAst(AstNulls.At, name) { TypeParameters = parameters.TypeParameters() },
      typeParameters1.SequenceEqual(typeParameters2));

  private static DualReferenceAst Reference(string argument)
    => new(AstNulls.At, argument);

  protected override string AbbreviatedString(string input)
    => $"( !D {input} )";

  private readonly AstAliasedChecks<DualDeclAst> _checks
    = new(regex => new DualDeclAst(AstNulls.At, regex));

  internal override IAstAliasedChecks AliasedChecks => _checks;
}
