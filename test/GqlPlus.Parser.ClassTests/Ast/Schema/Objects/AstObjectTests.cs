using System.Runtime.CompilerServices;
using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Ast.Schema.Objects;

public abstract class AstObjectTests
  : AstTypeTests
{
  [Theory, RepeatData]
  public void HashCode_WithAlternates(string name, AlternateInput[] alternates)
    => ObjectChecks.HashCode_WithAlternates(name, alternates);
  [Theory, RepeatData]
  public void String_WithAlternates(string name, AlternateInput[] alternates)
    => ObjectChecks.String_WithAlternates(name, alternates);
  [Theory, RepeatData]
  public void Equality_WithAlternates(string name, AlternateInput[] alternates)
    => ObjectChecks.Equality_WithAlternates(name, alternates);
  [Theory, RepeatData]
  public void Inequality_BetweenAlternates(string name, AlternateInput[] alternates1, AlternateInput[] alternates2)
    => ObjectChecks.Inequality_BetweenAlternates(name, alternates1, alternates2);

  [Theory, RepeatData]
  public void HashCode_WithFields(string name, FieldInput[] fields)
      => ObjectChecks.HashCode_WithFields(name, fields);
  [Theory, RepeatData]
  public void String_WithFields(string name, FieldInput[] fields)
    => ObjectChecks.String_WithFields(name, fields);
  [Theory, RepeatData]
  public void Equality_WithFields(string name, FieldInput[] fields)
    => ObjectChecks.Equality_WithFields(name, fields);
  [Theory, RepeatData]
  public void Inequality_BetweenFields(string name, FieldInput[] fields1, FieldInput[] fields2)
    => ObjectChecks.Inequality_BetweenFields(name, fields1, fields2);

  [Theory, RepeatData]
  public void HashCode_WithTypeParams(string name, string[] typeParams)
      => ObjectChecks.HashCode_WithTypeParams(name, typeParams);
  [Theory, RepeatData]
  public void String_WithTypeParams(string name, string[] typeParams)
    => ObjectChecks.String_WithTypeParams(name, typeParams);
  [Theory, RepeatData]
  public void Equality_WithTypeParams(string name, string[] typeParams)
    => ObjectChecks.Equality_WithTypeParams(name, typeParams);
  [Theory, RepeatData]
  public void Inequality_BetweenTypeParamss(string name, string[] typeParams1, string[] typeParams2)
    => ObjectChecks.Inequality_BetweenTypeParamss(name, typeParams1, typeParams2);

  protected override string ParentString(string name, string parent)
    => $"( !{TypeChecks.Abbr} {name} : {parent} )";

  internal override IAstTypeChecks TypeChecks => ObjectChecks;

  internal abstract IAstObjectChecks ObjectChecks { get; }
}

internal abstract class AstObjectChecks<TObjectAst, TObjBase, TObjField, TObjAlt>(
BaseAstChecks<TObjectAst>.CreateBy<string> createInput,
AstTypeChecks<TObjectAst, IGqlpObjBase>.ParentCreator createParent,
  [CallerArgumentExpression(nameof(createInput))] string createExpression = ""
) : AstTypeChecks<TObjectAst, IGqlpObjBase>(createInput, createParent, createExpression)
  , IAstObjectChecks
  where TObjectAst : AstObject<TObjBase, TObjField, TObjAlt>
  where TObjBase : IGqlpObjBase
  where TObjField : IGqlpObjField
  where TObjAlt : IGqlpObjAlternate
{
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

  public void HashCode_WithTypeParams(string name, string[] typeParams)
      => HashCode(
        () => CreateInput(name) with { TypeParams = typeParams.TypeParams() });
  public void String_WithTypeParams(string name, string[] typeParams)
    => Text(
      () => CreateInput(name) with { TypeParams = typeParams.TypeParams() },
      $"( !{Abbr} {name} < {typeParams.Joined(s => "$" + s + " :_Any")} > )");
  public void Equality_WithTypeParams(string name, string[] typeParams)
    => Equality(
      () => CreateInput(name) with { TypeParams = typeParams.TypeParams() });
  public void Inequality_BetweenTypeParamss(string name, string[] typeParams1, string[] typeParams2)
    => InequalityBetween(typeParams1, typeParams2,
      parameters => CreateInput(name) with { TypeParams = parameters.TypeParams() },
      typeParams1.SequenceEqual(typeParams2));

  protected abstract TObjAlt[] CreateAlternates(IEnumerable<AlternateInput> alternates);
  protected string AlternateString(AlternateInput input)
    => $"{input.Type} [] ?";

  protected abstract TObjField[] CreateFields(IEnumerable<FieldInput> fields);
  protected abstract string FieldString(FieldInput input);
}

internal interface IAstObjectChecks
  : IAstTypeChecks
{
  void HashCode_WithAlternates(string name, AlternateInput[] alternates);
  void String_WithAlternates(string name, AlternateInput[] alternates);
  void Equality_WithAlternates(string name, AlternateInput[] alternates);
  void Inequality_BetweenAlternates(string name, AlternateInput[] alternates1, AlternateInput[] alternates2);

  void HashCode_WithFields(string name, FieldInput[] fields);
  void String_WithFields(string name, FieldInput[] fields);
  void Equality_WithFields(string name, FieldInput[] fields);
  void Inequality_BetweenFields(string name, FieldInput[] fields1, FieldInput[] fields2);

  void HashCode_WithTypeParams(string name, string[] typeParams);
  void String_WithTypeParams(string name, string[] typeParams);
  void Equality_WithTypeParams(string name, string[] typeParams);
  void Inequality_BetweenTypeParamss(string name, string[] typeParams1, string[] typeParams2);
}
