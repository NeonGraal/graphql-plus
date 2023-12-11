using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Merging;

public class MergeScalarRangesTests
  : TestDistinct<ScalarRangeAst>
{
  private readonly MergeScalarRanges _merger = new();

  protected override DistinctsMerger<ScalarRangeAst> MergerDistinct => _merger;

  protected override ScalarRangeAst MakeDistinct(string name)
    => new(AstNulls.At);
}
