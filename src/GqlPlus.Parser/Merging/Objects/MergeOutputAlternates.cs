using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Merging.Objects;

internal class MergeOutputAlternates(
  ILoggerFactory logger
) : AstAlternatesMerger<IGqlpOutputAlternate, IGqlpOutputBase>(logger)
{ }
