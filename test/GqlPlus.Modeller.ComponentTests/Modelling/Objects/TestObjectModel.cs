using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Objects;

namespace GqlPlus.Modelling.Objects;

public abstract class TestObjectModel<TObjectAst, TObjField, TObjFieldAst, TObjAlt, TObjAltAst, TObjBase, TObjBaseAst>
  : TestTypeModel<IGqlpObjBase, string, TypeKindModel>
  where TObjectAst : AstObject<TObjBase, TObjField, TObjAlt>
  where TObjField : IGqlpObjField
  where TObjFieldAst : AstObjField<TObjBase>, TObjField
  where TObjAlt : IGqlpObjAlternate
  where TObjAltAst : AstObjAlternate<TObjBase>, TObjAlt
  where TObjBase : IGqlpObjBase
  where TObjBaseAst : AstObjBase<TObjBase>, TObjBase
{
  [Theory, RepeatData(Repeats)]
  public void Model_ParentDual(string name, string parent)
    => ObjectChecks
      .AddTypeKinds(TypeKindModel.Dual, parent)
      .ObjectExpected(
        (TObjectAst)TypeChecks.TypeAst(name, parent),
        new(name, parent),
        ObjectChecks.DualParent);

  [Theory, RepeatData(Repeats)]
  public void Model_ParentTypeParameter(string name, string parent)
    => ObjectChecks
      .AddTypeKinds(TypeKindModel.Dual, parent)
      .ObjectExpected(
        ObjectChecks.ObjectAst(name, [], []) with {
          Parent = (TObjBaseAst)TypeChecks.ParentAst(parent) with { IsTypeParameter = true }
        },
        new(name, parent), ObjectChecks.TypeParameterParent);

  [Theory, RepeatData(Repeats)]
  public void Model_Alternate(string name, AlternateInput alternate)
    => ObjectChecks.ObjectExpected(
      ObjectChecks.ObjectAst(name, [], [alternate]),
      new(name, alternates: [alternate]));

  [Theory, RepeatData(Repeats)]
  public void Model_AlternateParent(string name, string parent, AlternateInput alternate)
    => ObjectChecks
      .AddParent(ObjectChecks.NewParent(parent, [alternate]))
      .ParentExpected(
        (TObjectAst)TypeChecks.TypeAst(name, parent),
        new(name, parent, alternates: [alternate]));

  [Theory, RepeatData(Repeats)]
  public void Model_AlternateTypeParameter(string name, AlternateInput alternate)
    => ObjectChecks.ObjectExpected(
      ObjectChecks.ObjectAst(name, [], [alternate.MakeTypeParameter()]),
      new(name, alternates: [alternate.MakeTypeParameter()]));

  [Theory, RepeatData(Repeats)]
  public void Model_Alternates(string name, AlternateInput[] alternates)
    => ObjectChecks.ObjectExpected(
      ObjectChecks.ObjectAst(name, [], alternates),
      new(name, alternates: alternates));

  [Theory, RepeatData(Repeats)]
  public void Model_Field(string name, FieldInput field)
    => ObjectChecks.ObjectExpected(
      ObjectChecks.ObjectAst(name, [field], []),
      new(name, fields: [field]));

  [Theory, RepeatData(Repeats)]
  public void Model_FieldParent(string name, string parent, FieldInput field)
    => ObjectChecks
      .AddParent(ObjectChecks.NewParent(parent, [field]))
      .ParentExpected(
        (TObjectAst)TypeChecks.TypeAst(name, parent),
        new(name, parent, fields: [field]));

  [Theory, RepeatData(Repeats)]
  public void Model_FieldTypeParameter(string name, FieldInput field)
    => ObjectChecks.ObjectExpected(
      ObjectChecks.ObjectAst(name, [field.MakeTypeParameter()], []),
      new(name, fields: [field.MakeTypeParameter()]));

  [Theory, RepeatData(Repeats)]
  public void Model_Fields(string name, FieldInput[] fields)
    => ObjectChecks.ObjectExpected(
      ObjectChecks.ObjectAst(name, fields, []),
      new(name, fields: fields));

  [Theory, RepeatData(Repeats)]
  public void Model_FieldsDual(string name, FieldInput[] fields)
    => ObjectChecks
      .AddTypeKinds(fields.Select(f => f.Type), TypeKindModel.Dual)
      .ObjectExpected(
        ObjectChecks.ObjectAst(name, fields, []),
        new(name, fields: fields),
        field: ObjectChecks.DualField);

  [Theory, RepeatData(Repeats)]
  public void Model_TypeParameter(string name, string typeParameter)
    => ObjectChecks
      .ObjectExpected(
        ObjectChecks.ObjectAst(name, [], []) with { TypeParameters = [new TypeParameterAst(AstNulls.At, typeParameter)] },
        new(name, typeParameters: [typeParameter]));

  [Theory, RepeatData(Repeats)]
  public void Model_TypeParameters(string name, string[] typeParameters)
    => ObjectChecks
      .ObjectExpected(
        ObjectChecks.ObjectAst(name, [], []) with { TypeParameters = typeParameters.TypeParameters() },
        new(name, typeParameters: typeParameters));

  [Theory, RepeatData(Repeats)]
  public void Model_All(string name, string contents, string parent, string[] aliases, FieldInput[] fields, AlternateInput[] alternates, string[] typeParameters)
    => ObjectChecks.ObjectExpected(
      ObjectChecks.ObjectAst(name, fields, alternates) with {
        Aliases = aliases,
        Description = contents,
        Parent = (TObjBaseAst)ObjectChecks.ParentAst(parent),
        TypeParameters = typeParameters.TypeParameters(),
      },
      new(name, parent, typeParameters, fields, alternates, aliases, contents));

  internal override ICheckTypeModel<IGqlpObjBase, string, TypeKindModel> TypeChecks => ObjectChecks;

  internal abstract ICheckObjectModel<TObjectAst, TObjBase, TObjField, TObjAlt> ObjectChecks { get; }
}

