using GqlPlus.Ast.Schema;

namespace GqlPlus.Merging.Globals;

internal class MergeOperations(
  IMergerRepository mergers
) : AstAliasedMerger<IAstSchemaOperation>(mergers)
{
  protected override string ItemMatchName => "Category";

  protected override string ItemMatchKey(IAstSchemaOperation item)
    => item.Category.ToString();

  internal static MergeOperations Factory(IMergerRepository r) => new(r);
}
