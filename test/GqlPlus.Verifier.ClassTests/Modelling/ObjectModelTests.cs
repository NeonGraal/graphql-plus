using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Modelling;

public abstract class ObjectModelTests<TObject, TField, TReference>
  : TypeModelTests<TReference, string>
  where TObject : AstObject<TField, TReference>
  where TField : AstField<TReference>
  where TReference : AstReference<TReference>
{
  [Theory, RepeatData(Repeats)]
  public void Model_Fields(string name, FieldInput[] fields)
    => ObjectChecks.ObjectExpected(
      ObjectChecks.ObjectAst(name, fields, []),
      ObjectChecks.ExpectedObject(name, null, fields));

  [Theory, RepeatData(Repeats)]
  public void Model_All(string name, string contents, string[] aliases, FieldInput[] fields, string[] alternates)
    => ObjectChecks.ObjectExpected(
      ObjectChecks.ObjectAst(name, fields, alternates) with {
        Aliases = aliases,
        Description = contents,
        // Parent = parent,
      },
      ObjectChecks.ExpectedObject(
        name,
        null, // parent,
        fields,
        alternates,
        [$"aliases: [{string.Join(", ", aliases)}]"],
        ["description: " + ObjectChecks.YamlQuoted(contents)]));

  protected override string[] ExpectedDescriptionAliases(string input, string description, string aliases)
    => ObjectChecks.ExpectedObject(input, null, null, null, [aliases], [description]);

  internal override ITypeModelChecks<TReference, string> TypeChecks => ObjectChecks;

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

  internal string[] ExpectedObject(
    string name,
    string? parent,
    FieldInput[]? fields,
    string[]? alternates,
    IEnumerable<string>? aliases,
    IEnumerable<string>? description
  ) => [$"!_{TypeKind}",
        .. aliases ?? [],
        .. description ?? [],
        $"kind: !_TypeKind {TypeKind}",
        "name: " + name];
  //.. parent.TypeRefFor(TypeKind)];

  protected override string[] ExpectedType(
    string name,
    string? parent,
    IEnumerable<string>? aliases = null,
    IEnumerable<string>? description = null)
    => ExpectedObject(name, parent, [], [], aliases, description);

  internal override AstObject<TField, TReference> NewTypeAst(string name, TReference? parent, string description)
    => NewObjectAst(name, parent, description, [], []);

  protected override string[] ExpectedParent(string? parent)
    => []; // Todo: parent.TypeRefFor(TypeKind);

  void IObjectModelChecks<TObject, TField, TReference>.ObjectExpected(AstObject<TField, TReference> ast, string[] expected)
    => AstExpected(ast, expected);

  AstObject<TField, TReference> IObjectModelChecks<TObject, TField, TReference>.ObjectAst(string name, FieldInput[] fields, string[] alternates)
    => NewObjectAst(name, default, "", fields, alternates);

  string[] IObjectModelChecks<TObject, TField, TReference>.ExpectedObject(
    string name,
    string? parent,
    FieldInput[]? fields,
    string[]? alternates,
    IEnumerable<string>? aliases,
    IEnumerable<string>? description)
    => ExpectedObject(name, parent, fields, alternates, aliases, description);

  protected abstract TObject NewObjectAst(string name, TReference? parent, string description, FieldInput[] fields, string[] alternates);
}

internal interface IObjectModelChecks<TObject, TField, TReference>
  : ITypeModelChecks<TReference, string>
  where TObject : AstObject<TField, TReference>
  where TField : AstField<TReference>
  where TReference : AstReference<TReference>
{
  void ObjectExpected(AstObject<TField, TReference> ast, string[] expected);
  AstObject<TField, TReference> ObjectAst(string name, FieldInput[] fields, string[] alternates);
  string[] ExpectedObject(string name, string? parent, FieldInput[]? fields = null, string[]? alternates = null, IEnumerable<string>? aliases = null, IEnumerable<string>? description = null);
}
