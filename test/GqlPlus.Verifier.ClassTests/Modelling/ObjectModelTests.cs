using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Modelling;

public abstract class ObjectModelTests<TObject, TField, TReference>
  : TypeModelTests<TReference, string, TypeKindModel>
  where TObject : AstObject<TField, TReference>
  where TField : AstField<TReference>
  where TReference : AstReference<TReference>
{
  [Theory, RepeatData(Repeats)]
  public void Model_Alternates(string name, string[] alternates)
    => ObjectChecks.ObjectExpected(
      ObjectChecks.ObjectAst(name, [], alternates),
      new(name, null, null, alternates));

  [Theory, RepeatData(Repeats)]
  public void Model_Fields(string name, FieldInput[] fields)
    => ObjectChecks.ObjectExpected(
      ObjectChecks.ObjectAst(name, fields, []),
      new(name, null, fields));

  [Theory, RepeatData(Repeats)]
  public void Model_All(string name, string contents, string parent, string[] aliases, FieldInput[] fields, string[] alternates)
    => ObjectChecks.ObjectExpected(
      ObjectChecks.ObjectAst(name, fields, alternates) with {
        Aliases = aliases,
        Description = contents,
        Parent = ObjectChecks.ParentAst(parent),
      },
      new(name, parent, fields, alternates,
        [$"aliases: [{string.Join(", ", aliases)}]"],
        ["description: " + ObjectChecks.YamlQuoted(contents)]));

  protected override string[] ExpectedDescriptionAliases(string input, string description, string aliases)
    => new ExpectedObjectInput(input, null, null, null, [aliases], [description])
      .Expected(ObjectChecks.TypeKind, p => [], f => [], a => []);

  internal override ITypeModelChecks<TReference, string, TypeKindModel> TypeChecks => ObjectChecks;

  internal abstract IObjectModelChecks<TObject, TField, TReference> ObjectChecks { get; }
}

internal abstract class ObjectModelChecks<TObject, TField, TReference>
  : TypeModelChecks<TReference, string, AstObject<TField, TReference>, TypeKindModel>,
    IObjectModelChecks<TObject, TField, TReference>
  where TObject : AstObject<TField, TReference>
  where TField : AstField<TReference>
  where TReference : AstReference<TReference>
{
  protected ObjectModelChecks(TypeKindModel kind, IModeller<AstType<TReference>> type)
    : base(kind, type)
  { }

  internal string[] ExpectedObject(ExpectedObjectInput input)
    => input.Expected(TypeKind, ExpectedParent, f => [], a => []);

  protected override string[] ExpectedType(
    string name,
    string? parent,
    IEnumerable<string>? aliases = null,
    IEnumerable<string>? description = null)
    => ExpectedObject(new(name, parent, [], [], aliases, description));

  internal override AstObject<TField, TReference> NewTypeAst(string name, TReference? parent, string description)
    => NewObjectAst(name, parent, description, [], []);

  void IObjectModelChecks<TObject, TField, TReference>.ObjectExpected(AstObject<TField, TReference> ast, ExpectedObjectInput input)
    => AstExpected(ast, input.Expected(TypeKind, ExpectedParent, f => [], a => []));

  AstObject<TField, TReference> IObjectModelChecks<TObject, TField, TReference>.ObjectAst(string name, FieldInput[] fields, string[] alternates)
    => NewObjectAst(name, default, "", fields, alternates);

  protected abstract TObject NewObjectAst(string name, TReference? parent, string description, FieldInput[] fields, string[] alternates);
}

internal interface IObjectModelChecks<TObject, TField, TReference>
  : ITypeModelChecks<TReference, string, TypeKindModel>
  where TObject : AstObject<TField, TReference>
  where TField : AstField<TReference>
  where TReference : AstReference<TReference>
{
  void ObjectExpected(AstObject<TField, TReference> ast, ExpectedObjectInput input);
  AstObject<TField, TReference> ObjectAst(string name, FieldInput[] fields, string[] alternates);
}

internal record struct ExpectedObjectInput(
  string Name,
  string? Parent,
  FieldInput[]? Fields = null,
  string[]? Alternates = null,
  IEnumerable<string>? Aliases = null,
  IEnumerable<string>? Description = null)
{
  internal string[] Expected(TypeKindModel typeKind, Func<string?, string[]> parent, Func<FieldInput[]?, string[]> fields, Func<string[]?, string[]> alternates)
    => [$"!_{typeKind}",
      .. Aliases ?? [],
      .. alternates(Alternates),
      .. Description ?? [],
      .. fields(Fields),
      $"kind: !_TypeKind {typeKind}",
      "name: " + Name,
      .. parent(Parent)];
}
