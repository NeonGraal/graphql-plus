using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Schema;
using Xunit.Abstractions;

namespace GqlPlus.Verifier.Merging;

public class MergeScalarAstNumbersTests(
  ITestOutputHelper outputHelper
) : TestScalarAsts<ScalarRangeAst, ScalarRangeInput>(outputHelper)
{
  protected override ScalarRangeAst[] MakeItems(ScalarRangeInput input)
    => input.ScalarRange();

  protected override AstScalar<ScalarRangeAst> MakeTyped(string name, string description = "")
    => new(AstNulls.At, name, description, ScalarDomain.Number);
}
