using GqlPlus.Verifier.Ast.Schema;
using GqlPlus.Verifier.Rendering;

namespace GqlPlus.Verifier.Modelling.Types;

public abstract class TestScalarModel<TItem, TAstItem>
  : TestTypeModel<SimpleKindModel>
  where TAstItem : IAstScalarItem
{
  [Theory, RepeatData(Repeats)]
  public void Model_Members(string name, TItem[] members)
    => ScalarChecks
    .AddTypeKinds(TypeKindModel.Basic, members)
    .ScalarExpected(
      ScalarChecks.ScalarAst(name, members),
      ScalarChecks.ExpectedScalar(new(name, items: members)));
  [SkippableTheory, RepeatData(Repeats)]
  public void Model_MembersParent(string name, string parent, TItem[] parentMembers)
    => ScalarChecks
    .SkipIf(string.Equals(name, parent, StringComparison.Ordinal))
    .AddTypeKinds(TypeKindModel.Basic, parentMembers)
    .AddParent(ScalarChecks.NewParent(parent, parentMembers))
    .ScalarExpected(
      ScalarChecks.ScalarAst(name, []) with { Parent = parent },
      ScalarChecks.ExpectedScalar(new(name, parent, otherItems: parentMembers.ParentItems(parent))));

  [SkippableTheory, RepeatData(Repeats)]
  public void Model_MembersGrandParent(string name, string parent, string grandParent, TItem[] grandParentMembers)
    => ScalarChecks
    .SkipIf(string.Equals(parent, grandParent, StringComparison.Ordinal))
    .AddTypeKinds(TypeKindModel.Basic, grandParentMembers)
    .AddParent(ScalarChecks.NewParent(parent, [], grandParent))
    .AddParent(ScalarChecks.NewParent(grandParent, grandParentMembers))
    .ScalarExpected(
      ScalarChecks.ScalarAst(name, []) with { Parent = parent },
      ScalarChecks.ExpectedScalar(new(name, parent, otherItems: grandParentMembers.ParentItems(grandParent))));

  [Theory, RepeatData(Repeats)]
  public void Model_All(string name, string contents, string[] aliases, string parent, TItem[] members)
    => ScalarChecks
    .AddTypeKinds(TypeKindModel.Basic, members)
    .ScalarExpected(
      ScalarChecks.ScalarAst(name, members) with {
        Aliases = aliases,
        Description = contents,
        Parent = parent,
      },
      ScalarChecks.ExpectedScalar(new(name, parent, members, aliases: aliases, description: contents)));

  internal override ICheckTypeModel<SimpleKindModel> TypeChecks => ScalarChecks;

  internal abstract ICheckScalarModel<TItem, TAstItem> ScalarChecks { get; }
}

internal abstract class CheckScalarModel<TItem, TAstItem, TItemModel>(
  ScalarDomain kind,
  IScalarModeller<TAstItem, TItemModel> modeller
) : CheckTypeModel<AstScalar<TAstItem>, SimpleKindModel, BaseScalarModel<TItemModel>>(modeller, SimpleKindModel.Scalar)
  , ICheckScalarModel<TItem, TAstItem>
  where TAstItem : IAstScalarItem
  where TItemModel : IBaseScalarItemModel
{
  internal string[] ExpectedScalar(ExpectedScalarInput<TItem> input)
    => [$"!_Scalar{kind}",
        .. input.Aliases ?? [],
        .. AllItems(input.AllItems),
        .. input.Description ?? [],
        .. Items(input.Items),
        "kind: !_TypeKind Scalar",
        "name: " + input.Name,
        .. input.Parent.TypeRefFor(SimpleKindModel.Scalar),
        $"scalar: !_ScalarKind {kind}"];

  string[] ICheckScalarModel<TItem, TAstItem>.ExpectedScalar(ExpectedScalarInput<TItem> input) => ExpectedScalar(input);

  AstScalar<TAstItem> ICheckScalarModel<TItem, TAstItem>.ScalarAst(string name, TItem[] items)
    => NewScalarAst(name, items);

  void ICheckScalarModel<TItem, TAstItem>.ScalarExpected(AstScalar<TAstItem> scalar, string[] expected)
    => AstExpected(scalar, expected);

  BaseTypeModel IParentModel<TItem>.NewParent(string name, TItem[] members, string? parent)
    => _modeller.ToModel(NewScalarAst(name, members) with { Parent = parent }, TypeKinds);

  protected IEnumerable<string> Items(TItem[]? inputs)
    => Items("items:", inputs, ExpectedItem());

  protected IEnumerable<string> AllItems((string Scalar, TItem Item)[]? inputs)
    => Items("allItems:", inputs, ExpectedAllItem());

  protected override string[] ExpectedType(ExpectedTypeInput<string> input)
    => ExpectedScalar(new ExpectedScalarInput<TItem>(input));

  internal override AstScalar<TAstItem> NewTypeAst(string name, string? parent, string description)
    => new(AstNulls.At, name, description, kind) { Parent = parent };

  protected override string[] ExpectedParent(string? parent)
    => parent.TypeRefFor(TypeKind);

  protected abstract string[] ExpectedItem(TItem input, string exclude, string[] scalar);

  protected abstract TAstItem[]? ScalarItems(TItem[]? inputs);

  private AstScalar<TAstItem> NewScalarAst(string name, TItem[] items)
    => new(AstNulls.At, name, kind, ScalarItems(items) ?? []);

  private IEnumerable<string> Items<TInput>(string field, TInput[]? inputs, Func<TInput, bool, IEnumerable<string>> mapping)
  {
    var exclude = true;

    return ItemsExpected(field, inputs, i => mapping(i, exclude = !exclude));
  }

  private Func<TItem, bool, IEnumerable<string>> ExpectedItem()
    => (input, exclude) => ExpectedItem(input, "  exclude: " + exclude.TrueFalse(), []);

  private Func<(string Scalar, TItem Item), bool, IEnumerable<string>> ExpectedAllItem()
        => (input, exclude) => {
          var result = ExpectedItem(input.Item, "  exclude: " + exclude.TrueFalse(), ["  scalar: " + input.Scalar]);
          return ["- !_ScalarItem(" + result[0][3..] + ")", .. result[1..]];
        };
}

internal interface ICheckScalarModel<TItem, TAstItem>
  : ICheckTypeModel<SimpleKindModel>, IParentModel<TItem>
  where TAstItem : IAstScalarItem
{
  void ScalarExpected(AstScalar<TAstItem> scalar, string[] expected);
  AstScalar<TAstItem> ScalarAst(string name, TItem[] items);
  string[] ExpectedScalar(ExpectedScalarInput<TItem> input);
}

internal sealed class ExpectedScalarInput<TItem>(
  string name,
  string? parent = null,
  TItem[]? items = null,
  (string, TItem)[]? otherItems = null,
  IEnumerable<string>? aliases = null,
  string? description = null
) : ExpectedTypeInput<string>(name, parent, aliases, description)
{
  internal TItem[] Items { get; } = items ?? [];
  internal (string, TItem)[]? AllItems { get; }
    = [.. otherItems ?? [], .. items?.ParentItems(name) ?? []];

  internal ExpectedScalarInput(ExpectedTypeInput<string> input)
    : this(input.Name, input.Parent)
  {
    Aliases = input.Aliases;
    Description = input.Description;
  }
}
