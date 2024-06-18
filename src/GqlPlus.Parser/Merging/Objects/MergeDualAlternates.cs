using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Merging.Objects;

internal class MergeDualAlternates(
  ILoggerFactory logger
) : AstAlternatesMerger<IGqlpDualAlternate, IGqlpDualBase>(logger)
{ }
