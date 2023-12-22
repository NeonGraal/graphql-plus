using GqlPlus.Verifier.Ast;

namespace GqlPlus.Verifier.Merging;

public abstract class NamedDescribedMerger<TItem>
  : NamedMerger<TItem>
  where TItem : AstNamed, IAstDescribed
{
  public override bool CanMerge(TItem[] items)
    => base.CanMerge(items)
      && items.CanMerge(item => item.Description);
}
