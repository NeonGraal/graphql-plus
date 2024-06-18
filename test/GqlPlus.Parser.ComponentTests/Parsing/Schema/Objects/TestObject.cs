using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Objects;

namespace GqlPlus.Parsing.Schema.Objects;

public abstract class TestObject
  : BaseAliasedTests<ObjectInput>
{
  [Theory, RepeatData(Repeats)]
  public void WithAlternates_ReturnsCorrectAst(string name, string[] others)
    => ObjectChecks.WithAlternates(name, others);

  [Theory, RepeatData(Repeats)]
  public void WithAlternateComments_ReturnsCorrectAst(string name, AlternateComment[] others)
    => ObjectChecks.WithAlternateComments(name, others);

  [Theory, RepeatData(Repeats)]
  public void WithAlternateModifiers_ReturnsCorrectAst(string name, string[] others)
    => ObjectChecks.WithAlternateModifiers(name, others);

  [Theory, RepeatData(Repeats)]
  public void WithAlternateModifiersBad_ReturnsFalse(string name, string[] others)
    => ObjectChecks.WithAlternateModifiersBad(name, others);

  [Theory, RepeatData(Repeats)]
  public void WithTypeParameters_ReturnsCorrectAst(string name, string other, string[] parameters)
    => ObjectChecks.WithTypeParameters(name, other, parameters);

  [Theory, RepeatData(Repeats)]
  public void WithTypeParameterBad_ReturnsFalse(string name, string other)
    => ObjectChecks.WithTypeParameterBad(name, other);

  [Theory, RepeatData(Repeats)]
  public void WithTypeParametersBad_ReturnsFalse(string name, string other, string[] parameters)
    => ObjectChecks.WithTypeParametersBad(name, other, parameters);

  [Theory, RepeatData(Repeats)]
  public void WithTypeParametersNone_ReturnsFalse(string name, string other)
    => ObjectChecks.WithTypeParametersNone(name, other);

  [Theory, RepeatData(Repeats)]
  public void WithFieldBad_ReturnsFalse(string name, FieldInput[] fields, string fieldName)
    => ObjectChecks.WithFieldBad(name, fields, fieldName);

  [Theory, RepeatData(Repeats)]
  public void WithFields_ReturnsCorrectAst(string name, FieldInput[] fields)
    => ObjectChecks.WithFields(name, fields);

  [Theory, RepeatData(Repeats)]
  public void WithFieldsBad_ReturnsFalse(string name, FieldInput[] fields)
    => ObjectChecks.WithFieldsBad(name, fields);

  [Theory, RepeatData(Repeats)]
  public void WithParentField_ReturnsCorrectAst(string name, string parent, string field, string fieldType)
    => ObjectChecks.WithParentField(name, parent, field, fieldType);

  [Theory, RepeatData(Repeats)]
  public void WithParentFieldBad_ReturnsFalse(string name, string parent, string field, string fieldType)
    => ObjectChecks.WithParentFieldBad(name, parent, field, fieldType);

  [Theory, RepeatData(Repeats)]
  public void WithParentGenericFieldBad_ReturnsFalse(string name, string parent, string subType, string field, string fieldType)
    => ObjectChecks.WithParentGenericFieldBad(name, parent, subType, field, fieldType);

  [Theory, RepeatData(Repeats)]
  public void WithFieldsAndAlternates_ReturnsCorrectAst(string name, FieldInput[] fields, string[] others)
    => ObjectChecks.WithFieldsAndAlternates(name, fields, others);

  [Theory, RepeatData(Repeats)]
  public void WithFieldsBadAndAlternates_ReturnsFalse(string name, FieldInput[] fields, string[] others)
    => ObjectChecks.WithFieldsBadAndAlternates(name, fields, others);

  [Theory, RepeatData(Repeats)]
  public void WithFieldsAndAlternatesBad_ReturnsFalse(string name, FieldInput[] fields, string[] others)
    => ObjectChecks.WithFieldsAndAlternatesBad(name, fields, others);

  internal abstract ICheckObject ObjectChecks { get; }

  internal sealed override IBaseAliasedChecks<ObjectInput> AliasChecks => ObjectChecks;
}

