using GqlPlus.Abstractions.Schema;
using GqlPlus.Merging.Simple;

namespace GqlPlus.Merging.Schema.Simple;

public abstract class TestDomainMerger<TItem, TItemInput>
  : TestSimpleMerger<IAstDomain, IAstDomain<TItem>, TItem, TItemInput>
  where TItem : class, IAstDomainItem
{
  [Theory, RepeatData]
  public void CanMerge_SameKinds_ReturnsGood(string name)
  {
    IAstDomain<TItem>[] items = [MakeDomain(name), MakeDomain(name)];

    IMessages result = Merger.CanMerge(items);

    result.ShouldBeEmpty();
  }

  [Theory, RepeatData]
  public void CanMerge_DifferentKinds_ReturnsErrors(string name)
  {
    DomainKind domainKind = MakeDescribed(name).DomainKind == DomainKind.String
      ? DomainKind.Number
      : DomainKind.String;
    IAstDomain<TItem>[] items = [MakeDomain(name, kind: domainKind), MakeDomain(name)];

    IMessages result = Merger.CanMerge(items);

    result.ShouldNotBeEmpty();
  }

  internal abstract IDomainMerger<TItem> Merger { get; }

  // internal override AstTypeMerger<IAstDomain, IAstDomain<TItem>, string, TItem> MergerTyped => Merger;

  protected abstract IAstDomain<TItem> MakeDomain(
    string name,
    string[]? aliases = null,
    string description = "",
    IAstTypeRef? parent = default,
    DomainKind? kind = null,
    IEnumerable<TItem>? items = null
  );
  protected override IAstDomain<TItem> MakeSimple(string name, string[]? aliases = null, string description = "", IAstTypeRef? parent = null, IEnumerable<TItem>? items = null)
    => MakeDomain(name, aliases, description, parent, null, items);
}
