using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Merging.Globals;

internal class MergeOperations(
  ILoggerFactory logger
) : AstAliasedMerger<IGqlpSchemaOperation>(logger)
{
  protected override string ItemMatchName => "Category";
  protected override string ItemMatchKey(IGqlpSchemaOperation item)
    => item.Category.ToString();
}
