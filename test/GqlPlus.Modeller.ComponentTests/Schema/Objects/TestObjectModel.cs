﻿using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Objects;

namespace GqlPlus.Schema.Objects;

public abstract class TestObjectModel<TObject, TObjField, TModel>(
  ICheckObjectModel<TObject, TObjField, TModel> objectChecks
) : TestTypeModel<IGqlpObjBase, string, TypeKindModel, TModel>(objectChecks)
  where TObject : IGqlpObject<TObjField>
  where TObjField : IGqlpObjField
  where TModel : IModelBase
{
  [Theory, RepeatData]
  public void Model_ParentDual(string name, string parent)
    => objectChecks
      .AddTypeKinds(TypeKindModel.Dual, parent)
      .ObjectExpected(new(name, parent), objectChecks.DualParent);

  [Theory, RepeatData]
  public void Model_Alternate(string name, AlternateInput alternate)
    => objectChecks.ObjectExpected(new(name, alternates: [alternate]));

  [Theory, RepeatData]
  public void Model_AlternateParent(string name, string parent, AlternateInput alternate)
    => objectChecks
      .AddParent(objectChecks.NewParent(parent, [alternate]))
      .ParentExpected(new(name, parent, alternates: [alternate]));

  [Theory, RepeatData]
  public void Model_AlternateTypeParam(string name, AlternateInput alternate)
    => objectChecks.ObjectExpected(new(name, alternates: [alternate.MakeTypeParam()]));

  [Theory, RepeatData]
  public void Model_Alternates(string name, AlternateInput[] alternates)
    => objectChecks.ObjectExpected(new(name, alternates: alternates));

  [Theory, RepeatData]
  public void Model_Field(string name, FieldInput field)
    => objectChecks.ObjectExpected(new(name, fields: [field]));

  [Theory, RepeatData]
  public void Model_FieldParent(string name, string parent, FieldInput field)
    => objectChecks
      .AddParent(objectChecks.NewParent(parent, [field]))
      .ParentExpected(new(name, parent, fields: [field]));

  [Theory, RepeatData]
  public void Model_FieldTypeParam(string name, FieldInput field)
    => objectChecks.ObjectExpected(new(name, fields: [field.MakeTypeParam()]));

  [Theory, RepeatData]
  public void Model_Fields(string name, FieldInput[] fields)
    => objectChecks.ObjectExpected(new(name, fields: fields));

  [Theory, RepeatData]
  public void Model_FieldsDual(string name, FieldInput[] fields)
    => objectChecks
      .AddTypeKinds(fields.Select(f => f.Type), TypeKindModel.Dual)
      .ObjectExpected(
        new(name, fields: fields),
        field: objectChecks.DualField);

  [Theory, RepeatData]
  public void Model_TypeParam(string name, string typeParam)
    => objectChecks
      .AddTypeKinds(BuiltIn.Internal, TypeKindModel.Internal)
      .ObjectExpected(new(name, typeParams: [typeParam]));

  [Theory, RepeatData]
  public void Model_TypeParams(string name, string[] typeParams)
    => objectChecks
      .AddTypeKinds(BuiltIn.Internal, TypeKindModel.Internal)
      .ObjectExpected(new(name, typeParams: typeParams));

  [Theory, RepeatData]
  public void Model_All(string name, string contents, string parent, string[] aliases, FieldInput[] fields, AlternateInput[] alternates, string[] typeParams)
    => objectChecks
      .AddTypeKinds(BuiltIn.Internal, TypeKindModel.Internal)
      .ObjectExpected(new(name, parent, typeParams, fields, alternates, aliases, contents));
}

