using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Merging;

internal abstract class TypedMerger<TBase, TType, TParent, TItem>(
  IMerge<TItem> mergeItems
) : AliasedAllMerger<TBase, TType>
  where TBase : AstAliased
  where TType : AstType<TParent>, TBase
  where TParent : IEquatable<TParent>
{
  internal abstract IEnumerable<TItem> GetItems(TType type);

  protected override bool CanMergeGroup(IGrouping<string, TType> group)
    => base.CanMergeGroup(group)
    && group.ManyCanMerge(GetItems, mergeItems);

  internal abstract TType SetItems(TType input, IEnumerable<TItem> items);

  protected override TType MergeGroup(IEnumerable<TType> group)
  {
    var items = group.ManyMerge(GetItems, mergeItems);

    return SetItems(base.MergeGroup(group), items);
  }
}
