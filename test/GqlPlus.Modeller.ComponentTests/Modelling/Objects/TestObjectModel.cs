﻿using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Objects;

namespace GqlPlus.Modelling.Objects;

public abstract class TestObjectModel<TObject, TObjBase, TObjField, TObjAlt, TModel>(
  ICheckObjectModel<TObject, TObjBase, TObjField, TObjAlt, TModel> objectChecks
) : TestTypeModel<IGqlpObjBase, string, TypeKindModel, TModel>(objectChecks)
  where TObject : IGqlpObject<TObjBase, TObjField, TObjAlt>
  where TObjField : IGqlpObjField
  where TObjAlt : IGqlpObjAlternate
  where TObjBase : IGqlpObjBase
  where TModel : ITypeObjectModel
{
  [Theory, RepeatData(Repeats)]
  public void Model_ParentDual(string name, string parent)
    => objectChecks
      .AddTypeKinds(TypeKindModel.Dual, parent)
      .ObjectExpected(new(name, parent), objectChecks.DualParent);

  //[Theory, RepeatData(Repeats)]
  //public void Model_ParentTypeParameter(string name, string parent)
  //  => ObjectChecks
  //    .AddTypeKinds(TypeKindModel.Dual, parent)
  //    .ObjectExpected(
  //      ObjectChecks.ObjectAst(name, [], []) with {
  //        Parent = (TObjBaseAst)TypeChecks.ParentAst(parent) with { IsTypeParameter = true }
  //      },
  //      new(name, parent), ObjectChecks.TypeParameterParent);

  [Theory, RepeatData(Repeats)]
  public void Model_Alternate(string name, AlternateInput alternate)
    => objectChecks.ObjectExpected(new(name, alternates: [alternate]));

  [Theory, RepeatData(Repeats)]
  public void Model_AlternateParent(string name, string parent, AlternateInput alternate)
    => objectChecks
      .AddParent(objectChecks.NewParent(parent, [alternate]))
      .ParentExpected(new(name, parent, alternates: [alternate]));

  [Theory, RepeatData(Repeats)]
  public void Model_AlternateTypeParameter(string name, AlternateInput alternate)
    => objectChecks.ObjectExpected(new(name, alternates: [alternate.MakeTypeParameter()]));

  [Theory, RepeatData(Repeats)]
  public void Model_Alternates(string name, AlternateInput[] alternates)
    => objectChecks.ObjectExpected(new(name, alternates: alternates));

  [Theory, RepeatData(Repeats)]
  public void Model_Field(string name, FieldInput field)
    => objectChecks.ObjectExpected(new(name, fields: [field]));

  [Theory, RepeatData(Repeats)]
  public void Model_FieldParent(string name, string parent, FieldInput field)
    => objectChecks
      .AddParent(objectChecks.NewParent(parent, [field]))
      .ParentExpected(new(name, parent, fields: [field]));

  [Theory, RepeatData(Repeats)]
  public void Model_FieldTypeParameter(string name, FieldInput field)
    => objectChecks.ObjectExpected(new(name, fields: [field.MakeTypeParameter()]));

  [Theory, RepeatData(Repeats)]
  public void Model_Fields(string name, FieldInput[] fields)
    => objectChecks.ObjectExpected(new(name, fields: fields));

  [Theory, RepeatData(Repeats)]
  public void Model_FieldsDual(string name, FieldInput[] fields)
    => objectChecks
      .AddTypeKinds(fields.Select(f => f.Type), TypeKindModel.Dual)
      .ObjectExpected(
        new(name, fields: fields),
        field: objectChecks.DualField);

  [Theory, RepeatData(Repeats)]
  public void Model_TypeParameter(string name, string typeParameter)
    => objectChecks
      .ObjectExpected(new(name, typeParameters: [typeParameter]));

  [Theory, RepeatData(Repeats)]
  public void Model_TypeParameters(string name, string[] typeParameters)
    => objectChecks
      .ObjectExpected(new(name, typeParameters: typeParameters));

  [Theory, RepeatData(Repeats)]
  public void Model_All(string name, string contents, string parent, string[] aliases, FieldInput[] fields, AlternateInput[] alternates, string[] typeParameters)
    => objectChecks.ObjectExpected(new(name, parent, typeParameters, fields, alternates, aliases, contents));
}

