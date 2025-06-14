using GqlPlus.Abstractions.Schema;
using GqlPlus.Merging.Simple;

namespace GqlPlus.Merging.Schema.Simple;

public abstract class TestDomainMerger<TItem, TItemInput>
  : TestSimpleMerger<IGqlpDomain, IGqlpDomain<TItem>, TItem, TItemInput>
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

  internal abstract IDomainMerger<TItem> Merger { get; }

  // internal override AstTypeMerger<IGqlpDomain, IGqlpDomain<TItem>, string, TItem> MergerTyped => Merger;

  protected abstract IGqlpDomain<TItem> MakeDomain(
    string name,
    string[]? aliases = null,
    string description = "",
    IGqlpTypeRef? parent = default,
    DomainKind? kind = null,
    IEnumerable<TItem>? items = null
  );
  protected override IGqlpDomain<TItem> MakeSimple(string name, string[]? aliases = null, string description = "", IGqlpTypeRef? parent = null, IEnumerable<TItem>? items = null)
    => MakeDomain(name, aliases, description, parent, null, items);
}
