using GqlPlus.Ast.Schema;

namespace GqlPlus.Merging.Simple;

internal class MergeAllDomains(
  IMergerRepository mergers
) : AllMerger<IAstDomain>(mergers)
  , IMergeAll<IAstType>
{
  protected override string ItemMatchName => "Domain";
  protected override string ItemMatchKey(IAstDomain item) => item.DomainKind.ToString();

  IMessages IMerge<IAstType>.CanMerge(IEnumerable<IAstType> items)
  {
    IEnumerable<IAstDomain> domains = items?.OfType<IAstDomain>() ?? [];

    return domains.Any() ? base.CanMerge(domains) : Messages.New;
  }

  IEnumerable<IAstType> IMerge<IAstType>.Merge(IEnumerable<IAstType> items)
      => Merge(items?.OfType<IAstDomain>() ?? []).Cast<IAstType>();

  internal static MergeAllDomains Factory(IMergerRepository m) => new(m);
}
