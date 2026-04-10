using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Objects;

namespace GqlPlus.Merging.Objects;

internal class MergeInputFields(
  IMergerRepository mergers
) : AstObjectFieldsMerger<IGqlpInputField>(mergers)
{
  protected override IMessages CanMergeGroup(IGrouping<string, IGqlpInputField> group)
    => base.CanMergeGroup(group)
      .Add(group.CanMerge(item => item.DefaultValue, mergers.MergerFor<IAstConstant>()));

  protected override IGqlpInputField MergeGroup(IEnumerable<IGqlpInputField> group)
    => (InputFieldAst)base.MergeGroup(group) with {
      DefaultValue = group.Merge(item => item.DefaultValue, mergers.MergerFor<IAstConstant>()).FirstOrDefault()
    };
}
