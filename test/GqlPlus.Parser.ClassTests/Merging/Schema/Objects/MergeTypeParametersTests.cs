using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Objects;
using GqlPlus.Merging.Objects;

namespace GqlPlus.Merging.Schema.Objects;

public class MergeTypeParamsTests
  : TestDescriptionsMerger<IGqlpTypeParam>
{
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
