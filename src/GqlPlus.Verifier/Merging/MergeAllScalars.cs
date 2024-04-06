using GqlPlus.Verifier.Ast.Schema;
using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Merging;

internal class MergeAllScalars(
  ILoggerFactory logger,
  IEnumerable<IMergeAll<AstScalar>> scalars
) : AllMerger<AstScalar>(logger, scalars)
  , IMergeAll<AstType>
{
  protected override string ItemMatchName => "Domain";
  protected override string ItemMatchKey(AstScalar item) => item.Domain.ToString();

  ITokenMessages IMerge<AstType>.CanMerge(IEnumerable<AstType> items)
  {
    var scalars = items.OfType<AstScalar>();

    return scalars.Any() ? CanMerge(scalars) : new TokenMessages();
  }

  IEnumerable<AstType> IMerge<AstType>.Merge(IEnumerable<AstType> items)
      => Merge(items.OfType<AstScalar>());
}
