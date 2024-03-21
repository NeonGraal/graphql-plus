using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Merging;

public class MergeScalarAstNumbersTests
  : TestScalarAsts<ScalarRangeAst, ScalarRangeInput>
{
  protected override ScalarRangeAst[] MakeItems(ScalarRangeInput input)
    => input.ScalarRange();

  protected override AstScalar<ScalarRangeAst> MakeTyped(string name, string description = "")
    => new(AstNulls.At, name, description, ScalarDomain.Number);
}
