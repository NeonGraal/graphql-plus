using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Merging;

public class MergeScalarRangesTests
  : TestBase<ScalarRangeAst>
{
  // Todo: Finish MergeScalarRanges tests
  private readonly MergeScalarRanges _merger = new();

  protected override IMerge<ScalarRangeAst> MergerBase => _merger;

  protected override ScalarRangeAst MakeDistinct(string name)
    => new(AstNulls.At, false);
}
