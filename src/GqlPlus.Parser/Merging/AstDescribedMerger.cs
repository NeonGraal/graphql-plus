using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Merging;

internal abstract class AstDescribedMerger<TItem>(
  IMergerRepository mergers
) : DistinctMerger<TItem>(mergers)
  where TItem : IAstError, IGqlpDescribed
{ }
