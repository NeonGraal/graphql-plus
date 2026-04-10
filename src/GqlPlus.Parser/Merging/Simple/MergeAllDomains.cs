using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Merging.Simple;

internal class MergeAllDomains(
  IMergerRepository mergers
) : AllMerger<IGqlpDomain>(mergers)
  , IMergeAll<IAstType>
{
  protected override string ItemMatchName => "Domain";
  protected override string ItemMatchKey(IGqlpDomain item) => item.DomainKind.ToString();

  IMessages IMerge<IAstType>.CanMerge(IEnumerable<IAstType> items)
  {
    IEnumerable<IGqlpDomain> domains = items?.OfType<IGqlpDomain>() ?? [];

    return domains.Any() ? base.CanMerge(domains) : Messages.New;
  }

  IEnumerable<IAstType> IMerge<IAstType>.Merge(IEnumerable<IAstType> items)
      => Merge(items?.OfType<IGqlpDomain>() ?? []).Cast<IAstType>();
}
