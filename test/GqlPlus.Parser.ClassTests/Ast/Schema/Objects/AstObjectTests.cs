using System.Runtime.CompilerServices;

using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Ast.Schema.Objects;

public abstract class AstObjectTests
  : AstTypeTests
{
  [Theory, RepeatData(Repeats)]
  public void HashCode_WithAlternates(string name, AlternateInput[] alternates)
    => ObjectChecks.HashCode_WithAlternates(name, alternates);
  [Theory, RepeatData(Repeats)]
  public void String_WithAlternates(string name, AlternateInput[] alternates)
    => ObjectChecks.String_WithAlternates(name, alternates);
  [Theory, RepeatData(Repeats)]
  public void Equality_WithAlternates(string name, AlternateInput[] alternates)
    => ObjectChecks.Equality_WithAlternates(name, alternates);
  [SkippableTheory, RepeatData(Repeats)]
  public void Inequality_BetweenAlternates(string name, AlternateInput[] alternates1, AlternateInput[] alternates2)
    => ObjectChecks.Inequality_BetweenAlternates(name, alternates1, alternates2);

  [Theory, RepeatData(Repeats)]
  public void HashCode_WithFields(string name, FieldInput[] fields)
      => ObjectChecks.HashCode_WithFields(name, fields);
  [Theory, RepeatData(Repeats)]
  public void String_WithFields(string name, FieldInput[] fields)
    => ObjectChecks.String_WithFields(name, fields);
  [Theory, RepeatData(Repeats)]
  public void Equality_WithFields(string name, FieldInput[] fields)
    => ObjectChecks.Equality_WithFields(name, fields);
  [SkippableTheory, RepeatData(Repeats)]
  public void Inequality_BetweenFields(string name, FieldInput[] fields1, FieldInput[] fields2)
    => ObjectChecks.Inequality_BetweenFields(name, fields1, fields2);

  [Theory, RepeatData(Repeats)]
  public void HashCode_WithTypeParameters(string name, string[] typeParameters)
      => ObjectChecks.HashCode_WithTypeParameters(name, typeParameters);
  [Theory, RepeatData(Repeats)]
  public void String_WithTypeParameters(string name, string[] typeParameters)
    => ObjectChecks.String_WithTypeParameters(name, typeParameters);
  [Theory, RepeatData(Repeats)]
  public void Equality_WithTypeParameters(string name, string[] typeParameters)
    => ObjectChecks.Equality_WithTypeParameters(name, typeParameters);
  [SkippableTheory, RepeatData(Repeats)]
  public void Inequality_BetweenTypeParameterss(string name, string[] typeParameters1, string[] typeParameters2)
    => ObjectChecks.Inequality_BetweenTypeParameterss(name, typeParameters1, typeParameters2);

  protected override string ParentString(string name, string parent)
    => $"( !{TypeChecks.Abbr} {name} : {parent} )";

  internal override IAstTypeChecks TypeChecks => ObjectChecks;

  internal abstract IAstObjectChecks ObjectChecks { get; }
}

