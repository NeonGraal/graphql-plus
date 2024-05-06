﻿using GqlPlus.Ast.Schema.Simple;

namespace GqlPlus.Merging.Simple;

internal abstract class AstDomainItemMerger<TItem>(
  ILoggerFactory logger
) : DistinctMerger<TItem>(logger)
  where TItem : AstDomainItem
{
  protected override string ItemMatchKey(TItem item)
    => item.Excludes.ToString();

  protected override TItem MergeGroup(IEnumerable<TItem> group)
    => group.First();
}
