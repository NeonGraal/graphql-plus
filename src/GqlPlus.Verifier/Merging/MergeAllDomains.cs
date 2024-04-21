using GqlPlus.Verifier.Ast.Schema;
using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Merging;

internal class MergeAllDomains(
  ILoggerFactory logger,
  IEnumerable<IMergeAll<AstDomain>> domains
) : AllMerger<AstDomain>(logger, domains)
  , IMergeAll<AstType>
{
  protected override string ItemMatchName => "Domain";
  protected override string ItemMatchKey(AstDomain item) => item.Domain.ToString();

  ITokenMessages IMerge<AstType>.CanMerge(IEnumerable<AstType> items)
  {
    var domains = items.OfType<AstDomain>();

    return domains.Any() ? CanMerge(domains) : new TokenMessages();
  }

  IEnumerable<AstType> IMerge<AstType>.Merge(IEnumerable<AstType> items)
      => Merge(items.OfType<AstDomain>());
}
