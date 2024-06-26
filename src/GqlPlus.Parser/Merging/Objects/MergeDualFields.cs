using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Merging.Objects;

internal class MergeDualFields(
  ILoggerFactory logger
) : AstObjectFieldsMerger<IGqlpDualField>(logger)
{ }
