using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast;
using GqlPlus.Ast.Schema.Globals;

namespace GqlPlus.Merging.Globals;

internal class MergeOptionSettings(
  IMerge<IGqlpConstant> values
) : GroupsMerger<IGqlpSchemaSetting>
{
  protected override string ItemGroupKey(IGqlpSchemaSetting item) => item.Name;

  protected override IMessages CanMergeGroup(IGrouping<string, IGqlpSchemaSetting> group)
    => group.CanMerge(item => item.Value, values);

  protected override IGqlpSchemaSetting MergeGroup(IEnumerable<IGqlpSchemaSetting> group)
  {
    OptionSettingAst ast = (OptionSettingAst)group.First();
    return ast with {
      Value = (ConstantAst)group.Combine(item => item.Value, values)
    };
  }
}
