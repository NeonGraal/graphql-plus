using GqlPlus.Abstractions.Schema;
using GqlPlus.Token;

namespace GqlPlus.Merging.Simple;

internal class MergeAllDomains(
  ILoggerFactory logger,
  IEnumerable<IMergeAll<IGqlpDomain>> domains
) : AllMerger<IGqlpDomain>(logger, domains)
  , IMergeAll<IGqlpType>
{
  protected override string ItemMatchName => "Domain";
  protected override string ItemMatchKey(IGqlpDomain item) => item.DomainKind.ToString();

  ITokenMessages IMerge<IGqlpType>.CanMerge(IEnumerable<IGqlpType> items)
  {
    IEnumerable<IGqlpDomain> domains = items.OfType<IGqlpDomain>();

    return domains.Any() ? CanMerge(domains) : TokenMessages.New;
  }

  IEnumerable<IGqlpType> IMerge<IGqlpType>.Merge(IEnumerable<IGqlpType> items)
      => Merge(items.OfType<IGqlpDomain>()).Cast<IGqlpType>();
}
