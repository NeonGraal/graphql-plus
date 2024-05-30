using GqlPlus.Ast.Schema.Objects;

namespace GqlPlus.Modelling.Objects;

public abstract class TestObjectModel<TObject, TObjField, TObjBase>
  : TestTypeModel<TObjBase, string, TypeKindModel>
  where TObject : AstObject<TObjField, TObjBase>
  where TObjField : AstObjectField<TObjBase>
  where TObjBase : AstObjectBase<TObjBase>
{
  [Theory, RepeatData(Repeats)]
  public void Model_ParentDual(string name, string parent)
    => ObjectChecks
      .AddTypeKinds(TypeKindModel.Dual, parent)
      .ObjectExpected(
        (TObject)TypeChecks.TypeAst(name, parent),
        new(name, parent),
        ObjectChecks.DualParent);

  [Theory, RepeatData(Repeats)]
  public void Model_ParentTypeParameter(string name, string parent)
    => ObjectChecks
      .AddTypeKinds(TypeKindModel.Dual, parent)
      .ObjectExpected(
        ObjectChecks.ObjectAst(name, [], []) with {
          Parent = TypeChecks.ParentAst(parent) with { IsTypeParameter = true }
        },
        new(name, parent), ObjectChecks.TypeParameterParent);

  [Theory, RepeatData(Repeats)]
  public void Model_Alternate(string name, string alternate)
    => ObjectChecks.ObjectExpected(
      ObjectChecks.ObjectAst(name, [], [alternate]),
      new(name, alternates: [alternate]));

  [Theory, RepeatData(Repeats)]
  public void Model_AlternateParent(string name, string parent, string alternate)
    => ObjectChecks
      .AddParent(ObjectChecks.NewParent(parent, [alternate]))
      .ParentExpected(
        (TObject)TypeChecks.TypeAst(name, parent),
        new(name, parent, alternates: [alternate]));

  [Theory, RepeatData(Repeats)]
  public void Model_AlternateTypeParameter(string name, string alternate)
    => ObjectChecks.ObjectExpected(
      ObjectChecks.ObjectAst(name, [], []) with {
        Alternates = [new(TypeChecks.ParentAst(alternate) with { IsTypeParameter = true })]
      },
      new(name, alternates: [alternate]),
      alternate: ObjectChecks.TypeParameterAlternate);

  [Theory, RepeatData(Repeats)]
  public void Model_Alternates(string name, string[] alternates)
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
        (TObject)TypeChecks.TypeAst(name, parent),
        new(name, parent, fields: [field]));

  [Theory, RepeatData(Repeats)]
  public void Model_FieldTypeParameter(string name, FieldInput field)
    => ObjectChecks.ObjectExpected(
      ObjectChecks.ObjectAst(name, [field.MakeTypeParameter()], []),
      new(name, fields: [field]));

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
  public void Model_All(string name, string contents, string parent, string[] aliases, FieldInput[] fields, string[] alternates, string[] typeParameters)
    => ObjectChecks.ObjectExpected(
      ObjectChecks.ObjectAst(name, fields, alternates) with {
        Aliases = aliases,
        Description = contents,
        Parent = ObjectChecks.ParentAst(parent),
        TypeParameters = typeParameters.TypeParameters(),
      },
      new(name, parent, typeParameters, fields, alternates, aliases, contents));

  internal override ICheckTypeModel<TObjBase, string, TypeKindModel> TypeChecks => ObjectChecks;

  internal abstract ICheckObjectModel<TObject, TObjField, TObjBase> ObjectChecks { get; }
}