internal abstract class AstObjectChecks<TObjectAst, TObjBase, TObjField, TObjAlt>
  : AstTypeChecks<TObjectAst, IGqlpObjBase>
  , IAstObjectChecks
  where TObjectAst : AstObject<TObjBase, TObjField, TObjAlt>
  where TObjBase : IGqlpObjBase
  where TObjField : IGqlpObjField
  where TObjAlt : IGqlpObjAlternate
{
  public AstObjectChecks(
    CreateBy<string> createInput,
    ParentCreator createParent,
    [CallerArgumentExpression(nameof(createInput))] string createExpression = ""
) : base(createInput, createParent, createExpression)
  { }

  public void Equality_WithAlternates(string name, AlternateInput[] alternates)
    => Equality(() => CreateInput(name) with { ObjAlternates = CreateAlternates(alternates) });
  public void HashCode_WithAlternates(string name, AlternateInput[] alternates)
    => HashCode(() => CreateInput(name) with { ObjAlternates = CreateAlternates(alternates) });
  public void Inequality_BetweenAlternates(string name, AlternateInput[] alternates1, AlternateInput[] alternates2)
    => InequalityBetween(alternates1, alternates2,
      alternates => CreateInput(name) with { ObjAlternates = CreateAlternates(alternates) },
      alternates1.OrderedEqual(alternates2));
  public void String_WithAlternates(string name, AlternateInput[] alternates)
    => Text(
      () => CreateInput(name) with { ObjAlternates = CreateAlternates(alternates) },
      $"( !{Abbr} {name} | {alternates.Joined(AlternateString)} )");

  public void HashCode_WithFields(string name, FieldInput[] fields)
      => HashCode(() => CreateInput(name) with { ObjFields = CreateFields(fields) });
  public void String_WithFields(string name, FieldInput[] fields)
    => Text(
      () => CreateInput(name) with { ObjFields = CreateFields(fields) },
      $"( !{Abbr} {name} {{ {fields.Joined(FieldString)} }} )");
  public void Equality_WithFields(string name, FieldInput[] fields)
    => Equality(() => CreateInput(name) with { ObjFields = CreateFields(fields) });
  public void Inequality_BetweenFields(string name, FieldInput[] fields1, FieldInput[] fields2)
    => InequalityBetween(fields1, fields2,
      fields => CreateInput(name) with { ObjFields = CreateFields(fields) },
      fields1.OrderedEqual(fields2));

  public void HashCode_WithTypeParameters(string name, string[] typeParameters)
      => HashCode(
        () => CreateInput(name) with { TypeParameters = typeParameters.TypeParameters() });
  public void String_WithTypeParameters(string name, string[] typeParameters)
    => Text(
      () => CreateInput(name) with { TypeParameters = typeParameters.TypeParameters() },
      $"( !{Abbr} {name} < {typeParameters.Joined(s => "$" + s)} > )");
  public void Equality_WithTypeParameters(string name, string[] typeParameters)
    => Equality(
      () => CreateInput(name) with { TypeParameters = typeParameters.TypeParameters() });
  public void Inequality_BetweenTypeParameterss(string name, string[] typeParameters1, string[] typeParameters2)
    => InequalityBetween(typeParameters1, typeParameters2,
      parameters => CreateInput(name) with { TypeParameters = parameters.TypeParameters() },
      typeParameters1.SequenceEqual(typeParameters2));

  protected abstract TObjAlt[] CreateAlternates(IEnumerable<AlternateInput> alternates);
  protected abstract string AlternateString(AlternateInput input);

  protected abstract TObjField[] CreateFields(IEnumerable<FieldInput> fields);
  protected abstract string FieldString(FieldInput input);
}

internal interface IAstObjectChecks
  : IAstTypeChecks
{
  public void HashCode_WithAlternates(string name, AlternateInput[] alternates);
  public void String_WithAlternates(string name, AlternateInput[] alternates);
  public void Equality_WithAlternates(string name, AlternateInput[] alternates);
  public void Inequality_BetweenAlternates(string name, AlternateInput[] alternates1, AlternateInput[] alternates2);

  public void HashCode_WithFields(string name, FieldInput[] fields);
  public void String_WithFields(string name, FieldInput[] fields);
  public void Equality_WithFields(string name, FieldInput[] fields);
  public void Inequality_BetweenFields(string name, FieldInput[] fields1, FieldInput[] fields2);

  public void HashCode_WithTypeParameters(string name, string[] typeParameters);
  public void String_WithTypeParameters(string name, string[] typeParameters);
  public void Equality_WithTypeParameters(string name, string[] typeParameters);
  public void Inequality_BetweenTypeParameterss(string name, string[] typeParameters1, string[] typeParameters2);
}
