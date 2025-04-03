using System.Data;
using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast;
using GqlPlus.Ast.Schema.Objects;
using GqlPlus.Merging;
using GqlPlus.Merging.Objects;

namespace GqlPlus.Schema.Objects;

public class MergeTypeParamsTests
  : TestDescriptionsMerger<IGqlpTypeParam>
{
  [Theory(Skip = "WIP"), RepeatData]
  public void CanMerge_TwoAstsConstraintCantMerge_ReturnsErrors(string name, string constraint)
    => this
      .SkipWhitespace(constraint)
      .CanMerge_Errors(
        new TypeParamAst(AstNulls.At, name) with { Constraint = constraint },
        new TypeParamAst(AstNulls.At, name));

  [Theory(Skip = "WIP"), RepeatData]
  public void Merge_TwoAstsWithConstraint_CallsConstraintMerge(string name, string constraint1, string constraint2)
    => this
    .SkipWhitespace(constraint1)
    .SkipWhitespace(constraint2)
  .Merge_Expected([
        new TypeParamAst(AstNulls.At, name) with { Constraint = constraint1 },
      new TypeParamAst(AstNulls.At, name) with { Constraint = constraint2 }],
        new TypeParamAst(AstNulls.At, name) with { Constraint = constraint1 + "|" + constraint2 });

  [Theory, RepeatData]
  public void Merge_ManyItems_ReturnsItem(string name)
  {
    IGqlpTypeParam[] items = [.. Enumerable.Range(1, 5).Select(i => MakeAst(name))];

    IEnumerable<IGqlpTypeParam> result = MergerGroups.Merge(items);

    result.ShouldBeAssignableTo<IEnumerable<IGqlpTypeParam>>();
  }

  private readonly MergeTypeParams _merger = new();

  internal override GroupsMerger<IGqlpTypeParam> MergerGroups => _merger;

  protected override IGqlpTypeParam MakeDescribed(string name, string description = "")
    => new TypeParamAst(AstNulls.At, name, description);
}
