using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast;
using GqlPlus.Token;

namespace GqlPlus.Merging.Simple;

internal class MergeAllDomains(
  ILoggerFactory logger,
  IEnumerable<IMergeAll<IGqlpDomain>> mergeDomains
) : AllMerger<IGqlpDomain>(logger, mergeDomains)
  , IMergeAll<IGqlpType>
{
  protected override string ItemMatchName => "Domain";
  protected override string ItemMatchKey(IGqlpDomain item) => item.DomainKind.ToString();

  IMessages IMerge<IGqlpType>.CanMerge(IEnumerable<IGqlpType> items)
  {
    IEnumerable<IGqlpDomain> domains = items?.OfType<IGqlpDomain>() ?? [];

    return domains.Any() ? base.CanMerge(domains) : Messages.New;
  }

  IEnumerable<IGqlpType> IMerge<IGqlpType>.Merge(IEnumerable<IGqlpType> items)
      => Merge(items?.OfType<IGqlpDomain>() ?? []).Cast<IGqlpType>();
}
