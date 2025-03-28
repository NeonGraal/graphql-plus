using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Merging.Simple;

internal class MergeEnumLabels(
  ILoggerFactory logger
) : AstAliasedMerger<IGqlpEnumLabel>(logger)
{
  protected override string ItemMatchName => "Name";
  protected override string ItemMatchKey(IGqlpEnumLabel item)
    => item.Name;
}
