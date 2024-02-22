using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Schema;
using GqlPlus.Verifier.Rendering;

namespace GqlPlus.Verifier.Modelling;

public abstract class ModelScalarTests<TInput, TItem>
  : ModelAliasedTests<string>
  where TItem : IAstScalarItem
{
  [Theory, RepeatData(Repeats)]
  public void Model_Parent(string name, string parent)
    => ScalarChecks.ScalarExpected(
      ScalarChecks.ScalarAst(name, []) with { Parent = parent },
      ScalarChecks.ExpectedScalar(name, parent));

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

  internal override IModelAliasedChecks<string> AliasedChecks => ScalarChecks;

  internal abstract IModelScalarChecks<TInput, TItem> ScalarChecks { get; }
}

internal abstract class ModelScalarChecks<TInput, TItem>
  : ModelAliasedChecks<string, AstScalar<TItem>>, IModelScalarChecks<TInput, TItem>
  where TItem : IAstScalarItem
{
  private readonly ScalarKind _kind;

  private readonly IModeller<AstScalar<TItem>> _scalar;

  protected ModelScalarChecks(ScalarKind kind, IModeller<AstScalar<TItem>> scalar)
  {
    _kind = kind;
    _scalar = scalar;
  }

  string[] IModelScalarChecks<TInput, TItem>.ExpectedScalar(
    string name,
    string? parent,
    TInput[]? items,
    IEnumerable<string>? aliases,
    IEnumerable<string>? description
  ) => [$"!_Scalar{_kind}",
        .. aliases ?? [],
        .. AllItems(items, name),
        .. description ?? [],
        .. Items(items),
        "kind: !_TypeKind Scalar",
        "name: " + name,
        .. parent.TypeRefFor(SimpleKindModel.Scalar),
        $"scalar: !_ScalarKind {_kind}"];

  AstScalar<TItem> IModelScalarChecks<TInput, TItem>.ScalarAst(string name, TInput[] items)
    => new(AstNulls.At, name, _kind, ScalarItems(items) ?? []);

  void IModelScalarChecks<TInput, TItem>.ScalarExpected(AstScalar<TItem> scalar, string[] expected)
    => AstExpected(scalar, expected);

  protected IEnumerable<string> Items(TInput[]? inputs)
    => Items("items:", inputs, ExpectedItem());

  protected IEnumerable<string> AllItems(TInput[]? inputs, string ofScalar)
    => Items("allItems:", inputs, ExpectedAllItem(ofScalar));

  protected override IRendering AstToModel(AstScalar<TItem> aliased)
    => _scalar.ToRenderer(aliased);

  protected override AstScalar<TItem> NewDescribedAst(string input, string description)
    => new(AstNulls.At, input, description, _kind);

  protected abstract string[] ExpectedItem(TInput input, string exclude, string[] scalar);

  protected abstract TItem[]? ScalarItems(TInput[]? inputs);

  private IEnumerable<string> Items(string field, TInput[]? inputs, Func<TInput, bool, IEnumerable<string>> mapping)
  {
    if (inputs == null || inputs.Length == 0) {
      return [];
    }

    var exclude = true;

    return inputs.SelectMany(i => mapping(i, exclude = !exclude)).Prepend(field);
  }

  private Func<TInput, bool, IEnumerable<string>> ExpectedItem()
    => (input, exclude) => ExpectedItem(input, "  exclude: " + exclude.TrueFalse(), []);

  private Func<TInput, bool, IEnumerable<string>> ExpectedAllItem(string ofScalar)
        => (input, exclude) => {
          var result = ExpectedItem(input, "  exclude: " + exclude.TrueFalse(), ["  scalar: " + ofScalar]);
          return ["- !_ScalarItem(" + result[0][3..] + ")", .. result[1..]];
        };
}

internal interface IModelScalarChecks<TInput, TItem>
  : IModelAliasedChecks<string>
  where TItem : IAstScalarItem
{
  void ScalarExpected(AstScalar<TItem> scalar, string[] expected);
  AstScalar<TItem> ScalarAst(string name, TInput[] items);
  string[] ExpectedScalar(string name, string? parent, TInput[]? items = null, IEnumerable<string>? aliases = null, IEnumerable<string>? description = null);
}
