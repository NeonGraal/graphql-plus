using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Objects;

namespace GqlPlus.Merging.Objects;

internal class MergeOutputFields(
  ILoggerFactory logger,
  IMerge<IGqlpInputParam> parameters
) : AstObjectFieldsMerger<IGqlpOutputField>(logger)
{
  protected override string ItemMatchName => "ModifiedType + EnumLabel";
  protected override string ItemMatchKey(IGqlpOutputField item)
    => item.ModifiedType + "~" + item.EnumLabel;

  protected override ITokenMessages CanMergeGroup(IGrouping<string, IGqlpOutputField> group)
    => base.CanMergeGroup(group)
      .Add(group.ManyCanMerge(item => item.Params, parameters));
  protected override IGqlpOutputField MergeGroup(IEnumerable<IGqlpOutputField> group)
    => (OutputFieldAst)base.MergeGroup(group) with {
      Params = group.ManyMerge(item => item.Params, parameters).ArrayOf<InputParamAst>(),
    };
}
