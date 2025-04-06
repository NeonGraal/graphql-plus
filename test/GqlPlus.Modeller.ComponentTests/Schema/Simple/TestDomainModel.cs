using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Simple;
using GqlPlus.Modelling.Simple;
using GqlPlus.Resolving;

namespace GqlPlus.Schema.Simple;

public abstract class TestDomainModel<TValue, TItem, TItemModel>(
  ICheckDomainModel<TValue, TItem, TItemModel> domainChecks
) : TestTypeModel<SimpleKindModel, BaseDomainModel<TItemModel>>(domainChecks)
  where TItem : IGqlpDomainItem
  where TItemModel : BaseDomainItemModel
{
  [Theory, RepeatData]
  public void Model_Labels(string name, TValue[] labels)
    => domainChecks
    .AddTypeKinds(TypeKindModel.Basic, labels)
    .DomainExpected(
      domainChecks.DomainAst(name, null, [], null, labels),
      domainChecks.ExpectedDomain(new(name, items: labels)));
  [Theory, RepeatData]
  public void Model_LabelsParent(string name, string parent, TValue[] parentLabels)
    => domainChecks
    .SkipIf(string.Equals(name, parent, StringComparison.Ordinal))
    .AddTypeKinds(TypeKindModel.Basic, parentLabels)
    .AddParent(domainChecks.NewParent(parent, parentLabels))
    .DomainExpected(
      domainChecks.DomainAst(name, null, [], parent, []),
      domainChecks.ExpectedDomain(new(name, parent, otherItems: parentLabels.ParentItems(parent))));

  [Theory, RepeatData]
  public void Model_LabelsGrandParent(string name, string parent, string grandParent, TValue[] grandParentLabels)
    => domainChecks
    .SkipIf(string.Equals(parent, grandParent, StringComparison.Ordinal))
    .AddTypeKinds(TypeKindModel.Basic, grandParentLabels)
    .AddParent(domainChecks.NewParent(parent, [], grandParent))
    .AddParent(domainChecks.NewParent(grandParent, grandParentLabels))
    .DomainExpected(
      domainChecks.DomainAst(name, null, [], parent, []),
      domainChecks.ExpectedDomain(new(name, parent, otherItems: grandParentLabels.ParentItems(grandParent))));

  [Theory, RepeatData]
  public void Model_All(string name, string contents, string[] aliases, string parent, TValue[] labels)
    => domainChecks
    .AddTypeKinds(TypeKindModel.Basic, labels)
    .DomainExpected(
      domainChecks.DomainAst(name, contents, aliases, parent, labels),
      domainChecks.ExpectedDomain(new(name, parent, labels, aliases: aliases, description: contents)));
}

internal abstract class CheckDomainModel<TValue, TAstItem, TItem, TItemModel>(
  DomainKind kind,
  CheckTypeInputs<IGqlpDomain<TItem>, BaseDomainModel<TItemModel>> inputs
) : CheckTypeModel<IGqlpDomain<TItem>, SimpleKindModel, BaseDomainModel<TItemModel>>(inputs, SimpleKindModel.Domain)
  , ICheckDomainModel<TValue, TItem, TItemModel>
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

  string[] ICheckDomainModel<TValue, TItem, TItemModel>.ExpectedDomain(ExpectedDomainInput<TValue> input) => ExpectedDomain(input);

  IGqlpDomain<TItem> ICheckDomainModel<TValue, TItem, TItemModel>.DomainAst(string name, string? description, string[] aliases, string? parent, TValue[] items)
    => NewDomainAst(name, description, aliases, parent, items);

  void ICheckDomainModel<TValue, TItem, TItemModel>.DomainExpected(IGqlpDomain<TItem> domain, string[] expected)
    => AstExpected(domain, expected);

  BaseTypeModel IParentModel<TValue>.NewParent(string name, TValue[] items, string? parent)
    => _modeller.ToModel(NewDomainAst(name, null, [], null, items) with { Parent = parent }, TypeKinds);

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
    => (input, exclude) => ExpectedItem(input, "    exclude: " + exclude.TrueFalse(), []);

  private Func<(string Domain, TValue Item), bool, IEnumerable<string>> ExpectedAllItem()
        => (input, exclude) => {
          string[] result = ExpectedItem(input.Item, "    exclude: " + exclude.TrueFalse(), ["    domain: " + input.Domain]);
          return ["  - !_DomainItem(" + result[0][5..] + ")", .. result[1..]];
        };
}

public record class CheckDomainInputs<TItem, TItemModel>(
    IDomainModeller<TItem, TItemModel> DomainModeller,
    IResolver<BaseDomainModel<TItemModel>> Resolver,
    IRenderer<BaseDomainModel<TItemModel>> Rendering
  ) : CheckTypeInputs<IGqlpDomain<TItem>, BaseDomainModel<TItemModel>>(DomainModeller, Resolver, Rendering)
  where TItem : IGqlpDomainItem
  where TItemModel : BaseDomainItemModel
{ }

public interface ICheckDomainModel<TValue, TItem, TItemModel>
  : ICheckTypeModel<SimpleKindModel, BaseDomainModel<TItemModel>>
  , IParentModel<TValue>
  where TItem : IGqlpDomainItem
  where TItemModel : BaseDomainItemModel
{
  void DomainExpected(IGqlpDomain<TItem> domain, string[] expected);
  IGqlpDomain<TItem> DomainAst(string name, string? description, string[] aliases, string? parent, TValue[] items);
  string[] ExpectedDomain(ExpectedDomainInput<TValue> input);
}

public sealed class ExpectedDomainInput<TItem>(
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
