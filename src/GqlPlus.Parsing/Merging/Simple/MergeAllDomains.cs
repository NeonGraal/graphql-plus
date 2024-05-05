using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Simple;

namespace GqlPlus.Merging.Simple;

internal class MergeAllDomains(
  ILoggerFactory logger,
  IEnumerable<IMergeAll<AstDomain>> domains
) : AllMerger<AstDomain>(logger, domains)
  , IMergeAll<IGqlpType>
{
  protected override string ItemMatchName => "Domain";
  protected override string ItemMatchKey(AstDomain item) => item.DomainKind.ToString();

  ITokenMessages IMerge<IGqlpType>.CanMerge(IEnumerable<IGqlpType> items)
  {
    IEnumerable<AstDomain> domains = items.OfType<AstDomain>();

    return domains.Any() ? CanMerge(domains) : Messages();
  }

  IEnumerable<IGqlpType> IMerge<IGqlpType>.Merge(IEnumerable<IGqlpType> items)
      => Merge(items.OfType<AstDomain>()).Cast<IGqlpType>();
}
