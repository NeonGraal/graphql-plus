using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Merging;

internal class MergeAllScalars(
  IEnumerable<IMergeAll<AstScalar>> scalars
) : AllMerger<AstScalar>(scalars), IMergeAll<AstType>
{
  bool IMerge<AstType>.CanMerge(IEnumerable<AstType> items)
  {
    var scalars = items.OfType<AstScalar>();

    return !scalars.Any() || CanMerge(scalars);
  }

  IEnumerable<AstType> IMerge<AstType>.Merge(IEnumerable<AstType> items)
      => Merge(items.OfType<AstScalar>());
}
