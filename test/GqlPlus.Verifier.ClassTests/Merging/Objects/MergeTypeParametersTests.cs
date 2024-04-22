using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Schema.Objects;

namespace GqlPlus.Verifier.Merging.Objects;

public class MergeTypeParametersTests
  : TestDescriptions<TypeParameterAst>
{
  [Theory, RepeatData(Repeats)]
  public void Merge_ManyItems_ReturnsItem(string name)
  {
    var items = Enumerable.Range(1, 5).Select(i => MakeAst(name)).ToArray();

    var result = MergerGroups.Merge(items);

    using var scope = new AssertionScope();

    result.Should().BeAssignableTo<IEnumerable<TypeParameterAst>>();
  }

  private readonly MergeTypeParameters _merger = new();

  internal override GroupsMerger<TypeParameterAst> MergerGroups => _merger;

  protected override TypeParameterAst MakeDescribed(string name, string description = "")
    => new(AstNulls.At, name, description);
}
