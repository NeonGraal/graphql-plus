using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Merging;

public class MergeScalarAstEnumsTests
  : TestScalarAsts<ScalarMemberAst, string>
{
  protected override ScalarMemberAst[] MakeItems(string input)
    => new[] { input }.ScalarMembers();

  protected override AstScalar<ScalarMemberAst> MakeTyped(string name, string description = "")
    => new(AstNulls.At, name, description, ScalarKind.Enum);
}