internal abstract class CheckObjectModel<TObject, TObjectAst, TObjField, TObjFieldAst, TObjAlt, TObjAltAst, TObjBase, TModel>(
  IModeller<TObject, TModel> modeller,
  IRenderer<TModel> rendering,
  TypeKindModel kind
) : CheckTypeModel<IGqlpObjBase, string, TObject, TypeKindModel, TModel>(modeller, rendering, kind),
    ICheckObjectModel<TObject, TObjBase, TObjField, TObjAlt, TModel>
  where TObject : IGqlpObject<TObjBase, TObjField, TObjAlt>
  where TObjectAst : AstObject<TObjBase, TObjField, TObjAlt>, TObject
  where TObjField : IGqlpObjField
  where TObjFieldAst : AstObjField<TObjBase>, TObjField
  where TObjAlt : IGqlpObjAlternate
  where TObjAltAst : AstObjAlternate<TObjBase>, TObjAlt
  where TObjBase : IGqlpObjBase
  where TModel : BaseTypeModel, ITypeObjectModel
{
  internal string[] ExpectedObject(ExpectedObjectInput input)
    => input.Expected(TypeKind, ExpectedParent);

  internal IEnumerable<string> ExpectedField(FieldInput field)
    => field.TypeParameter
        ? [$"- !_{TypeKind}Field", "  name: " + field.Name, "  type: !_TypeParameter " + field.Type]
        : [$"- !_{TypeKind}Field", "  name: " + field.Name, $"  type: !_{TypeKind}Base", $"    {TypeKindLower}: {field.Type}"];

  internal IEnumerable<string> ExpectedAlternate(AlternateInput alternate)
    => alternate.TypeParameter
        ? [$"- !_{TypeKind}Alternate", "  collections:", "  - !_Modifier", "    modifierKind: !_ModifierKind List", "  type: !_TypeParameter " + alternate.Type]
        : [$"- !_{TypeKind}Alternate", "  collections:", "  - !_Modifier", "    modifierKind: !_ModifierKind List", $"  type: !_{TypeKind}Base", $"    {TypeKindLower}: {alternate.Type}"];

  internal IEnumerable<string> ExpectedTypeParameter(string typeParameter)
    => ["- !_Described", "  name: " + typeParameter];

  protected override string[] ExpectedParent(string? parent)
    => parent is null ? []
    : [$"parent: !_{TypeKind}Base", $"  {TypeKindLower}: {parent}"];

  protected override string[] ExpectedType(ExpectedTypeInput<string> input)
    => ExpectedObject(new(input));

  internal override TObjectAst NewTypeAst(string name, IGqlpObjBase? parent = default, string? description = null, string[]? aliases = null)
    => NewObjectAst(new(name, description: description, aliases: aliases), parent);

  void ICheckObjectModel<TObject, TObjBase, TObjField, TObjAlt, TModel>.ObjectExpected(ExpectedObjectInput input,
      ToExpected<string?>? parent, ToExpected<FieldInput>? field, ToExpected<AlternateInput>? alternate)
    => AstExpected(NewObjectAst(input), input.Expected(TypeKind, parent ?? ExpectedParent,
      ItemsExpected("typeParameters:", input.TypeParameters, ExpectedTypeParameter),
      ItemsExpected("fields:", input.Fields, field ?? ExpectedField),
      ItemsExpected("allFields:", input.Fields, ExpectedObject(input.Name, field ?? ExpectedField)),
      ItemsExpected("alternates:", input.Alternates, alternate ?? ExpectedAlternate),
      ItemsExpected("allAlternates:", input.Alternates, ExpectedObject(input.Name, alternate ?? ExpectedAlternate))));
  string[] ICheckObjectModel<TObject, TObjBase, TObjField, TObjAlt, TModel>.DualField(FieldInput field)
    => field.TypeParameter
      ? [$"- !_{TypeKind}Field", "  name: " + field.Name, "  type: !_TypeParameter " + field.Type]
      : [$"- !_{TypeKind}Field", "  name: " + field.Name, "  type: !_DualBase", "    dual: " + field.Type];
  string[] ICheckObjectModel<TObject, TObjBase, TObjField, TObjAlt, TModel>.DualAlternate(AlternateInput alternate)
    => alternate.TypeParameter
    ? [$"- !_{TypeKind}Alternate", "  collections:", "  - !_Modifier", "    modifierKind: !_ModifierKind List", "  type: !_TypeParameter " + alternate.Type]
    : [$"- !_{TypeKind}Alternate", "  collections:", "  - !_Modifier", "    modifierKind: !_ModifierKind List", "  type: !_DualBase", "    dual: " + alternate.Type];
  string[] ICheckObjectModel<TObject, TObjBase, TObjField, TObjAlt, TModel>.DualParent(string? parent)
    => parent is null ? []
    : ["parent: !_DualBase", "  dual: " + parent];
  string[] ICheckObjectModel<TObject, TObjBase, TObjField, TObjAlt, TModel>.TypeParameterParent(string? parent)
    => parent is null ? []
    : ["parent: !_TypeParameter " + parent];

  private ToExpected<TInput> ExpectedObject<TInput>(string name, ToExpected<TInput> expectedField)
    => f => {
      string[] field = expectedField(f).ToArray();

      string first = "- !_ObjectFor(" + field[0][3..] + ")";
      int typeAt = field.Length - Array.FindIndex(field, f => f.StartsWith("  type:", StringComparison.InvariantCulture));
      IEnumerable<string> last = field.TakeLast(typeAt);

      return [first, .. field.Skip(1).SkipLast(typeAt), "  object: " + name, .. last];
    };

  void ICheckObjectModel<TObject, TObjBase, TObjField, TObjAlt, TModel>.ParentExpected(ExpectedObjectInput input)
    => AstExpected(NewObjectAst(new(input.Name, input.Parent)), input.Expected(TypeKind, ExpectedParent, [],
      [], ItemsExpected("allFields:", input.Fields, ExpectedObject<FieldInput>(input.Parent!, ExpectedField)),
      [], ItemsExpected("allAlternates:", input.Alternates, ExpectedObject<AlternateInput>(input.Parent!, ExpectedAlternate))));

  TObject ICheckObjectModel<TObject, TObjBase, TObjField, TObjAlt, TModel>.ObjectAst(ExpectedObjectInput input)
    => NewObjectAst(input);

  BaseTypeModel IParentModel<FieldInput>.NewParent(string name, FieldInput[] members, string? parent)
    => NewParentModel(name, parent, members, []);
  BaseTypeModel IParentModel<AlternateInput>.NewParent(string name, AlternateInput[] members, string? parent)
    => NewParentModel(name, parent, [], members);

  private BaseTypeModel NewParentModel(string name, string? parent, FieldInput[] fields, AlternateInput[] alternates)
    => _modeller.ToModel<TModel>(NewObjectAst(new(name, parent, fields: fields, alternates: alternates)), TypeKinds);

  protected abstract TObjectAst NewObjectAst(ExpectedObjectInput input, IGqlpObjBase? parent = default);
}

