using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Merging.Objects;

internal class MergeDualFields(
  IMergerRepository mergers
) : AstObjectFieldsMerger<IGqlpDualField>(mergers.LoggerFactory)
{ }