internal abstract class CheckObjectModel<TObject, TObjectAst, TObjField, TObjFieldAst, TObjAltAst, TModel>(
  CheckTypeInputs<TObject, TModel> inputs,
  TypeKindModel kind
) : CheckTypeModel<IGqlpObjBase, string, TObject, TypeKindModel, TModel>(inputs, kind),
    ICheckObjectModel<TObject, TObjField, TModel>
  where TObject : IGqlpObject<TObjField>
  where TObjectAst : AstObject<TObjField>, TObject
  where TObjField : IGqlpObjField
  where TObjFieldAst : AstObjField, TObjField
  where TObjAltAst : ObjAlternateAst
  where TModel : BaseTypeModel
{
  internal string[] ExpectedObject(ExpectedObjectInput input)
    => input.Expected(TypeKind, ExpectedParent);

  internal IEnumerable<string> ExpectedField(FieldInput field)
    => [$"  - !_{TypeKind}Field", "    name: " + field.Name, "    type: !_ObjBase", $"      {TypeParamOrKind(field)}: {field.Type}"];

  internal IEnumerable<string> ExpectedAlternate(AlternateInput alternate)
    => ["  - !_ObjAlternate", "    collections:", "      - !_Modifier", "        modifierKind: !_ModifierKind List", "    type: !_ObjBase", $"      {TypeParamOrKind(alternate)}: {alternate.Type}"];

  internal IEnumerable<string> ExpectedTypeParam(string typeParam)
    => ["  - !_TypeParam",
        "    constraint: !_TypeRef(_TypeKind)", "      name: _Any", "      typeKind: !_TypeKind Internal",
        "    name: " + typeParam];

  protected override string[] ExpectedParent(string? parent)
    => parent is null ? []
    : ["parent: !_ObjBase", $"  name: {parent}"];

  protected override string[] ExpectedType(ExpectedTypeInput<string> input)
    => ExpectedObject(new(input));

  internal override TObjectAst NewTypeAst(string name, IGqlpObjBase? parent = default, string? description = null, string[]? aliases = null)
    => NewObjectAst(new(name, description: description, aliases: aliases), parent);

  void ICheckObjectModel<TObject, TObjField, TModel>.ObjectExpected(ExpectedObjectInput input,
      ToExpected<string?>? parent, ToExpected<FieldInput>? field, ToExpected<AlternateInput>? alternate)
    => AstExpected(NewObjectAst(input), input.Expected(TypeKind, parent ?? ExpectedParent,
      ItemsExpected("typeParams:", input.TypeParams, ExpectedTypeParam),
      ItemsExpected("fields:", input.Fields, field ?? ExpectedField),
      ItemsExpected("allFields:", input.Fields, ExpectedObject(input.Name, field ?? ExpectedField)),
      ItemsExpected("alternates:", input.Alternates, alternate ?? ExpectedAlternate),
      ItemsExpected("allAlternates:", input.Alternates, ExpectedObject(input.Name, alternate ?? ExpectedAlternate))));
  string[] ICheckObjectModel<TObject, TObjField, TModel>.DualField(FieldInput field)
    => [$"  - !_{TypeKind}Field", "    name: " + field.Name, "    type: !_ObjBase",
        (field.TypeParam ? "      typeParam: " : "      name: ") + field.Type];
  string[] ICheckObjectModel<TObject, TObjField, TModel>.DualAlternate(AlternateInput alternate)
    => alternate.TypeParam
    ? [$"  - !_TypeParam " + alternate.Type]
    : ["  - !_ObjAlternate", "    collections:", "      - !_Modifier", "        modifierKind: !_ModifierKind List", "    type: !_ObjBase", "      name: " + alternate.Type];
  string[] ICheckObjectModel<TObject, TObjField, TModel>.DualParent(string? parent)
    => parent is null ? []
    : ["parent: !_ObjBase", "  name: " + parent];
  string[] ICheckObjectModel<TObject, TObjField, TModel>.TypeParamParent(string? parent)
    => parent is null ? []
    : ["parent: !_TypeParam " + parent];

  private ToExpected<TInput> ExpectedObject<TInput>(string name, ToExpected<TInput> expectedField)
    => f => {
      string[] value = [.. expectedField(f)];
      string[] field = value;

      string first = "  - !_ObjectFor(" + field[0][5..] + ")";
      int index = Array.FindIndex(field, f => f.StartsWith("    ", StringComparison.Ordinal) && string.CompareOrdinal(f, "    o") > 0);
      int typeAt = index < 1 ? 0 : field.Length - index;
      IEnumerable<string> last = field.TakeLast(typeAt);

      return [first, .. field.Skip(1).SkipLast(typeAt), "    object: " + name, .. last];
    };

  void ICheckObjectModel<TObject, TObjField, TModel>.ParentExpected(ExpectedObjectInput input)
    => AstExpected(NewObjectAst(new(input.Name, input.Parent)), input.Expected(TypeKind, ExpectedParent, [],
      [], ItemsExpected("allFields:", input.Fields, ExpectedObject<FieldInput>(input.Parent!, ExpectedField)),
      [], ItemsExpected("allAlternates:", input.Alternates, ExpectedObject<AlternateInput>(input.Parent!, ExpectedAlternate))));

  TObject ICheckObjectModel<TObject, TObjField, TModel>.ObjectAst(ExpectedObjectInput input)
    => NewObjectAst(input);

  BaseTypeModel IParentModel<FieldInput>.NewParent(string name, FieldInput[] items, string? parent)
    => NewParentModel(name, parent, items, []);
  BaseTypeModel IParentModel<AlternateInput>.NewParent(string name, AlternateInput[] items, string? parent)
    => NewParentModel(name, parent, [], items);

  private BaseTypeModel NewParentModel(string name, string? parent, FieldInput[] fields, AlternateInput[] alternates)
    => _modeller.ToModel<TModel>(NewObjectAst(new(name, parent, fields: fields, alternates: alternates)), TypeKinds);

  protected abstract TObjectAst NewObjectAst(ExpectedObjectInput input, IGqlpObjBase? parent = default);
}

