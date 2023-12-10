using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Merging;

public class MergeScalarRegexsTests
  : TestDistinct<ScalarRegexAst>
{
  private readonly MergeScalarRegexes _merger = new();

  [Theory, RepeatData(Repeats)]
  public void CanMerge_TwoItemsSameExcludes_ReturnsTrue(string name)
  {
    var items = new[] { new ScalarRegexAst(AstNulls.At, name, false), new ScalarRegexAst(AstNulls.At, name, false) };

    var result = _merger.CanMerge(items);

    result.Should().BeTrue();
  }

  [Theory, RepeatData(Repeats)]
  public void CanMerge_TwoItemsDifferentExcludes_ReturnsFalse(string name)
  {
    var items = new[] { new ScalarRegexAst(AstNulls.At, name, true), new ScalarRegexAst(AstNulls.At, name, false) };

    var result = _merger.CanMerge(items);

    result.Should().BeFalse();
  }

  protected override DistinctMerger<ScalarRegexAst> MergerDistinct => _merger;

  protected override ScalarRegexAst MakeDistinct(string name)
    => new(AstNulls.At, name, false);
}
