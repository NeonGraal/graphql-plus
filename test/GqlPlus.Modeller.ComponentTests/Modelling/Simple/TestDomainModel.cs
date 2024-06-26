using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Simple;

namespace GqlPlus.Modelling.Simple;

public abstract class TestDomainModel<TValue, TItem>
  : TestTypeModel<SimpleKindModel>
  where TItem : IGqlpDomainItem
{
  [Theory, RepeatData(Repeats)]
  public void Model_Members(string name, TValue[] members)
    => DomainChecks
    .AddTypeKinds(TypeKindModel.Basic, members)
    .DomainExpected(
      DomainChecks.DomainAst(name, null, [], null, members),
      DomainChecks.ExpectedDomain(new(name, items: members)));
  [SkippableTheory, RepeatData(Repeats)]
  public void Model_MembersParent(string name, string parent, TValue[] parentMembers)
    => DomainChecks
    .SkipIf(string.Equals(name, parent, StringComparison.Ordinal))
    .AddTypeKinds(TypeKindModel.Basic, parentMembers)
    .AddParent(DomainChecks.NewParent(parent, parentMembers))
    .DomainExpected(
      DomainChecks.DomainAst(name, null, [], parent, []),
      DomainChecks.ExpectedDomain(new(name, parent, otherItems: parentMembers.ParentItems(parent))));

  [SkippableTheory, RepeatData(Repeats)]
  public void Model_MembersGrandParent(string name, string parent, string grandParent, TValue[] grandParentMembers)
    => DomainChecks
    .SkipIf(string.Equals(parent, grandParent, StringComparison.Ordinal))
    .AddTypeKinds(TypeKindModel.Basic, grandParentMembers)
    .AddParent(DomainChecks.NewParent(parent, [], grandParent))
    .AddParent(DomainChecks.NewParent(grandParent, grandParentMembers))
    .DomainExpected(
      DomainChecks.DomainAst(name, null, [], parent, []),
      DomainChecks.ExpectedDomain(new(name, parent, otherItems: grandParentMembers.ParentItems(grandParent))));

  [Theory, RepeatData(Repeats)]
  public void Model_All(string name, string contents, string[] aliases, string parent, TValue[] members)
    => DomainChecks
    .AddTypeKinds(TypeKindModel.Basic, members)
    .DomainExpected(
      DomainChecks.DomainAst(name, contents, aliases, parent, members),
      DomainChecks.ExpectedDomain(new(name, parent, members, aliases: aliases, description: contents)));

  internal override ICheckTypeModel<SimpleKindModel> TypeChecks => DomainChecks;

  internal abstract ICheckDomainModel<TValue, TItem> DomainChecks { get; }
}

internal abstract class CheckDomainModel<TValue, TAstItem, TItem, TItemModel>(
  DomainKind kind,
  IDomainModeller<TItem, TItemModel> modeller,
  IRenderer<BaseDomainModel<TItemModel>> rendering
) : CheckTypeModel<IGqlpDomain<TItem>, SimpleKindModel, BaseDomainModel<TItemModel>>(modeller, rendering, SimpleKindModel.Domain)
  , ICheckDomainModel<TValue, TItem>
  where TAstItem : AstAbbreviated, TItem
  where TItem : IGqlpDomainItem
  where TItemModel : BaseDomainItemModel
{
  internal string[] ExpectedDomain(ExpectedDomainInput<TValue> input)
    => [$"!_Domain{kind}",
      .. input.ExpectedAliases ?? [],
      .. AllItems(input.AllItems),
      .. input.ExpectedDescription ?? [],
      $"domainKind: !_DomainKind {kind}",
      .. Items(input.Items),
      "name: " + input.Name,
      .. input.Parent.TypeRefFor(SimpleKindModel.Domain),
      "typeKind: !_TypeKind Domain"];

  string[] ICheckDomainModel<TValue, TItem>.ExpectedDomain(ExpectedDomainInput<TValue> input) => ExpectedDomain(input);

  IGqlpDomain<TItem> ICheckDomainModel<TValue, TItem>.DomainAst(string name, string? description, string[] aliases, string? parent, TValue[] items)
    => NewDomainAst(name, description, aliases, parent, items);

  void ICheckDomainModel<TValue, TItem>.DomainExpected(IGqlpDomain<TItem> domain, string[] expected)
    => AstExpected(domain, expected);

  BaseTypeModel IParentModel<TValue>.NewParent(string name, TValue[] members, string? parent)
    => _modeller.ToModel(NewDomainAst(name, null, [], null, members) with { Parent = parent }, TypeKinds);

  protected IEnumerable<string> Items(TValue[]? inputs)
    => Items("items:", inputs, ExpectedItem());

  protected IEnumerable<string> AllItems((string Domain, TValue Item)[]? inputs)
    => Items("allItems:", inputs, ExpectedAllItem());

  protected override string[] ExpectedType(ExpectedTypeInput<string> input)
    => ExpectedDomain(new ExpectedDomainInput<TValue>(input));

  internal override AstDomain<TAstItem, TItem> NewTypeAst(string name, string? parent, string? description, string[]? aliases)
    => new(AstNulls.At, name, description ?? "", kind) {
      Parent = parent,
      Aliases = aliases ?? [],
    };

  protected override string[] ExpectedParent(string? parent)
    => parent.TypeRefFor(TypeKind);

  protected abstract string[] ExpectedItem(TValue input, string exclude, string[] domain);

  protected abstract TAstItem[]? DomainItems(TValue[]? inputs);

  private AstDomain<TAstItem, TItem> NewDomainAst(string name, string? description, string[] aliases, string? parent, TValue[] items)
    => new(AstNulls.At, name, kind, DomainItems(items) ?? []) {
      Description = description ?? "",
      Aliases = aliases ?? [],
      Parent = parent,
    };

  private IEnumerable<string> Items<TInput>(string field, TInput[]? inputs, Func<TInput, bool, IEnumerable<string>> mapping)
  {
    bool exclude = true;

    return ItemsExpected(field, inputs, i => mapping(i, exclude = !exclude));
  }

  private Func<TValue, bool, IEnumerable<string>> ExpectedItem()
    => (input, exclude) => ExpectedItem(input, "  exclude: " + exclude.TrueFalse(), []);

  private Func<(string Domain, TValue Item), bool, IEnumerable<string>> ExpectedAllItem()
        => (input, exclude) => {
          string[] result = ExpectedItem(input.Item, "  exclude: " + exclude.TrueFalse(), ["  domain: " + input.Domain]);
          return ["- !_DomainItem(" + result[0][3..] + ")", .. result[1..]];
        };
}

internal interface ICheckDomainModel<TValue, TItem>
  : ICheckTypeModel<SimpleKindModel>, IParentModel<TValue>
  where TItem : IGqlpDomainItem
{
  void DomainExpected(IGqlpDomain<TItem> domain, string[] expected);
  IGqlpDomain<TItem> DomainAst(string name, string? description, string[] aliases, string? parent, TValue[] items);
  string[] ExpectedDomain(ExpectedDomainInput<TValue> input);
}

internal sealed class ExpectedDomainInput<TItem>(
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

  internal ExpectedDomainInput(ExpectedTypeInput<string> input)
    : this(input.Name, input.Parent)
  {
    Aliases = input.Aliases;
    ExpectedAliases = input.ExpectedAliases;
    Description = input.Description;
    ExpectedDescription = input.ExpectedDescription;
  }
}
