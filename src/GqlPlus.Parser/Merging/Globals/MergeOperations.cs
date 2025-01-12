using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Globals;
using GqlPlus.Ast.Schema.Objects;

namespace GqlPlus.Merging.Globals;

internal class MergeOperations(
  ILoggerFactory logger
) : AstAliasedMerger<IGqlpSchemaOperation>(logger)
{
  protected override string ItemMatchName => "Category";
  protected override string ItemMatchKey(IGqlpSchemaOperation item)
    => item.Category.ToString();
}
