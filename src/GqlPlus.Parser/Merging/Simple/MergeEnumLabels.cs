using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Merging.Simple;

internal class MergeEnumLabels(
  IMergerRepository mergers
) : AstAliasedMerger<IGqlpEnumLabel>(mergers.LoggerFactory)
{
  protected override string ItemMatchName => "Name";
  protected override string ItemMatchKey(IGqlpEnumLabel item)
    => item.Name;
}
