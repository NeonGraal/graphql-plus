using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Objects;

namespace GqlPlus.Merging.Objects;

internal class MergeInputFields(
  ILoggerFactory logger,
  IMerge<IGqlpConstant> constant
) : AstObjectFieldsMerger<IGqlpInputField>(logger)
{
  protected override IMessages CanMergeGroup(IGrouping<string, IGqlpInputField> group)
    => base.CanMergeGroup(group)
      .Add(group.CanMerge(item => item.DefaultValue, constant));

  protected override IGqlpInputField MergeGroup(IEnumerable<IGqlpInputField> group)
    => (InputFieldAst)base.MergeGroup(group) with {
      DefaultValue = group.Merge(item => item.DefaultValue, constant).FirstOrDefault()
    };
}