internal abstract class CheckObjectModel<TObject, TObjectAst, TObjField, TObjFieldAst, TObjAlt, TObjAltAst, TObjBase, TModel>(
  IModeller<TObject, TModel> modeller,
  IRenderer<TModel> rendering,
  TypeKindModel kind
) : CheckTypeModel<IGqlpObjBase, string, TObject, TypeKindModel, TModel>(modeller, rendering, kind),
    ICheckObjectModel<TObjectAst, TObjBase, TObjField, TObjAlt>
  where TObject : IGqlpObject
  where TObjectAst : AstObject<TObjBase, TObjField, TObjAlt>, TObject
  where TObjField : IGqlpObjField
  where TObjFieldAst : AstObjField<TObjBase>, TObjField
  where TObjAlt : IGqlpObjAlternate
  where TObjAltAst : AstObjAlternate<TObjBase>, TObjAlt
  where TObjBase : IGqlpObjBase
  where TModel : BaseTypeModel
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
    => NewObjectAst(name, parent, description, aliases, [], []);

  void ICheckObjectModel<TObjectAst, TObjBase, TObjField, TObjAlt>.ObjectExpected(TObjectAst ast, ExpectedObjectInput input,
      ToExpected<string?>? parent, ToExpected<FieldInput>? field, ToExpected<AlternateInput>? alternate)
    => AstExpected(ast, input.Expected(TypeKind, parent ?? ExpectedParent,
      ItemsExpected("typeParameters:", input.TypeParameters, ExpectedTypeParameter),
      ItemsExpected("fields:", input.Fields, field ?? ExpectedField),
      ItemsExpected("allFields:", input.Fields, ExpectedObject(input.Name, field ?? ExpectedField)),
      ItemsExpected("alternates:", input.Alternates, alternate ?? ExpectedAlternate),
      ItemsExpected("allAlternates:", input.Alternates, ExpectedObject(input.Name, alternate ?? ExpectedAlternate))));
  string[] ICheckObjectModel<TObjectAst, TObjBase, TObjField, TObjAlt>.DualField(FieldInput field)
    => field.TypeParameter
      ? [$"- !_{TypeKind}Field", "  name: " + field.Name, "  type: !_TypeParameter " + field.Type]
      : [$"- !_{TypeKind}Field", "  name: " + field.Name, "  type: !_DualBase", "    dual: " + field.Type];
  string[] ICheckObjectModel<TObjectAst, TObjBase, TObjField, TObjAlt>.DualAlternate(AlternateInput alternate)
    => alternate.TypeParameter
    ? [$"- !_{TypeKind}Alternate", "  collections:", "  - !_Modifier", "    modifierKind: !_ModifierKind List", "  type: !_TypeParameter " + alternate.Type]
    : [$"- !_{TypeKind}Alternate", "  collections:", "  - !_Modifier", "    modifierKind: !_ModifierKind List", "  type: !_DualBase", "    dual: " + alternate.Type];
  string[] ICheckObjectModel<TObjectAst, TObjBase, TObjField, TObjAlt>.DualParent(string? parent)
    => parent is null ? []
    : ["parent: !_DualBase", "  dual: " + parent];
  string[] ICheckObjectModel<TObjectAst, TObjBase, TObjField, TObjAlt>.TypeParameterParent(string? parent)
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

  void ICheckObjectModel<TObjectAst, TObjBase, TObjField, TObjAlt>.ParentExpected(TObjectAst ast, ExpectedObjectInput input)
    => AstExpected(ast, input.Expected(TypeKind, ExpectedParent, [],
      [], ItemsExpected("allFields:", input.Fields, ExpectedObject<FieldInput>(input.Parent!, ExpectedField)),
      [], ItemsExpected("allAlternates:", input.Alternates, ExpectedObject<AlternateInput>(input.Parent!, ExpectedAlternate))));

  TObjectAst ICheckObjectModel<TObjectAst, TObjBase, TObjField, TObjAlt>.ObjectAst(string name, FieldInput[] fields, AlternateInput[] alternates)
    => NewObjectAst(name, default, "", null, fields, alternates);

  BaseTypeModel IParentModel<FieldInput>.NewParent(string name, FieldInput[] members, string? parent)
    => NewParentModel(name, parent, members, []);
  BaseTypeModel IParentModel<AlternateInput>.NewParent(string name, AlternateInput[] members, string? parent)
    => NewParentModel(name, parent, [], members);

  private BaseTypeModel NewParentModel(string name, string? parent, FieldInput[] fields, AlternateInput[] alternates)
    => _modeller.ToModel<TModel>(NewObjectAst(name, parent is null ? default : NewParentAst(parent), "", null, fields, alternates), TypeKinds);

  protected abstract TObjectAst NewObjectAst(string name, IGqlpObjBase? parent, string? description, string[]? aliases, FieldInput[] fields, AlternateInput[] alternates);
}