public interface ICheckObjectModel<TObject, TObjField, TModel>
  : ICheckTypeModel<IGqlpObjBase, string, TypeKindModel, TModel>
  , IParentModel<FieldInput>, IParentModel<AlternateInput>
  where TObject : IGqlpObject<TObjField>
  where TObjField : IGqlpObjField
  where TModel : IModelBase
{
  void ObjectExpected(ExpectedObjectInput input, ToExpected<string?>? parent = null,
    ToExpected<FieldInput>? field = null, ToExpected<AlternateInput>? alternate = null);
  string[] DualParent(string? parent);
  string[] DualField(FieldInput field);
  string[] DualAlternate(AlternateInput alternate);
  string[] TypeParamParent(string? parent);

  void ParentExpected(ExpectedObjectInput input);
  TObject ObjectAst(ExpectedObjectInput input);
}

public sealed class ExpectedObjectInput(
  string name,
  string? parent = null,
  string[]? typeParams = null,
  FieldInput[]? fields = null,
  AlternateInput[]? alternates = null,
  IEnumerable<string>? aliases = null,
  string? description = null
) : ExpectedTypeInput<string>(name, parent, aliases, description)
{
  internal string[] TypeParams { get; } = typeParams ?? [];
  internal FieldInput[] Fields { get; } = fields ?? [];
  internal AlternateInput[] Alternates { get; } = alternates ?? [];

  internal ExpectedObjectInput(ExpectedTypeInput<string> input)
    : this(input.Name, input.Parent)
  {
    Aliases = input.Aliases;
    ExpectedAliases = input.ExpectedAliases;
    Description = input.Description;
    ExpectedDescription = input.ExpectedDescription;
  }

  internal string[] Expected(
    TypeKindModel typeKind,
    ToExpected<string?> parent,
    IEnumerable<string>? typeParams = null,
    IEnumerable<string>? fields = null,
    IEnumerable<string>? allFields = null,
    IEnumerable<string>? alternates = null,
    IEnumerable<string>? allAlternates = null)
    => [$"!_Type{typeKind}",
      .. ExpectedAliases,
      .. allAlternates ?? [],
      .. allFields ?? [],
      .. alternates ?? [],
      .. ExpectedDescription,
      .. fields ?? [],
      "name: " + Name,
      .. parent(Parent),
      $"typeKind: !_TypeKind {typeKind}",
      .. typeParams ?? []];
}
