using GqlPlus.Abstractions.Schema;
using GqlPlus.Merging.Simple;

namespace GqlPlus.Merging.Schema.Simple;

public abstract class TestDomainMerger<TItem, TItemInput>
  : TestTypedMerger<IGqlpDomain, IGqlpDomain<TItem>, string, TItem>
  where TItem : class, IGqlpDomainItem
{
  [Theory, RepeatData]
  public void CanMerge_SameKinds_ReturnsGood(string name)
  {
    IGqlpDomain<TItem>[] items = [MakeDomain(name), MakeDomain(name)];

    ITokenMessages result = Merger.CanMerge(items);

    result.ShouldBeEmpty();
  }

  [Theory, RepeatData]
  public void CanMerge_DifferentKinds_ReturnsErrors(string name)
  {
    DomainKind domainKind = MakeDescribed(name).DomainKind == DomainKind.String
      ? DomainKind.Number
      : DomainKind.String;
    IGqlpDomain<TItem>[] items = [MakeDomain(name, kind: domainKind), MakeDomain(name)];

    ITokenMessages result = Merger.CanMerge(items);

    result.ShouldNotBeEmpty();
  }

  [Theory, RepeatData]
  public void CanMerge_ItemsCantMerge_ReturnsErrors(string name, TItemInput input)
  {
    IGqlpDomain<TItem>[] items = [
      MakeDomain(name, items: MakeItems(input)),
      MakeDomain(name, items: MakeItems(input)),
    ];
    MergeItems.CanMerge([]).ReturnsForAnyArgs(new TokenMessages(new TokenMessage(AstNulls.At, "Error!")));

    ITokenMessages result = Merger.CanMerge(items);

    result.ShouldNotBeEmpty();
  }

  internal readonly IMerge<TItem> MergeItems;
  internal abstract IDomainMerger<TItem> Merger { get; }

  protected TestDomainMerger()
    => MergeItems = Merger<TItem>();

  // internal override AstTypeMerger<IGqlpDomain, IGqlpDomain<TItem>, string, TItem> MergerTyped => Merger;

  protected abstract TItem[] MakeItems(TItemInput input);
  protected abstract IGqlpDomain<TItem> MakeDomain(
    string name,
    string[]? aliases = null,
    string description = "",
    string? parent = default,
    DomainKind? kind = null,
    IEnumerable<TItem>? items = null
  );

  protected override IGqlpDomain<TItem> MakeTyped(string name, string[]? aliases = null, string description = "", string? parent = default)
    => MakeDomain(name, aliases, description, parent);

  protected override string MakeParent(string parent)
    => parent;
}
