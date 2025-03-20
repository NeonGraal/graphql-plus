using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Merging;

internal abstract class AstDescribedMerger<TItem>(
  ILoggerFactory logger
) : DistinctMerger<TItem>(logger)
  where TItem : IGqlpError, IGqlpDescribed
{ }
