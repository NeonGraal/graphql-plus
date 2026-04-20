using GqlPlus.Ast.Schema;

namespace GqlPlus.Merging.Globals;

internal class MergeCategories(
  IMergerRepository mergers
) : AstAliasedMerger<IAstSchemaCategory>(mergers)
{
  protected override IMessages CanMergeGroup(IGrouping<string, IAstSchemaCategory> group)
    => base.CanMergeGroup(group)
      .Add(group.CanMergeStruct(item => item.CategoryOption));

  protected override string ItemMatchName => "Output~Modifiers~Option";
  protected override string ItemMatchKey(IAstSchemaCategory item)
    => $"{item.Output.Name}~{item.Modifiers.AsString().Joined(",")}~{item.CategoryOption}";

  internal static MergeCategories Factory(IMergerRepository m) => new(m);
}
