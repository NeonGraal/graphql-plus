using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Merging.Simple;

internal class MergeEnumLabels(
  IMergerRepository mergers
) : AstAliasedMerger<IAstEnumLabel>(mergers)
{
  protected override string ItemMatchName => "Name";
  protected override string ItemMatchKey(IAstEnumLabel item)
    => item.Name;
}
