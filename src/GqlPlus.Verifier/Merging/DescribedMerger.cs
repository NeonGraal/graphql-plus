using GqlPlus.Verifier.Ast;

namespace GqlPlus.Verifier.Merging;

public class DescribedMerger<TItem> : IMerge<TItem>
  where TItem : IAstDescribed
{
  public virtual bool CanMerge(TItem[] items)
    => items.CanMerge(item => item.Description);

  public virtual TItem Merge(TItem[] items) => throw new NotImplementedException();
}