public record struct ObjectInput(string Name, string Other);

internal sealed class CheckObject<TObject, TObjField, TObjFieldAst, TObjAlt, TObjAltAst, TObjBase, TObjBaseAst>
  : BaseAliasedChecks<ObjectInput, TObject>, ICheckObject
  where TObject : AstObject<TObjField, TObjAlt, TObjBase>
  where TObjField : IGqlpObjField<TObjBase>
  where TObjFieldAst : AstObjField<TObjBase>, TObjField
  where TObjAlt : IGqlpObjAlternate<TObjBase>
  where TObjAltAst : AstObjAlternate<TObjBase>, TObjAlt
  where TObjBase : IGqlpObjBase<TObjBase>, IEquatable<TObjBase>
  where TObjBaseAst : AstObjBase<TObjBase>, TObjBase
{
  private readonly IObjectFactories<TObject, TObjField, TObjFieldAst, TObjAlt, TObjAltAst, TObjBase, TObjBaseAst> _factories;

  internal CheckObject(IObjectFactories<TObject, TObjField, TObjFieldAst, TObjAlt, TObjAltAst, TObjBase, TObjBaseAst> factories, Parser<TObject>.D parser)
    : base(parser)
    => _factories = factories;

  public void WithNameBad(decimal id, string[] others)
      => False($"{id}{{" + others.Joined(s => "|" + s) + "}");

  public void WithAlternates(string name, string[] others)
    => TrueExpected(
      name + "{" + others.Joined(s => "|" + s) + "}",
       Object(name) with {
         Alternates = [.. others.Select(ObjAlternate)],
       });

  public void WithFieldsAndAlternates(string name, FieldInput[] fields, string[] others)
    => TrueExpected(
      name + "{" + fields.Select(f => f.Name + ":" + f.Type).Joined() + others.Joined(s => "|" + s) + "}",
       Object(name) with {
         Fields = [.. fields.Select(f => ObjField(f.Name, f.Type))],
         Alternates = [.. others.Select(ObjAlternate)],
       });

  public void WithFieldsBadAndAlternates(string name, FieldInput[] fields, string[] others)
    => False(name + "{" + fields.Select(f => f.Name + " " + f.Type).Joined() + others.Joined(s => "|" + s) + "}");

  public void WithFieldsAndAlternatesBad(string name, FieldInput[] fields, string[] others)
    => False(name + "{" + fields.Select(f => f.Name + ":" + f.Type).Joined() + "||" + others.Joined(s => "|" + s) + "}");

  public void WithAlternateComments(string name, AlternateComment[] others)
    => TrueExpected(
      name + "{" + others.Select(o => $"|'{o.Content}'{o.Alternate}").Joined() + "}",
       Object(name) with {
         Alternates = [.. others.Select(o => ObjAlternate(ObjBase(o.Alternate, o.Content)))],
       });

  public void WithAlternateModifiers(string name, string[] others)
    => TrueExpected(
      name + "{" + others.Joined(a => $"|{a}[][String]") + "}",
       Object(name) with {
         Alternates = [.. others.Select(a => ObjAlternate(a) with { Modifiers = TestCollections() })],
       });

  public void WithAlternateModifiersBad(string name, string[] others)
    => False(name + "{" + others.Joined(a => $"|{a}[?]") + "}");

  public void WithTypeParameters(string name, string other, string[] parameters)
    => TrueExpected(
      name + "<" + parameters.Joined(s => "$" + s) + ">{|" + other + "}",
       Object(name) with {
         Alternates = [ObjAlternate(other)],
         TypeParameters = parameters.TypeParameters(),
       });

  public void WithTypeParameterBad(string name, string other)
    => False(name + "<$>{|" + other);

  public void WithTypeParametersBad(string name, string other, string[] parameters)
    => False(name + "<" + parameters.Joined(s => "$" + s) + "{|" + other);

  public void WithTypeParametersNone(string name, string other)
    => False(name + "<>{|" + other);

  public void WithFieldBad(string name, FieldInput[] fields, string fieldName)
    => False(name + "{" + fields.Select(f => f.Name + ":" + f.Type).Joined() + " " + fieldName + ":}");

  public void WithFields(string name, FieldInput[] fields)
    => TrueExpected(
      name + "{" + fields.Select(f => f.Name + ":" + f.Type).Joined() + "}",
       Object(name) with {
         Fields = [.. fields.Select(f => ObjField(f.Name, f.Type))],
       });

  public void WithFieldsBad(string name, FieldInput[] fields)
    => False(name + "{" + fields.Select(f => f.Name + ":" + f.Type).Joined());

  public void WithParentField(string name, string parent, string field, string fieldType)
    => TrueExpected(
      name + "{:" + parent + " " + field + ":" + fieldType + "}",
       Object(name) with {
         Fields = [ObjField(field, fieldType)],
         Parent = ObjBase(parent),
       });

  public void WithParentFieldBad(string name, string parent, string field, string fieldType)
    => False(name + "{:" + parent + " " + field + ":" + fieldType);

  public void WithParentGenericField(string name, string parent, string subType, string field, string fieldType)
    => TrueExpected(
      name + "{:" + parent + "<" + subType + ">" + field + ":" + fieldType + "}",
       Object(name) with {
         Fields = [ObjField(field, fieldType)],
         Parent = ObjBaseWithArgs(parent, subType),
       });

  public void WithParentGenericFieldBad(string name, string parent, string subType, string field, string fieldType)
    => False(name + "{:" + parent + "<" + subType + " " + field + ":" + fieldType + "}");

  public TObject Object(string name)
    => _factories.Object(AstNulls.At, name);

  public TObjField ObjField(string field, string baseType)
    => _factories.ObjField(AstNulls.At, field, ObjBase(baseType));

  public TObjField ObjField(string field, TObjBase baseType)
    => _factories.ObjField(AstNulls.At, field, baseType);

  public TObjAltAst ObjAlternate(string baseType)
    => _factories.ObjAlternate(AstNulls.At, ObjBase(baseType));

  public TObjAlt ObjAlternate(TObjBase baseType)
    => _factories.ObjAlternate(AstNulls.At, baseType);

  public TObjBaseAst ObjBase(string type, string description = "")
    => _factories.ObjBase(AstNulls.At, type, description);

  public TObjBase ObjBaseWithArgs(string type, string subType)
    => ObjBase(type) with { TypeArguments = [ObjBase(subType)] };

  protected internal sealed override string AliasesString(ObjectInput input, string aliases)
    => input.Name + aliases + "{|" + input.Other + "}";
  protected internal sealed override TObject NamedFactory(ObjectInput input)
    => Object(input.Name) with { Alternates = [ObjAlternate(input.Other)] };
}

