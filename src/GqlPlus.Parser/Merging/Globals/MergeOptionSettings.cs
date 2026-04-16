using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast;
using GqlPlus.Ast.Schema.Globals;

namespace GqlPlus.Merging.Globals;

internal class MergeOptionSettings(
  IMergerRepository mergers
) : GroupsMerger<IAstSchemaSetting>
{
  protected override string ItemGroupKey(IAstSchemaSetting item) => item.Name;

  protected override IMessages CanMergeGroup(IGrouping<string, IAstSchemaSetting> group)
    => group.CanMerge(item => item.Value, mergers.MergerFor<IAstConstant>());

  protected override IAstSchemaSetting MergeGroup(IEnumerable<IAstSchemaSetting> group)
  {
    OptionSettingAst ast = (OptionSettingAst)group.First();
    return ast with {
      Value = (ConstantAst)group.Combine(item => item.Value, mergers.MergerFor<IAstConstant>())
    };
  }

  internal static MergeOptionSettings Factory(IMergerRepository m) => new(m);
}
