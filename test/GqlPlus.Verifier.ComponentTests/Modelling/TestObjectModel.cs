using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Modelling;

public abstract class TestObjectModel<TObject, TField, TRef>
  : TestTypeModel<TRef, string, TypeKindModel>
  where TObject : AstObject<TField, TRef>
  where TField : AstField<TRef>
  where TRef : AstReference<TRef>
{
  [Theory, RepeatData(Repeats)]
  public void Model_ParentDual(string name, string parent)
    => ObjectChecks
      .AddTypeKinds(TypeKindModel.Dual, parent)
      .DualExpected(
        (TObject)TypeChecks.TypeAst(name, parent),
        new(name, parent));

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
  public void Model_Fields(string name, FieldInput[] fields)
    => ObjectChecks.ObjectExpected(
      ObjectChecks.ObjectAst(name, fields, []),
      new(name, fields: fields));

  [Theory, RepeatData(Repeats)]
  public void Model_FieldsDual(string name, FieldInput[] fields)
    => ObjectChecks
      .AddTypeKinds(fields.Select(f => f.Type), TypeKindModel.Dual)
      .DualExpected(
        ObjectChecks.ObjectAst(name, fields, []),
        new(name, fields: fields));

  [Theory, RepeatData(Repeats)]
  public void Model_TypeParameter(string name, string typeParameter)
    => ObjectChecks
      .DualExpected(
        ObjectChecks.ObjectAst(name, [], []) with { TypeParameters = [new TypeParameterAst(AstNulls.At, typeParameter)] },
        new(name, typeParameters: [typeParameter]));

  [Theory, RepeatData(Repeats)]
  public void Model_TypeParameters(string name, string[] typeParameters)
    => ObjectChecks
      .DualExpected(
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

  internal override ICheckTypeModel<TRef, string, TypeKindModel> TypeChecks => ObjectChecks;

  internal abstract ICheckObjectModel<TObject, TField, TRef> ObjectChecks { get; }
}

internal abstract class CheckObjectModel<TObject, TField, TRef, TModel>(
  IModeller<TObject, TModel> modeller,
  TypeKindModel kind
) : CheckTypeModel<TRef, string, TObject, TypeKindModel, TModel>(modeller, kind),
    ICheckObjectModel<TObject, TField, TRef>
  where TObject : AstObject<TField, TRef>
  where TField : AstField<TRef>
  where TRef : AstReference<TRef>
  where TModel : BaseTypeModel
{
  internal string[] ExpectedObject(ExpectedObjectInput input)
    => input.Expected(TypeKind, ExpectedParent);

  internal IEnumerable<string> DualField(FieldInput field)
    => [$"- !_{TypeKind}Field", "  name: " + field.Name, "  type: !_DualBase " + field.Type];

  internal IEnumerable<string> DualAlternate(string alternate)
    => [$"- !_Alternate(_{TypeKind}Base)", "  collections:", "  - !_Modifier List", "  type: !_DualBase " + alternate];

  internal string[] DualParent(string? parent)
    => parent is null ? []
    : ["parent: !_DualBase " + parent];

  internal IEnumerable<string> ExpectedField(FieldInput field)
    => [$"- !_{TypeKind}Field", "  name: " + field.Name, $"  type: !_{TypeKind}Base {field.Type}"];

  internal IEnumerable<string> ExpectedAlternate(string alternate)
    => [$"- !_Alternate(_{TypeKind}Base)", "  collections:", "  - !_Modifier List", $"  type: !_{TypeKind}Base {alternate}"];

  internal IEnumerable<string> ExpectedParameter(string typeParameter)
    => ["- !_Described " + typeParameter];

  protected override string[] ExpectedParent(string? parent)
    => parent is null ? []
    : [$"parent: !_{TypeKind}Base {parent}"];

  protected override string[] ExpectedType(ExpectedTypeInput<string> input)
    => ExpectedObject(new(input));

  internal override TObject NewTypeAst(string name, TRef? parent, string description)
    => NewObjectAst(name, parent, description, [], []);

  void ICheckObjectModel<TObject, TField, TRef>.ObjectExpected(TObject ast, ExpectedObjectInput input)
    => AstExpected(ast, input.Expected(TypeKind, ExpectedParent,
      ItemsExpected("typeParameters:", input.TypeParameters, ExpectedParameter),
      ItemsExpected("fields:", input.Fields, ExpectedField),
      ItemsExpected("allFields:", input.Fields, ExpectedObject<FieldInput>(input.Name, ExpectedField)),
      ItemsExpected("alternates:", input.Alternates, ExpectedAlternate),
      ItemsExpected("allAlternates:", input.Alternates, ExpectedObject<string>(input.Name, ExpectedAlternate))));

  private Func<TInput, IEnumerable<string>> ExpectedObject<TInput>(string name, Func<TInput, IEnumerable<string>> expectedField)
    => f => {
      var field = expectedField(f).ToArray();

      var first = "- !_ObjectFor(" + field[0][3..] + ")";
      var last = field.Last();

      return [first, .. field.Skip(1).SkipLast(1), "  object: " + name, last];
    };

  void ICheckObjectModel<TObject, TField, TRef>.DualExpected(TObject ast, ExpectedObjectInput input)
    => AstExpected(ast, input.Expected(TypeKind, DualParent,
      ItemsExpected("typeParameters:", input.TypeParameters, ExpectedParameter),
      ItemsExpected("fields:", input.Fields, DualField),
      ItemsExpected("allFields:", input.Fields, ExpectedObject<FieldInput>(input.Name, DualField)),
      ItemsExpected("alternates:", input.Alternates, DualAlternate),
      ItemsExpected("allAlternates:", input.Alternates, ExpectedObject<string>(input.Name, DualAlternate))));

  void ICheckObjectModel<TObject, TField, TRef>.ParentExpected(TObject ast, ExpectedObjectInput input)
    => AstExpected(ast, input.Expected(TypeKind, ExpectedParent, [],
      [], ItemsExpected("allFields:", input.Fields, ExpectedObject<FieldInput>(input.Parent!, ExpectedField)),
      [], ItemsExpected("allAlternates:", input.Alternates, ExpectedObject<string>(input.Parent!, ExpectedAlternate))));

  TObject ICheckObjectModel<TObject, TField, TRef>.ObjectAst(string name, FieldInput[] fields, string[] alternates)
    => NewObjectAst(name, default, "", fields, alternates);

  BaseTypeModel IParentModel<FieldInput>.NewParent(string name, FieldInput[] members, string? parent)
    => NewParentModel(name, parent, members, []);
  BaseTypeModel IParentModel<string>.NewParent(string name, string[] members, string? parent)
    => NewParentModel(name, parent, [], members);

  private BaseTypeModel NewParentModel(string name, string? parent, FieldInput[] fields, string[] alternates)
    => _modeller.ToModel<TModel>(NewObjectAst(name, parent is null ? null : NewReferenceAst(parent), "", fields, alternates), TypeKinds);

  protected abstract TObject NewObjectAst(string name, TRef? parent, string description, FieldInput[] fields, string[] alternates);
}

internal interface ICheckObjectModel<TObject, TField, TRef>
  : ICheckTypeModel<TRef, string, TypeKindModel>
  , IParentModel<FieldInput>, IParentModel<string>
  where TObject : AstObject<TField, TRef>
  where TField : AstField<TRef>
  where TRef : AstReference<TRef>
{
  void ObjectExpected(TObject ast, ExpectedObjectInput input);
  void DualExpected(TObject ast, ExpectedObjectInput input);
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
    Func<string?, IEnumerable<string>> parent,
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
      .. Description ,
      .. fields ?? [],
      $"kind: !_TypeKind {typeKind}",
      "name: " + Name,
      .. parent(Parent),
      .. typeParameters ?? []];
}
