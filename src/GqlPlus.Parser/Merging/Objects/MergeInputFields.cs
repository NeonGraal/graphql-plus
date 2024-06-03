using GqlPlus.Ast;
using GqlPlus.Ast.Schema.Objects;

namespace GqlPlus.Merging.Objects;

internal class MergeInputFields(
  ILoggerFactory logger,
  IMerge<IGqlpConstant> constant
) : AstObjectFieldsMerger<InputFieldAst, InputBaseAst>(logger)
{
  protected override ITokenMessages CanMergeGroup(IGrouping<string, InputFieldAst> group)
    => base.CanMergeGroup(group)
      .Add(group.CanMerge(item => item.DefaultValue, constant));

  protected override InputFieldAst MergeGroup(IEnumerable<InputFieldAst> group)
    => base.MergeGroup(group) with {
      DefaultValue = (ConstantAst?)group.Merge(item => item.DefaultValue, constant).FirstOrDefault()
    };
}
