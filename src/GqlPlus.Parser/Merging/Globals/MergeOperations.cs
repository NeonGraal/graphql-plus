using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Merging.Globals;

internal class MergeOperations(
  IMergerRepository mergers
) : AstAliasedMerger<IGqlpSchemaOperation>(mergers)
{
  protected override string ItemMatchName => "Category";
  protected override string ItemMatchKey(IGqlpSchemaOperation item)
    => item.Category.ToString();
}