internal abstract class CheckObjectModel<TObject, TObjField, TObjBase, TModel>(
  IModeller<TObject, TModel> modeller,
  TypeKindModel kind
) : CheckTypeModel<TObjBase, string, TObject, TypeKindModel, TModel>(modeller, kind),
    ICheckObjectModel<TObject, TObjField, TObjBase>
  where TObject : AstObject<TObjField, TObjBase>
  where TObjField : AstObjectField<TObjBase>
  where TObjBase : AstObjectBase<TObjBase>
  where TModel : BaseTypeModel
{
  internal string[] ExpectedObject(ExpectedObjectInput input)
    => input.Expected(TypeKind, ExpectedParent);

  internal IEnumerable<string> ExpectedField(FieldInput field)
    => field.TypeParameter
        ? [$"- !_{TypeKind}Field", "  name: " + field.Name, "  type: !_TypeParameter " + field.Type]
        : [$"- !_{TypeKind}Field", "  name: " + field.Name, $"  type: !_{TypeKind}Base", $"    {TypeKindLower}: {field.Type}"];

  internal IEnumerable<string> ExpectedAlternate(string alternate)
    => [$"- !_Alternate(_{TypeKind}Base)", "  collections:", "  - !_Modifier List", $"  type: !_{TypeKind}Base", $"    {TypeKindLower}: {alternate}"];

  internal IEnumerable<string> ExpectedTypeParameter(string typeParameter)
    => ["- !_Described", "  name: " + typeParameter];

  protected override string[] ExpectedParent(string? parent)
    => parent is null ? []
    : [$"parent: !_{TypeKind}Base", $"  {TypeKindLower}: {parent}"];

  protected override string[] ExpectedType(ExpectedTypeInput<string> input)
    => ExpectedObject(new(input));

  internal override TObject NewTypeAst(string name, TObjBase? parent = default, string? description = null, string[]? aliases = null)
    => NewObjectAst(name, parent, description, aliases, [], []);

  void ICheckObjectModel<TObject, TObjField, TObjBase>.ObjectExpected(TObject ast, ExpectedObjectInput input,
      ToExpected<string?>? parent, ToExpected<FieldInput>? field, ToExpected<string>? alternate)
    => AstExpected(ast, input.Expected(TypeKind, parent ?? ExpectedParent,
      ItemsExpected("typeParameters:", input.TypeParameters, ExpectedTypeParameter),
      ItemsExpected("fields:", input.Fields, field ?? ExpectedField),
      ItemsExpected("allFields:", input.Fields, ExpectedObject(input.Name, field ?? ExpectedField)),
      ItemsExpected("alternates:", input.Alternates, alternate ?? ExpectedAlternate),
      ItemsExpected("allAlternates:", input.Alternates, ExpectedObject(input.Name, alternate ?? ExpectedAlternate))));
  string[] ICheckObjectModel<TObject, TObjField, TObjBase>.DualField(FieldInput field)
    => field.TypeParameter
      ? [$"- !_{TypeKind}Field", "  name: " + field.Name, "  type: !_TypeParameter " + field.Type]
      : [$"- !_{TypeKind}Field", "  name: " + field.Name, "  type: !_DualBase", "    dual: " + field.Type];
  string[] ICheckObjectModel<TObject, TObjField, TObjBase>.DualAlternate(string alternate)
    => [$"- !_Alternate(_{TypeKind}Base)", "  collections:", "  - !_Modifier List", "  type: !_DualBase", "    dual: " + alternate];
  string[] ICheckObjectModel<TObject, TObjField, TObjBase>.DualParent(string? parent)
    => parent is null ? []
    : ["parent: !_DualBase", "  dual: " + parent];
  string[] ICheckObjectModel<TObject, TObjField, TObjBase>.TypeParameterParent(string? parent)
    => parent is null ? []
    : ["parent: !_TypeParameter " + parent];
  string[] ICheckObjectModel<TObject, TObjField, TObjBase>.TypeParameterAlternate(string alternate)
    => [$"- !_Alternate(_{TypeKind}Base)", "  type: !_TypeParameter " + alternate];

  private ToExpected<TInput> ExpectedObject<TInput>(string name, ToExpected<TInput> expectedField)
    => f => {
      string[] field = expectedField(f).ToArray();

      string first = "- !_ObjectFor(" + field[0][3..] + ")";
      int typeAt = field.Length - Array.FindIndex(field, f => f.StartsWith("  type:", StringComparison.InvariantCulture));
      IEnumerable<string> last = field.TakeLast(typeAt);

      return [first, .. field.Skip(1).SkipLast(typeAt), "  object: " + name, .. last];
    };

  void ICheckObjectModel<TObject, TObjField, TObjBase>.ParentExpected(TObject ast, ExpectedObjectInput input)
    => AstExpected(ast, input.Expected(TypeKind, ExpectedParent, [],
      [], ItemsExpected("allFields:", input.Fields, ExpectedObject<FieldInput>(input.Parent!, ExpectedField)),
      [], ItemsExpected("allAlternates:", input.Alternates, ExpectedObject<string>(input.Parent!, ExpectedAlternate))));

  TObject ICheckObjectModel<TObject, TObjField, TObjBase>.ObjectAst(string name, FieldInput[] fields, string[] alternates)
    => NewObjectAst(name, default, "", null, fields, alternates);

  BaseTypeModel IParentModel<FieldInput>.NewParent(string name, FieldInput[] members, string? parent)
    => NewParentModel(name, parent, members, []);
  BaseTypeModel IParentModel<string>.NewParent(string name, string[] members, string? parent)
    => NewParentModel(name, parent, [], members);

  private BaseTypeModel NewParentModel(string name, string? parent, FieldInput[] fields, string[] alternates)
    => _modeller.ToModel<TModel>(NewObjectAst(name, parent is null ? null : NewParentAst(parent), "", null, fields, alternates), TypeKinds);

  protected abstract TObject NewObjectAst(string name, TObjBase? parent, string? description, string[]? aliases, FieldInput[] fields, string[] alternates);
}

internal interface ICheckObjectModel<TObject, TObjField, TObjBase>
  : ICheckTypeModel<TObjBase, string, TypeKindModel>
  , IParentModel<FieldInput>, IParentModel<string>
  where TObject : AstObject<TObjField, TObjBase>
  where TObjField : AstObjectField<TObjBase>
  where TObjBase : AstObjectBase<TObjBase>
{
  void ObjectExpected(TObject ast, ExpectedObjectInput input, ToExpected<string?>? parent = null,
    ToExpected<FieldInput>? field = null, ToExpected<string>? alternate = null);
  string[] DualParent(string? parent);
  string[] DualField(FieldInput field);
  string[] DualAlternate(string alternate);
  string[] TypeParameterParent(string? parent);
  string[] TypeParameterAlternate(string alternate);

  void ParentExpected(TObject ast, ExpectedObjectInput input);
  TObject ObjectAst(string name, FieldInput[] fields, string[] alternates);
}

internal sealed class ExpectedObjectInput(
  string name,
  string? parent = null,
  string[]? typeParameters = null,
  FieldInput[]? fields = null,
  string[]? alternates = null,
  IEnumerable<string>? aliases = null,
  string? description = null
) : ExpectedTypeInput<string>(name, parent, aliases, description)
{
  internal string[] TypeParameters { get; } = typeParameters ?? [];
  internal FieldInput[] Fields { get; } = fields ?? [];
  internal string[] Alternates { get; } = alternates ?? [];

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
