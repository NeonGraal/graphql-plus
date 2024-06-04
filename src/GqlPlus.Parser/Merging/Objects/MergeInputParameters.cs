using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast;
using GqlPlus.Ast.Schema;
using GqlPlus.Ast.Schema.Objects;

namespace GqlPlus.Merging.Objects;

internal class MergeInputParameters(
  ILoggerFactory logger,
  IMerge<IGqlpConstant> constant
) : DistinctMerger<IGqlpInputParameter>(logger)
{
  protected override string ItemGroupKey(IGqlpInputParameter item)
    => item.Type.FullType;

  protected override string ItemMatchName => "Modifiers";
  protected override string ItemMatchKey(IGqlpInputParameter item)
    => item.Modifiers.AsString().Joined();

  protected override ITokenMessages CanMergeGroup(IGrouping<string, IGqlpInputParameter> group)
    => base.CanMergeGroup(group)
      .Add(group.CanMergeString(item => item.Type.Description))
      .Add(group.CanMerge(item => item.DefaultValue, constant));

  protected override InputParameterAst MergeGroup(IEnumerable<IGqlpInputParameter> group)
  {
    InputParameterAst first = (InputParameterAst)group.First();
    if (first.Type is IAstSetDescription descrType) {
      descrType.MakeDescription(group);
    }

    return first with {
      DefaultValue = (ConstantAst?)group.Merge(item => item.DefaultValue, constant).FirstOrDefault(),
    };
  }
}
