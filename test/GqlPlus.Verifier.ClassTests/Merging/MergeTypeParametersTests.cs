using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Merging;

public class MergeTypeParametersTests
  : TestDescriptions<TypeParameterAst>
{
  [Theory, RepeatData(Repeats)]
  public void Merge_ManyItems_ReturnsItem(string name)
  {
    var items = Enumerable.Range(1, 5).Select(i => MakeDistinct(name)).ToArray();

    var result = MergerDistinct.Merge(items);

    using var scope = new AssertionScope();

    result.Should().BeOfType<TypeParameterAst>();
    result.Name.Should().Be(name);
  }

  private readonly MergeTypeParameters _merger = new();

  protected override DescribedsMerger<TypeParameterAst> MergerDescribed => _merger;

  protected override TypeParameterAst MakeDescribed(string name, string description = "")
    => new(AstNulls.At, name, description);
}
