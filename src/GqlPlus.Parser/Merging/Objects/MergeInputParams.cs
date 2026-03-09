using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema;
using GqlPlus.Ast.Schema.Objects;

namespace GqlPlus.Merging.Objects;

internal class MergeInputParams(
  IMergerRepository mergers
) : DistinctMerger<IGqlpInputParam>(mergers.LoggerFactory)
{
  protected override string ItemGroupKey(IGqlpInputParam item)
    => item.Type.FullType;

  protected override string ItemMatchName => "Modifiers";
  protected override string ItemMatchKey(IGqlpInputParam item)
    => item.Modifiers.AsString().Joined();

  protected override IMessages CanMergeGroup(IGrouping<string, IGqlpInputParam> group)
    => base.CanMergeGroup(group)
      .Add(group.CanMerge(item => item.DefaultValue, mergers.MergerFor<IGqlpConstant>()));

  protected override IGqlpInputParam MergeGroup(IEnumerable<IGqlpInputParam> group)
  {
    InputParamAst first = (InputParamAst)group.First();
    if (first.Type is IAstSetDescription descrType) {
      descrType.MakeDescription(group);
    }

    return first with {
      DefaultValue = group.Merge(item => item.DefaultValue, mergers.MergerFor<IGqlpConstant>()).FirstOrDefault(),
    };
  }
}
