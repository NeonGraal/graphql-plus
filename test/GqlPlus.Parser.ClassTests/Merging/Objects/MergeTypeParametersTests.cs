using GqlPlus.Ast;
using GqlPlus.Ast.Schema.Objects;

namespace GqlPlus.Merging.Objects;

public class MergeTypeParametersTests
  : TestDescriptions<TypeParameterAst>
{
  [Theory, RepeatData(Repeats)]
  public void Merge_ManyItems_ReturnsItem(string name)
  {
    TypeParameterAst[] items = Enumerable.Range(1, 5).Select(i => MakeAst(name)).ToArray();

    IEnumerable<TypeParameterAst> result = MergerGroups.Merge(items);

    using AssertionScope scope = new();

    result.Should().BeAssignableTo<IEnumerable<TypeParameterAst>>();
  }

  private readonly MergeTypeParameters _merger = new();

  internal override GroupsMerger<TypeParameterAst> MergerGroups => _merger;

  protected override TypeParameterAst MakeDescribed(string name, string description = "")
    => new(AstNulls.At, name, description);
}