public record struct AlternateComment(string Content, string Alternate);

internal interface ICheckObject
  : IBaseAliasedChecks<ObjectInput>
{
  void WithNameBad(decimal id, string[] others);
  void WithTypeParameters(string name, string other, string[] typeParameters);
  void WithTypeParameterBad(string name, string other);
  void WithTypeParametersBad(string name, string other, string[] typeParameters);
  void WithTypeParametersNone(string name, string other);
  void WithParentField(string name, string parent, string field, string fieldType);
  void WithParentFieldBad(string name, string parent, string field, string fieldType);
  void WithParentGenericField(string name, string parent, string subType, string field, string fieldType);
  void WithParentGenericFieldBad(string name, string parent, string subType, string field, string fieldType);
  void WithAlternates(string name, string[] others);
  void WithAlternateComments(string name, AlternateComment[] others);
  void WithAlternateModifiers(string name, string[] others);
  void WithAlternateModifiersBad(string name, string[] others);
  void WithFieldBad(string name, FieldInput[] fields, string fieldName);
  void WithFields(string name, FieldInput[] fields);
  void WithFieldsBad(string name, FieldInput[] fields);
  void WithFieldsAndAlternates(string name, FieldInput[] fields, string[] others);
  void WithFieldsBadAndAlternates(string name, FieldInput[] fields, string[] others);
  void WithFieldsAndAlternatesBad(string name, FieldInput[] fields, string[] others);
}
