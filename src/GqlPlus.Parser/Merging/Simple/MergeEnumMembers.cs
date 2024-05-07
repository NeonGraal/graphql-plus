using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Merging.Simple;

internal class MergeEnumMembers(
  ILoggerFactory logger
) : AstAliasedMerger<IGqlpEnumItem>(logger)
{
  protected override string ItemMatchName => "Name";
  protected override string ItemMatchKey(IGqlpEnumItem item)
    => item.Name;
}