public interface ICheckObjectModel<TObject, TObjBase, TObjField, TObjAlt, TModel>
  : ICheckTypeModel<IGqlpObjBase, string, TypeKindModel, TModel>
  , IParentModel<FieldInput>, IParentModel<AlternateInput>
  where TObject : IGqlpObject<TObjBase, TObjField, TObjAlt>
  where TObjBase : IGqlpObjBase
  where TObjField : IGqlpObjField
  where TObjAlt : IGqlpObjAlternate
  where TModel : ITypeObjectModel
{
  void ObjectExpected(ExpectedObjectInput input, ToExpected<string?>? parent = null,
    ToExpected<FieldInput>? field = null, ToExpected<AlternateInput>? alternate = null);
  string[] DualParent(string? parent);
  string[] DualField(FieldInput field);
  string[] DualAlternate(AlternateInput alternate);
  string[] TypeParameterParent(string? parent);

  void ParentExpected(ExpectedObjectInput input);
  TObject ObjectAst(ExpectedObjectInput input);
}

public sealed class ExpectedObjectInput(
  string name,
  string? parent = null,
  string[]? typeParameters = null,
  FieldInput[]? fields = null,
  AlternateInput[]? alternates = null,
  IEnumerable<string>? aliases = null,
  string? description = null
) : ExpectedTypeInput<string>(name, parent, aliases, description)
{
  internal string[] TypeParameters { get; } = typeParameters ?? [];
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
    IEnumerable<string>? typeParameters = null,
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
      .. typeParameters ?? []];
}
