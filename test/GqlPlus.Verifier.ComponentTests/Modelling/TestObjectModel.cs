using GqlPlus.Verifier.Ast.Schema;
using GqlPlus.Verifier.Rendering;

namespace GqlPlus.Verifier.Modelling;

public abstract class TestObjectModel<TObject, TField, TRef>
  : TestTypeModel<TRef, string, TypeKindModel>
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
      new(name, parent, fields, alternates, aliases, contents));

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
  where TModel : IRendering
{
  internal string[] ExpectedObject(ExpectedObjectInput input)
    => input.Expected(TypeKind, ExpectedParent, f => [], a => []);

  internal IEnumerable<string> ExpectedField(FieldInput field)
    => [$"- !_{TypeKind}Field", "  name: " + field.Name, $"  type: !_{TypeKind}Base {field.Type}"];

  internal IEnumerable<string> ExpectedAlternate(string alternate)
    => [$"- !_Alternate(_{TypeKind}Base)", "  collections:", "  - !_Modifier List", $"  type: !_Described(_ObjRef(_{TypeKind}Base)) {alternate}"];

  protected override string[] ExpectedParent(string? parent)
    => parent is null ? []
    : [$"parent: !_Described(_{TypeKind}Base) {parent}"];

  protected override string[] ExpectedType(ExpectedTypeInput<string> input)
    => ExpectedObject(new(input));

  internal override TObject NewTypeAst(string name, TRef? parent, string description)
    => NewObjectAst(name, parent, description, [], []);

  void ICheckObjectModel<TObject, TField, TRef>.ObjectExpected(TObject ast, ExpectedObjectInput input)
    => AstExpected(ast, input.Expected(TypeKind, ExpectedParent,
      fields => ItemsExpected("fields:", fields, ExpectedField),
      alternates => ItemsExpected("alternates:", alternates, ExpectedAlternate)));

  TObject ICheckObjectModel<TObject, TField, TRef>.ObjectAst(string name, FieldInput[] fields, string[] alternates)
    => NewObjectAst(name, default, "", fields, alternates);

  protected abstract TObject NewObjectAst(string name, TRef? parent, string description, FieldInput[] fields, string[] alternates);
}

internal interface ICheckObjectModel<TObject, TField, TRef>
  : ICheckTypeModel<TRef, string, TypeKindModel>
  where TObject : AstObject<TField, TRef>
  where TField : AstField<TRef>
  where TRef : AstReference<TRef>
{
  void ObjectExpected(TObject ast, ExpectedObjectInput input);
  TObject ObjectAst(string name, FieldInput[] fields, string[] alternates);
}

internal class ExpectedObjectInput(
  string name,
  string? parent,
  FieldInput[]? fields = null,
  string[]? alternates = null,
  IEnumerable<string>? aliases = null,
  string? description = null
) : ExpectedTypeInput<string>(name, parent, aliases, description)
{
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
    Func<FieldInput[], IEnumerable<string>> fields,
    Func<string[], IEnumerable<string>> alternates)
    => [$"!_Type{typeKind}",
      .. Aliases,
      .. alternates(Alternates),
      .. Description ,
      .. fields(Fields),
      $"kind: !_TypeKind {typeKind}",
      "name: " + Name,
      .. parent(Parent)];
}
