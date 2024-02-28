using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Schema;
using GqlPlus.Verifier.Rendering;

namespace GqlPlus.Verifier.Modelling;

public abstract class ScalarModelTests<TInput, TItem>
  : TypeModelTests<SimpleKindModel>
  where TItem : IAstScalarItem
{
  [Theory, RepeatData(Repeats)]
  public void Model_Members(string name, TInput[] members)
    => ScalarChecks.ScalarExpected(
      ScalarChecks.ScalarAst(name, members),
      ScalarChecks.ExpectedScalar(name, null, members));

  [Theory, RepeatData(Repeats)]
  public void Model_All(string name, string contents, string[] aliases, string parent, TInput[] members)
    => ScalarChecks.ScalarExpected(
      ScalarChecks.ScalarAst(name, members) with {
        Aliases = aliases,
        Description = contents,
        Parent = parent,
      },
      ScalarChecks.ExpectedScalar(
        name,
        parent,
        members,
        [$"aliases: [{string.Join(", ", aliases)}]"],
        ["description: " + ScalarChecks.YamlQuoted(contents)]));

  protected override string[] ExpectedDescriptionAliases(string input, string description, string aliases)
    => ScalarChecks.ExpectedScalar(input, null, null, [aliases], [description]);

  internal override ITypeModelChecks<SimpleKindModel> TypeChecks => ScalarChecks;

  internal abstract IScalarModelChecks<TInput, TItem> ScalarChecks { get; }
}

internal abstract class ScalarModelChecks<TInput, TItem>
  : TypeModelChecks<AstScalar<TItem>, SimpleKindModel>, IScalarModelChecks<TInput, TItem>
  where TItem : IAstScalarItem
{
  private readonly ScalarKind _scalarKind;

  protected ScalarModelChecks(ScalarKind kind, IModeller<AstType<string>> type)
    : base(SimpleKindModel.Scalar, type)
    => _scalarKind = kind;

  internal string[] ExpectedScalar(
    string name,
    string? parent,
    TInput[]? items,
    IEnumerable<string>? aliases,
    IEnumerable<string>? description
  ) => [$"!_Scalar{_scalarKind}",
        .. aliases ?? [],
        .. AllItems(items, name),
        .. description ?? [],
        .. Items(items),
        "kind: !_TypeKind Scalar",
        "name: " + name,
        .. parent.TypeRefFor(SimpleKindModel.Scalar),
        $"scalar: !_ScalarKind {_scalarKind}"];

  string[] IScalarModelChecks<TInput, TItem>.ExpectedScalar(
    string name,
    string? parent,
    TInput[]? items,
    IEnumerable<string>? aliases,
    IEnumerable<string>? description
  ) => ExpectedScalar(name, parent, items, aliases, description);

  AstScalar<TItem> IScalarModelChecks<TInput, TItem>.ScalarAst(string name, TInput[] items)
    => new(AstNulls.At, name, _scalarKind, ScalarItems(items) ?? []);

  void IScalarModelChecks<TInput, TItem>.ScalarExpected(AstScalar<TItem> scalar, string[] expected)
    => AstExpected(scalar, expected);

  protected IEnumerable<string> Items(TInput[]? inputs)
    => Items("items:", inputs, ExpectedItem());

  protected IEnumerable<string> AllItems(TInput[]? inputs, string ofScalar)
    => Items("allItems:", inputs, ExpectedAllItem(ofScalar));

  protected override string[] ExpectedType(
    string name,
    string? parent,
    IEnumerable<string>? aliases = null,
    IEnumerable<string>? description = null)
    => ExpectedScalar(name, parent, [], aliases, description);

  internal override AstScalar<TItem> NewTypeAst(string name, string? parent, string description)
    => new(AstNulls.At, name, description, _scalarKind) { Parent = parent };

  protected override string[] ExpectedParent(string? parent)
    => parent.TypeRefFor(TypeKind);

  protected abstract string[] ExpectedItem(TInput input, string exclude, string[] scalar);

  protected abstract TItem[]? ScalarItems(TInput[]? inputs);

  [SuppressMessage("Performance", "CA1822:Mark members as static")]
  private IEnumerable<string> Items(string field, TInput[]? inputs, Func<TInput, bool, IEnumerable<string>> mapping)
  {
    var exclude = true;

    return ItemsExpected(field, inputs, i => mapping(i, exclude = !exclude));
  }

  private Func<TInput, bool, IEnumerable<string>> ExpectedItem()
    => (input, exclude) => ExpectedItem(input, "  exclude: " + exclude.TrueFalse(), []);

  private Func<TInput, bool, IEnumerable<string>> ExpectedAllItem(string ofScalar)
        => (input, exclude) => {
          var result = ExpectedItem(input, "  exclude: " + exclude.TrueFalse(), ["  scalar: " + ofScalar]);
          return ["- !_ScalarItem(" + result[0][3..] + ")", .. result[1..]];
        };
}

internal interface IScalarModelChecks<TInput, TItem>
  : ITypeModelChecks<SimpleKindModel>
  where TItem : IAstScalarItem
{
  void ScalarExpected(AstScalar<TItem> scalar, string[] expected);
  AstScalar<TItem> ScalarAst(string name, TInput[] items);
  string[] ExpectedScalar(string name, string? parent, TInput[]? items = null, IEnumerable<string>? aliases = null, IEnumerable<string>? description = null);
}
