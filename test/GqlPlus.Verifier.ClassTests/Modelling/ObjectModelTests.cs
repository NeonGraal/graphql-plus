using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Modelling;

public abstract class ObjectModelTests<TObject, TField, TRef>
  : TypeModelTests<TRef, string, TypeKindModel>
  where TObject : AstObject<TField, TRef>
  where TField : AstField<TRef>
  where TRef : AstReference<TRef>
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

  internal override ITypeModelChecks<TRef, string, TypeKindModel> TypeChecks => ObjectChecks;

  internal abstract IObjectModelChecks<TObject, TField, TRef> ObjectChecks { get; }
}

internal abstract class ObjectModelChecks<TObject, TField, TRef>(
  TypeKindModel kind,
  IModeller<AstType<TRef>> type
) : TypeModelChecks<TRef, string, AstObject<TField, TRef>, TypeKindModel>(kind, type),
    IObjectModelChecks<TObject, TField, TRef>
  where TObject : AstObject<TField, TRef>
  where TField : AstField<TRef>
  where TRef : AstReference<TRef>
{
  internal string[] ExpectedObject(ExpectedObjectInput input)
    => input.Expected(TypeKind, ExpectedParent, f => [], a => []);

  internal IEnumerable<string> ExpectedField(FieldInput field)
    => [$"- !_{TypeKind}Field", "  name: " + field.Name, $"  type: !_{TypeKind}Base", $"    {TypeKindLower}: {field.Type}"];

  internal IEnumerable<string> ExpectedAlternate(string alternate)
    => [$"- !_Alternate(_{TypeKind}Base)", "  collections:", "  - !_Modifier List", "  - !_Modifier Optional", $"  type: !_{TypeKind}Base", $"    {TypeKindLower}: {alternate}"];

  protected override string[] ExpectedParent(string? parent)
    => parent is null ? []
    : [$"parent: !_Described(_{TypeKind}Base)", $"  {TypeKindLower}: {parent}"];

  protected override string[] ExpectedType(
    string name,
    string? parent,
    IEnumerable<string>? aliases = null,
    IEnumerable<string>? description = null)
    => ExpectedObject(new(name, parent, [], [], aliases, description));

  internal override AstObject<TField, TRef> NewTypeAst(string name, TRef? parent, string description)
    => NewObjectAst(name, parent, description, [], []);

  void IObjectModelChecks<TObject, TField, TRef>.ObjectExpected(AstObject<TField, TRef> ast, ExpectedObjectInput input)
    => AstExpected(ast, input.Expected(TypeKind, ExpectedParent,
      fields => ItemsExpected("fields:", fields, ExpectedField),
      alternates => ItemsExpected("alternates:", alternates, ExpectedAlternate)));

  AstObject<TField, TRef> IObjectModelChecks<TObject, TField, TRef>.ObjectAst(string name, FieldInput[] fields, string[] alternates)
    => NewObjectAst(name, default, "", fields, alternates);

  protected abstract TObject NewObjectAst(string name, TRef? parent, string description, FieldInput[] fields, string[] alternates);
}

internal interface IObjectModelChecks<TObject, TField, TRef>
  : ITypeModelChecks<TRef, string, TypeKindModel>
  where TObject : AstObject<TField, TRef>
  where TField : AstField<TRef>
  where TRef : AstReference<TRef>
{
  void ObjectExpected(AstObject<TField, TRef> ast, ExpectedObjectInput input);
  AstObject<TField, TRef> ObjectAst(string name, FieldInput[] fields, string[] alternates);
}

internal record struct ExpectedObjectInput(
  string Name,
  string? Parent,
  FieldInput[]? Fields = null,
  string[]? Alternates = null,
  IEnumerable<string>? Aliases = null,
  IEnumerable<string>? Description = null)
{
  internal string[] Expected(
    TypeKindModel typeKind,
    Func<string?, IEnumerable<string>> parent,
    Func<FieldInput[]?, IEnumerable<string>> fields,
    Func<string[]?, IEnumerable<string>> alternates)
    => [$"!_{typeKind}",
      .. Aliases ?? [],
      .. alternates(Alternates),
      .. Description ?? [],
      .. fields(Fields),
      $"kind: !_TypeKind {typeKind}",
      "name: " + Name,
      .. parent(Parent)];
}
