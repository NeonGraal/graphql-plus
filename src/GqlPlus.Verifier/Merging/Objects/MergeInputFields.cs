using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Schema.Objects;
using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Merging.Objects;

internal class MergeInputFields(
  ILoggerFactory logger,
  IMerge<ConstantAst> constant
) : FieldsMerger<InputFieldAst, InputReferenceAst>(logger)
{
  protected override ITokenMessages CanMergeGroup(IGrouping<string, InputFieldAst> group)
    => base.CanMergeGroup(group)
      .Add(group.CanMerge(item => item.Default, constant));

  protected override InputFieldAst MergeGroup(IEnumerable<InputFieldAst> group)
    => base.MergeGroup(group) with {
      Default = group.Merge(item => item.Default, constant).FirstOrDefault()
    };
}
