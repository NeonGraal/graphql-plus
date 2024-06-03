using GqlPlus.Ast;
using GqlPlus.Ast.Schema;
using GqlPlus.Ast.Schema.Objects;

namespace GqlPlus.Merging.Objects;

internal class MergeInputParameters(
  ILoggerFactory logger,
  IMerge<IGqlpConstant> constant
) : DistinctMerger<InputParameterAst>(logger)
{
  protected override string ItemGroupKey(InputParameterAst item)
    => item.Type.FullType;

  protected override string ItemMatchName => "Modifiers";
  protected override string ItemMatchKey(InputParameterAst item)
    => item.Modifiers.AsString().Joined();

  protected override ITokenMessages CanMergeGroup(IGrouping<string, InputParameterAst> group)
    => base.CanMergeGroup(group)
      .Add(group.CanMergeString(item => item.Type.Description))
      .Add(group.CanMerge(item => item.DefaultValue, constant));

  protected override InputParameterAst MergeGroup(IEnumerable<InputParameterAst> group)
  {
    InputParameterAst first = group.First();
    if (first.Type is IAstSetDescription descrType)
    {
      descrType.MakeDescription(group);
    }

    return first with
    {
      DefaultValue = (ConstantAst?)group.Merge(item => item.DefaultValue, constant).FirstOrDefault(),
    };
  }
}
