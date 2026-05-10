using GqlPlus.Ast.Schema;
using GqlPlus.Ast.Schema.Globals;

namespace GqlPlus.Merging.Globals;

internal class MergeOptionSettings(
  IMergerRepository mergers
) : GroupsMerger<IAstSchemaSetting>
{
  private readonly MergerOne<IAstConstant> _value = mergers.MergerFor<IAstConstant>();

  protected override string ItemGroupKey(IAstSchemaSetting item) => item.Name;

  protected override IMessages CanMergeGroup(IGrouping<string, IAstSchemaSetting> group)
    => group.CanMerge(item => item.Value, _value);

  protected override IAstSchemaSetting MergeGroup(IEnumerable<IAstSchemaSetting> group)
  {
    OptionSettingAst ast = (OptionSettingAst)group.First();
    return ast with {
      Value = (ConstantAst)group.Combine(item => item.Value, _value)
    };
  }

  internal static MergeOptionSettings Factory(IMergerRepository m) => new(m);
}
