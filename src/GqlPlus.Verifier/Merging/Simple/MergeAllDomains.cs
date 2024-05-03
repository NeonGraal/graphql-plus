using GqlPlus.Ast.Schema;
using GqlPlus.Ast.Schema.Simple;
using GqlPlus.Token;

namespace GqlPlus.Merging.Simple;

internal class MergeAllDomains(
  ILoggerFactory logger,
  IEnumerable<IMergeAll<AstDomain>> domains
) : AllMerger<AstDomain>(logger, domains)
  , IMergeAll<AstType>
{
  protected override string ItemMatchName => "Domain";
  protected override string ItemMatchKey(AstDomain item) => item.DomainKind.ToString();

  ITokenMessages IMerge<AstType>.CanMerge(IEnumerable<AstType> items)
  {
    IEnumerable<AstDomain> domains = items.OfType<AstDomain>();

    return domains.Any() ? CanMerge(domains) : new TokenMessages();
  }

  IEnumerable<AstType> IMerge<AstType>.Merge(IEnumerable<AstType> items)
      => Merge(items.OfType<AstDomain>());
}