internal interface ICheckObjectModel<TObjectAst, TObjBase, TObjField, TObjAlt>
  : ICheckTypeModel<IGqlpObjBase, string, TypeKindModel>
  , IParentModel<FieldInput>, IParentModel<AlternateInput>
  where TObjectAst : AstObject<TObjBase, TObjField, TObjAlt>
  where TObjField : IGqlpObjField
  where TObjAlt : IGqlpObjAlternate
  where TObjBase : IGqlpObjBase
{
  void ObjectExpected(TObjectAst ast, ExpectedObjectInput input, ToExpected<string?>? parent = null,
    ToExpected<FieldInput>? field = null, ToExpected<AlternateInput>? alternate = null);
  string[] DualParent(string? parent);
  string[] DualField(FieldInput field);
  string[] DualAlternate(AlternateInput alternate);
  string[] TypeParameterParent(string? parent);

  void ParentExpected(TObjectAst ast, ExpectedObjectInput input);
  TObjectAst ObjectAst(string name, FieldInput[] fields, AlternateInput[] alternates);
}

internal sealed class ExpectedObjectInput(
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
    Description = input.Description;
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
      .. Aliases,
      .. allAlternates ?? [],
      .. allFields ?? [],
      .. alternates ?? [],
      .. Description,
      .. fields ?? [],
      "name: " + Name,
      .. parent(Parent),
      $"typeKind: !_TypeKind {typeKind}",
      .. typeParameters ?? []];
}
