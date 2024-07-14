using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast;
using GqlPlus.Ast.Schema.Objects;

namespace GqlPlus.Merging.Objects;

public class MergeTypeParamsTests
  : TestDescriptionsMerger<IGqlpTypeParam>
{
  [Theory, RepeatData(Repeats)]
  public void Merge_ManyItems_ReturnsItem(string name)
  {
    IGqlpTypeParam[] items = Enumerable.Range(1, 5).Select(i => MakeAst(name)).ToArray();

    IEnumerable<IGqlpTypeParam> result = MergerGroups.Merge(items);

    using AssertionScope scope = new();

    result.Should().BeAssignableTo<IEnumerable<IGqlpTypeParam>>();
  }

  private readonly MergeTypeParams _merger = new();

  internal override GroupsMerger<IGqlpTypeParam> MergerGroups => _merger;

  protected override IGqlpTypeParam MakeDescribed(string name, string description = "")
    => new TypeParamAst(AstNulls.At, name, description);
}
