using System.Data;
using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Objects;
using GqlPlus.Merging.Objects;

namespace GqlPlus.Merging.Schema.Objects;

public class MergeTypeParamsTests
  : TestDescriptionsMerger<IGqlpTypeParam>
{
  [Theory, RepeatData]
  public void CanMerge_TwoAstsOneConstraintCanMerge_ReturnsGood(string name, string constraint)
    => this
      .SkipWhitespace(constraint)
      .CanMerge_Good(
        new TypeParamAst(AstNulls.At, name, constraint),
        new TypeParamAst(AstNulls.At, name, constraint));

  [Theory, RepeatData]
  public void CanMerge_TwoAstsTwoConstraintCanMerge_ReturnsErrors(string name, string constraint1, string constraint2)
    => this
      .SkipEqual(constraint1, constraint2)
      .CanMerge_Errors(
        new TypeParamAst(AstNulls.At, name, constraint1),
        new TypeParamAst(AstNulls.At, name, constraint2));

  [Theory, RepeatData]
  public void Merge_TwoAstsWithSameConstraint_ReturnsExpected(string name, string constraint)
    => this
    .SkipWhitespace(constraint)
  .Merge_Expected([
      new TypeParamAst(AstNulls.At, name, constraint),
      new TypeParamAst(AstNulls.At, name, constraint)],
      new TypeParamAst(AstNulls.At, name, constraint));

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
    => new TypeParamAst(AstNulls.At, name, description, "");
}
