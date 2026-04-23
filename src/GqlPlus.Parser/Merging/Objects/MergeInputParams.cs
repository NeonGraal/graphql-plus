using GqlPlus.Ast.Schema;
using GqlPlus.Ast.Schema.Objects;

namespace GqlPlus.Merging.Objects;

internal class MergeInputParams(
  IMergerRepository mergers
) : DistinctMerger<IAstInputParam>(mergers)
{
  protected override string ItemGroupKey(IAstInputParam item)
    => item.Type.FullType;

  protected override string ItemMatchName => "Modifiers";
  protected override string ItemMatchKey(IAstInputParam item)
    => item.Modifiers.AsString().Joined();

  protected override IMessages CanMergeGroup(IGrouping<string, IAstInputParam> group)
    => base.CanMergeGroup(group)
      .Add(group.CanMerge(item => item.DefaultValue, mergers.MergerFor<IAstConstant>()));

  protected override IAstInputParam MergeGroup(IEnumerable<IAstInputParam> group)
  {
    InputParamAst first = (InputParamAst)group.First();
    if (first.Type is IAstSetDescription descrType) {
      descrType.MakeDescription(group);
    }

    return first with {
      DefaultValue = group.Merge(item => item.DefaultValue, mergers.MergerFor<IAstConstant>()).FirstOrDefault(),
    };
  }

  internal static MergeInputParams Factory(IMergerRepository m) => new(m);
}
