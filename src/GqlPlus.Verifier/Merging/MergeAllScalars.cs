using GqlPlus.Verifier.Ast.Schema;
using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Merging;

internal class MergeAllScalars(
  IEnumerable<IMergeAll<AstScalar>> scalars
) : AllMerger<AstScalar>(scalars), IMergeAll<AstType>
{
  ITokenMessages IMerge<AstType>.CanMerge(IEnumerable<AstType> items)
  {
    var scalars = items.OfType<AstScalar>();

    return scalars.Any() ? CanMerge(scalars) : new TokenMessages();
  }

  IEnumerable<AstType> IMerge<AstType>.Merge(IEnumerable<AstType> items)
      => Merge(items.OfType<AstScalar>());
}
