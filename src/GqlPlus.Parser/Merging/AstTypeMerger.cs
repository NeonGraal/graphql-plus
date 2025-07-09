﻿using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Merging;

internal abstract class AstTypeMerger<TAst, TType, TParent, TItem>(
  ILoggerFactory logger,
  IMerge<TItem> mergeItems
) : AstAliasedMerger<TType>(logger)
  , IMergeAll<TAst>
  where TAst : IGqlpType
  where TType : IGqlpType<TParent>, TAst
  where TParent : IGqlpDescribed, IEquatable<TParent>
  where TItem : IGqlpError
{
  internal abstract IEnumerable<TItem> GetItems(TType type);

  protected override IMessages CanMergeGroup(IGrouping<string, TType> group)
    => base.CanMergeGroup(group)
    .Add(group.ManyCanMerge(GetItems, mergeItems));

  internal abstract TType SetItems(TType input, IEnumerable<TItem> items);

  protected override TType MergeGroup(IEnumerable<TType> group)
  {
    IEnumerable<TItem> items = group.ManyMerge(GetItems, mergeItems);

    return SetItems(base.MergeGroup(group), items);
  }

  IMessages IMerge<TAst>.CanMerge(IEnumerable<TAst> items)
  {
    IEnumerable<TType> aliases = items.OfType<TType>();

    return aliases.Any() ? CanMerge(aliases) : new Messages();
  }

  IEnumerable<TAst> IMerge<TAst>.Merge(IEnumerable<TAst> items)
  {
    TType[] typeItems = [.. items.OfType<TType>()];
    TType[] merged = [.. base.Merge(typeItems)];
    TAst[] cast = [.. merged.Cast<TAst>()];
    return cast;
  }
}
