using GqlPlus.Verifier.Ast.Schema.Simple;
using GqlPlus.Verifier.Rendering;

namespace GqlPlus.Verifier.Modelling.Simple;

public abstract class TestDomainModel<TItem, TAstItem>
  : TestTypeModel<SimpleKindModel>
  where TAstItem : AstAbbreviated, IAstDomainItem
{
  [Theory, RepeatData(Repeats)]
  public void Model_Members(string name, TItem[] members)
    => DomainChecks
    .AddTypeKinds(TypeKindModel.Basic, members)
    .DomainExpected(
      DomainChecks.DomainAst(name, members),
      DomainChecks.ExpectedDomain(new(name, items: members)));
  [SkippableTheory, RepeatData(Repeats)]
  public void Model_MembersParent(string name, string parent, TItem[] parentMembers)
    => DomainChecks
    .SkipIf(string.Equals(name, parent, StringComparison.Ordinal))
    .AddTypeKinds(TypeKindModel.Basic, parentMembers)
    .AddParent(DomainChecks.NewParent(parent, parentMembers))
    .DomainExpected(
      DomainChecks.DomainAst(name, []) with { Parent = parent },
      DomainChecks.ExpectedDomain(new(name, parent, otherItems: parentMembers.ParentItems(parent))));

  [SkippableTheory, RepeatData(Repeats)]
  public void Model_MembersGrandParent(string name, string parent, string grandParent, TItem[] grandParentMembers)
    => DomainChecks
    .SkipIf(string.Equals(parent, grandParent, StringComparison.Ordinal))
    .AddTypeKinds(TypeKindModel.Basic, grandParentMembers)
    .AddParent(DomainChecks.NewParent(parent, [], grandParent))
    .AddParent(DomainChecks.NewParent(grandParent, grandParentMembers))
    .DomainExpected(
      DomainChecks.DomainAst(name, []) with { Parent = parent },
      DomainChecks.ExpectedDomain(new(name, parent, otherItems: grandParentMembers.ParentItems(grandParent))));

  [Theory, RepeatData(Repeats)]
  public void Model_All(string name, string contents, string[] aliases, string parent, TItem[] members)
    => DomainChecks
    .AddTypeKinds(TypeKindModel.Basic, members)
    .DomainExpected(
      DomainChecks.DomainAst(name, members) with {
        Aliases = aliases,
        Description = contents,
        Parent = parent,
      },
      DomainChecks.ExpectedDomain(new(name, parent, members, aliases: aliases, description: contents)));

  internal override ICheckTypeModel<SimpleKindModel> TypeChecks => DomainChecks;

  internal abstract ICheckDomainModel<TItem, TAstItem> DomainChecks { get; }
}

internal abstract class CheckDomainModel<TItem, TAstItem, TItemModel>(
  DomainKind kind,
  IDomainModeller<TAstItem, TItemModel> modeller
) : CheckTypeModel<AstDomain<TAstItem>, SimpleKindModel, BaseDomainModel<TItemModel>>(modeller, SimpleKindModel.Domain)
  , ICheckDomainModel<TItem, TAstItem>
  where TAstItem : AstAbbreviated, IAstDomainItem
  where TItemModel : IBaseDomainItemModel
{
  internal string[] ExpectedDomain(ExpectedDomainInput<TItem> input)
    => [$"!_Domain{kind}",
        .. input.Aliases ?? [],
        .. AllItems(input.AllItems),
        .. input.Description ?? [],
        $"domain: !_DomainKind {kind}",
        .. Items(input.Items),
        "name: " + input.Name,
        .. input.Parent.TypeRefFor(SimpleKindModel.Domain),
        "typeKind: !_TypeKind Domain"];

  string[] ICheckDomainModel<TItem, TAstItem>.ExpectedDomain(ExpectedDomainInput<TItem> input) => ExpectedDomain(input);

  AstDomain<TAstItem> ICheckDomainModel<TItem, TAstItem>.DomainAst(string name, TItem[] items)
    => NewDomainAst(name, items);

  void ICheckDomainModel<TItem, TAstItem>.DomainExpected(AstDomain<TAstItem> domain, string[] expected)
    => AstExpected(domain, expected);

  BaseTypeModel IParentModel<TItem>.NewParent(string name, TItem[] members, string? parent)
    => _modeller.ToModel(NewDomainAst(name, members) with { Parent = parent }, TypeKinds);

  protected IEnumerable<string> Items(TItem[]? inputs)
    => Items("items:", inputs, ExpectedItem());

  protected IEnumerable<string> AllItems((string Domain, TItem Item)[]? inputs)
    => Items("allItems:", inputs, ExpectedAllItem());

  protected override string[] ExpectedType(ExpectedTypeInput<string> input)
    => ExpectedDomain(new ExpectedDomainInput<TItem>(input));

  internal override AstDomain<TAstItem> NewTypeAst(string name, string? parent, string description)
    => new(AstNulls.At, name, description, kind) { Parent = parent };

  protected override string[] ExpectedParent(string? parent)
    => parent.TypeRefFor(TypeKind);

  protected abstract string[] ExpectedItem(TItem input, string exclude, string[] domain);

  protected abstract TAstItem[]? DomainItems(TItem[]? inputs);

  private AstDomain<TAstItem> NewDomainAst(string name, TItem[] items)
    => new(AstNulls.At, name, kind, DomainItems(items) ?? []);

  private IEnumerable<string> Items<TInput>(string field, TInput[]? inputs, Func<TInput, bool, IEnumerable<string>> mapping)
  {
    var exclude = true;

    return ItemsExpected(field, inputs, i => mapping(i, exclude = !exclude));
  }

  private Func<TItem, bool, IEnumerable<string>> ExpectedItem()
    => (input, exclude) => ExpectedItem(input, "  exclude: " + exclude.TrueFalse(), []);

  private Func<(string Domain, TItem Item), bool, IEnumerable<string>> ExpectedAllItem()
        => (input, exclude) => {
          var result = ExpectedItem(input.Item, "  exclude: " + exclude.TrueFalse(), ["  domain: " + input.Domain]);
          return ["- !_DomainItem(" + result[0][3..] + ")", .. result[1..]];
        };
}

internal interface ICheckDomainModel<TItem, TAstItem>
  : ICheckTypeModel<SimpleKindModel>, IParentModel<TItem>
  where TAstItem : AstAbbreviated, IAstDomainItem
{
  void DomainExpected(AstDomain<TAstItem> domain, string[] expected);
  AstDomain<TAstItem> DomainAst(string name, TItem[] items);
  string[] ExpectedDomain(ExpectedDomainInput<TItem> input);
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
    Description = input.Description;
  }
}
