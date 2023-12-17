using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Merging;

public class MergeScalarRegexesTests
  : TestDistinct<ScalarRegexAst>
{
  private readonly MergeScalarRegexes _merger = new();

  [Theory, RepeatData(Repeats)]
  public void CanMerge_TwoItemsSameExcludes_ReturnsTrue(string name)
    => CanMerge_True([
      new ScalarRegexAst(AstNulls.At, name, false),
      new ScalarRegexAst(AstNulls.At, name, false)]);

  [Theory, RepeatData(Repeats)]
  public void CanMerge_TwoItemsDifferentExcludes_ReturnsFalse(string name)
    => CanMerge_False([
      new ScalarRegexAst(AstNulls.At, name, true),
      new ScalarRegexAst(AstNulls.At, name, false)]);

  protected override DistinctsMerger<ScalarRegexAst> MergerDistinct => _merger;

  protected override ScalarRegexAst MakeDistinct(string name)
    => new(AstNulls.At, name, false);
}
