using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Merging.Objects;

internal class MergeInputAlternates(
  ILoggerFactory logger
) : AstAlternatesMerger<IGqlpInputAlternate, IGqlpInputBase>(logger)
{ }
