using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Objects;
using GqlPlus.Parsing.Schema.Objects;

namespace GqlPlus.Parser.Schema.Objects;

public abstract class TestObject<TObject>(
  ICheckObject<TObject> objectChecks
) : BaseAliasedTests<ObjectInput, TObject>(objectChecks)
where TObject : IGqlpObject
{
  [Theory, RepeatData]
  public void WithAlternates_ReturnsCorrectAst(string name, string[] others)
    => objectChecks.WithAlternates(name, others);

  [Theory, RepeatData]
  public void WithAlternateComments_ReturnsCorrectAst(string name, AlternateComment[] others)
    => objectChecks.WithAlternateComments(name, others);

  [Theory, RepeatData]
  public void WithAlternateModifiers_ReturnsCorrectAst(string name, string[] others)
    => objectChecks.WithAlternateModifiers(name, others);

  [Theory, RepeatData]
  public void WithAlternateModifiersBad_ReturnsFalse(string name, string[] others)
    => objectChecks.WithAlternateModifiersBad(name, others);

  [Theory, RepeatData]
  public void WithTypeParams_ReturnsCorrectAst(string name, string other, string[] parameters)
    => objectChecks
      .WithTypeParams(name, other, parameters);

  [Theory, RepeatData]
  public void WithTypeParamBad_ReturnsFalse(string name, string other)
    => objectChecks.WithTypeParamBad(name, other);

  [Theory, RepeatData]
  public void WithTypeParamsBad_ReturnsFalse(string name, string other, string[] parameters)
    => objectChecks.WithTypeParamsBad(name, other, parameters);

  [Theory, RepeatData]
  public void WithTypeParamsNone_ReturnsFalse(string name, string other)
    => objectChecks.WithTypeParamsNone(name, other);

  [Theory, RepeatData]
  public void WithFieldBad_ReturnsFalse(string name, FieldInput[] fields, string fieldName)
    => objectChecks.WithFieldBad(name, fields, fieldName);

  [Theory, RepeatData]
  public void WithFields_ReturnsCorrectAst(string name, FieldInput[] fields)
    => objectChecks.WithFields(name, fields);

  [Theory, RepeatData]
  public void WithFieldsBad_ReturnsFalse(string name, FieldInput[] fields)
    => objectChecks.WithFieldsBad(name, fields);

  [Theory, RepeatData]
  public void WithParentField_ReturnsCorrectAst(string name, string parent, string field, string fieldType)
    => objectChecks.WithParentField(name, parent, field, fieldType);

  [Theory, RepeatData]
  public void WithParentFieldBad_ReturnsFalse(string name, string parent, string field, string fieldType)
    => objectChecks.WithParentFieldBad(name, parent, field, fieldType);

  [Theory, RepeatData]
  public void WithParentGenericFieldBad_ReturnsFalse(string name, string parent, string subType, string field, string fieldType)
    => objectChecks.WithParentGenericFieldBad(name, parent, subType, field, fieldType);

  [Theory, RepeatData]
  public void WithFieldsAndAlternates_ReturnsCorrectAst(string name, FieldInput[] fields, string[] others)
    => objectChecks.WithFieldsAndAlternates(name, fields, others);

  [Theory, RepeatData]
  public void WithFieldsBadAndAlternates_ReturnsFalse(string name, FieldInput[] fields, string[] others)
    => objectChecks.WithFieldsBadAndAlternates(name, fields, others);

  [Theory, RepeatData]
  public void WithFieldsAndAlternatesBad_ReturnsFalse(string name, FieldInput[] fields, string[] others)
    => objectChecks.WithFieldsAndAlternatesBad(name, fields, others);
}

public record struct ObjectInput(string Name, string Other);

