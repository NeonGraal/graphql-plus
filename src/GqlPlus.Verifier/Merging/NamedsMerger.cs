using GqlPlus.Verifier.Ast;

namespace GqlPlus.Verifier.Merging;

public abstract class NamedsMerger<TItem>
  : DescribedsMerger<TItem>
  where TItem : AstDescribed
{
  protected override string ItemGroupKey(TItem item)
    => item.Name;
}
