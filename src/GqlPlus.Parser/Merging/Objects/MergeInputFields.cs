using GqlPlus.Ast.Schema;
using GqlPlus.Ast.Schema.Objects;

namespace GqlPlus.Merging.Objects;

internal class MergeInputFields(
  IMergerRepository mergers
) : AstObjectFieldsMerger<IAstInputField>(mergers)
{
  private readonly MergerOne<IAstConstant> _defaultValue = mergers.MergerFor<IAstConstant>();

  protected override IMessages CanMergeGroup(IGrouping<string, IAstInputField> group)
    => base.CanMergeGroup(group)
      .Add(group.CanMerge(item => item.DefaultValue, _defaultValue));

  protected override IAstInputField MergeGroup(IEnumerable<IAstInputField> group)
    => (InputFieldAst)base.MergeGroup(group) with {
      DefaultValue = group.Merge(item => item.DefaultValue, _defaultValue).FirstOrDefault()
    };

  internal static MergeInputFields Factory(IMergerRepository m) => new(m);
}
