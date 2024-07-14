using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast;
using GqlPlus.Ast.Schema;
using GqlPlus.Ast.Schema.Objects;

namespace GqlPlus.Merging.Objects;

internal class MergeInputParams(
  ILoggerFactory logger,
  IMerge<IGqlpConstant> constant
) : DistinctMerger<IGqlpInputParam>(logger)
{
  protected override string ItemGroupKey(IGqlpInputParam item)
    => item.Type.FullType;

  protected override string ItemMatchName => "Modifiers";
  protected override string ItemMatchKey(IGqlpInputParam item)
    => item.Modifiers.AsString().Joined();

  protected override ITokenMessages CanMergeGroup(IGrouping<string, IGqlpInputParam> group)
    => base.CanMergeGroup(group)
      .Add(group.CanMergeString(item => item.Type.Description))
      .Add(group.CanMerge(item => item.DefaultValue, constant));

  protected override InputParamAst MergeGroup(IEnumerable<IGqlpInputParam> group)
  {
    InputParamAst first = (InputParamAst)group.First();
    if (first.Type is IAstSetDescription descrType) {
      descrType.MakeDescription(group);
    }

    return first with {
      DefaultValue = (ConstantAst?)group.Merge(item => item.DefaultValue, constant).FirstOrDefault(),
    };
  }
}