internal class CheckObject<TObject, TObjectAst, TObjField, TObjFieldAst>
  : BaseAliasedChecks<ObjectInput, TObjectAst, TObject>
  , ICheckObject<TObject>
  where TObject : IGqlpObject<TObjField>
  where TObjectAst : AstObject<TObjField>, TObject
  where TObjField : IGqlpObjField
  where TObjFieldAst : AstObjField, TObjField
{
  private readonly IObjectFactories<TObjectAst, TObjField, TObjFieldAst> _factories;

  internal CheckObject(IObjectFactories<TObjectAst, TObjField, TObjFieldAst> factories, Parser<TObject>.D parser)
    : base(parser)
    => _factories = factories;

  public void WithNameBad(decimal id, string[] others)
      => FalseExpected($"{id}{{" + others.Joined(s => "|" + s) + "}");

  public void WithAlternates(string name, string[] others)
    => TrueExpected(
      name + "{" + others.Joined(s => "|" + s) + "}",
       Object(name) with {
         Alternates = [.. others.Select(Alternate)],
       });

  public void WithFieldsAndAlternates(string name, FieldInput[] fields, string[] others)
    => TrueExpected(
      name + "{" + fields.Select(f => f.Name + ":" + f.Type).Joined() + others.Joined(s => "|" + s) + "}",
       Object(name) with {
         ObjFields = [.. fields.Select(f => ObjField(f.Name, f.Type))],
         Alternates = [.. others.Select(Alternate)],
       });

  public void WithFieldsBadAndAlternates(string name, FieldInput[] fields, string[] others)
    => FalseExpected(name + "{" + fields.Select(f => f.Name + " " + f.Type).Joined() + others.Joined(s => "|" + s) + "}");

  public void WithFieldsAndAlternatesBad(string name, FieldInput[] fields, string[] others)
    => FalseExpected(name + "{" + fields.Select(f => f.Name + ":" + f.Type).Joined() + "||" + others.Joined(s => "|" + s) + "}");

  public void WithAlternateComments(string name, AlternateComment[] others)
    => TrueExpected(
      name + "{" + others.Select(o => $"|'{o.Content}'{o.Alternate}").Joined() + "}",
       Object(name) with {
         Alternates = [.. others.Select(o => Alternate(o.Alternate) with { Description = o.Content })],
       });

  public void WithAlternateModifiers(string name, string[] others)
    => TrueExpected(
      name + "{" + others.Joined(a => $"|{a}[][String]") + "}",
       Object(name) with {
         Alternates = [.. others.Select(a => Alternate(a) with { Modifiers = TestCollections() })],
       });

  public void WithAlternateModifiersBad(string name, string[] others)
    => FalseExpected(name + "{" + others.Joined(a => $"|{a}[?]") + "}");

  public void WithTypeParams(string name, string other, string[] parameters)
    => TrueExpected(
      name + "<" + parameters.Joined(s => "$" + s + ":_Any") + ">{|" + other + "}",
       Object(name) with {
         Alternates = [Alternate(other)],
         TypeParams = parameters.TypeParams(),
       });

  public void WithTypeParamBad(string name, string other)
    => FalseExpected(name + "<$>{|" + other);

  public void WithTypeParamsBad(string name, string other, string[] parameters)
    => FalseExpected(name + "<" + parameters.Joined(s => "$" + s) + "{|" + other);

  public void WithTypeParamsNone(string name, string other)
    => FalseExpected(name + "<>{|" + other);

  public void WithFieldBad(string name, FieldInput[] fields, string fieldName)
    => FalseExpected(name + "{" + fields.Select(f => f.Name + ":" + f.Type).Joined() + " " + fieldName + ":}");

  public void WithFields(string name, FieldInput[] fields)
    => TrueExpected(
      name + "{" + fields.Select(f => f.Name + ":" + f.Type).Joined() + "}",
       Object(name) with {
         ObjFields = [.. fields.Select(f => ObjField(f.Name, f.Type))],
       });

  public void WithFieldsBad(string name, FieldInput[] fields)
    => FalseExpected(name + "{" + fields.Select(f => f.Name + ":" + f.Type).Joined());

  public void WithParentField(string name, string parent, string field, string fieldType)
    => TrueExpected(
      name + "{:" + parent + " " + field + ":" + fieldType + "}",
       Object(name) with {
         ObjFields = [ObjField(field, fieldType)],
         Parent = ObjBase(parent),
       });

  public void WithParentFieldBad(string name, string parent, string field, string fieldType)
    => FalseExpected(name + "{:" + parent + " " + field + ":" + fieldType);

  public void WithParentGenericField(string name, string parent, string subType, string field, string fieldType)
    => TrueExpected(
      name + "{:" + parent + "<" + subType + ">" + field + ":" + fieldType + "}",
       Object(name) with {
         ObjFields = [ObjField(field, fieldType)],
         Parent = ObjBaseWithArgs(parent, subType),
       });

  public void WithParentGenericFieldBad(string name, string parent, string subType, string field, string fieldType)
    => FalseExpected(name + "{:" + parent + "<" + subType + " " + field + ":" + fieldType + "}");

  public TObjectAst Object(string name)
    => _factories.Object(AstNulls.At, name);

  public TObjField ObjField(string field, string baseType)
    => _factories.ObjField(AstNulls.At, field, ObjBase(baseType));

  public TObjField ObjField(string field, IGqlpObjBase baseType)
    => _factories.ObjField(AstNulls.At, field, baseType);

  public static AlternateAst Alternate(string baseType)
    => new(AstNulls.At, baseType, "");

  public static ObjBaseAst ObjBase(string type, string description = "")
    => new(AstNulls.At, type, description);

  public static IGqlpObjBase ObjBaseWithArgs(string type, string subType)
    => ObjBase(type) with { Args = [TypeArg(subType)] };

  public static TypeArgAst TypeArg(string type, string description = "")
    => new(AstNulls.At, type, description);

  protected internal sealed override string AliasesString(ObjectInput input, string aliases)
    => input.Name + aliases + "{|" + input.Other + "}";
  protected internal sealed override TObjectAst NamedFactory(ObjectInput input)
    => Object(input.Name) with { Alternates = [Alternate(input.Other)] };
}

public record struct AlternateComment(string Content, string Alternate);

public interface ICheckObject<TObject>
  : IBaseAliasedChecks<ObjectInput, TObject>
where TObject : IGqlpObject
{
  void WithNameBad(decimal id, string[] others);
  void WithTypeParams(string name, string other, string[] typeParams);
  void WithTypeParamBad(string name, string other);
  void WithTypeParamsBad(string name, string other, string[] typeParams);
  void WithTypeParamsNone(string name, string other);
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
