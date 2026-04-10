using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Merging;

internal abstract class AstTypeMerger<TAst, TType, TParent, TItem>(
  IMergerRepository mergers
) : AstAliasedMerger<TType>(mergers)
  , IMergeAll<TAst>
  where TAst : IAstType
  where TType : IAstType<TParent>, TAst
  where TParent : IAstDescribed, IEquatable<TParent>
  where TItem : IAstError
{
  private readonly IMerge<TItem> _mergeItems = mergers.MergerFor<TItem>();

  internal abstract IEnumerable<TItem> GetItems(TType type);

  protected override IMessages CanMergeGroup(IGrouping<string, TType> group)
    => base.CanMergeGroup(group)
    .Add(group.ManyCanMerge(GetItems, _mergeItems));

  internal abstract TType SetItems(TType input, IEnumerable<TItem> items);

  protected override TType MergeGroup(IEnumerable<TType> group)
  {
    IEnumerable<TItem> items = group.ManyMerge(GetItems, _mergeItems);

    return SetItems(base.MergeGroup(group), items);
  }

  IMessages IMerge<TAst>.CanMerge(IEnumerable<TAst> items)
  {
    IEnumerable<TType> aliases = items.OfType<TType>();

    return aliases.Any() ? CanMerge(aliases) : new Messages();
  }

  IEnumerable<TAst> IMerge<TAst>.Merge(IEnumerable<TAst> items)
  {
    TType[] typeItems = [.. items?.OfType<TType>() ?? []];
    TType[] merged = [.. base.Merge(typeItems)];
    TAst[] cast = [.. merged.Cast<TAst>()];
    return cast;
  }
}
