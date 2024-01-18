using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Merging;

public class MergeScalarRangesTests
  : TestBase<ScalarRangeNumberAst>
{
  private readonly MergeScalarRanges _merger = new();

  protected override IMerge<ScalarRangeNumberAst> MergerBase => _merger;

  protected override ScalarRangeNumberAst MakeDistinct(string name)
    => new(AstNulls.At);
}
