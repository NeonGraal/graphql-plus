using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Merging;

internal class MergeAllTypes
  : IMerge<AstType>
{
  public bool CanMerge(AstType[] items)
    => items.Select(i => i.GetType()).Distinct().Count() == 1;

  public AstType Merge(AstType[] items) => throw new NotImplementedException();
}
