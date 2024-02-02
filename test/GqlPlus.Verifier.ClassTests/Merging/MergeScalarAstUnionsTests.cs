using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Merging;

public class MergeScalarAstUnionsTests
  : TestScalarAsts<ScalarReferenceAst, string>
{
  protected override ScalarReferenceAst[] MakeItems(string input)
    => input.ScalarReferences();
  protected override AstScalar<ScalarReferenceAst> MakeTyped(string name, string description = "")
    => new(AstNulls.At, name, description, ScalarKind.Union);
}
