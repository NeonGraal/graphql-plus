using GqlPlus.Verifier.Ast;

namespace GqlPlus.Verifier.Merging;

public abstract class NamedMerger<TItem>
  : DistinctMerger<TItem>
  where TItem : AstNamed
{
  protected override string ItemGroupKey(TItem item) => item.Name;
}
