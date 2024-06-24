using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast;
using GqlPlus.Ast.Schema.Objects;

namespace GqlPlus.Merging.Objects;

public class MergeTypeParametersTests
  : TestDescriptionsMerger<IGqlpTypeParameter>
{
  [Theory, RepeatData(Repeats)]
  public void Merge_ManyItems_ReturnsItem(string name)
  {
    IGqlpTypeParameter[] items = Enumerable.Range(1, 5).Select(i => MakeAst(name)).ToArray();

    IEnumerable<IGqlpTypeParameter> result = MergerGroups.Merge(items);

    using AssertionScope scope = new();

    result.Should().BeAssignableTo<IEnumerable<IGqlpTypeParameter>>();
  }

  private readonly MergeTypeParameters _merger = new();

  internal override GroupsMerger<IGqlpTypeParameter> MergerGroups => _merger;

  protected override TypeParameterAst MakeDescribed(string name, string description = "")
    => new(AstNulls.At, name, description);
}
