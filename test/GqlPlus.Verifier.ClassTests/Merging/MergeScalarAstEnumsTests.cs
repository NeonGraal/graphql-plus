using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Schema;
using Xunit.Abstractions;

namespace GqlPlus.Verifier.Merging;

public class MergeScalarAstEnumsTests(
  ITestOutputHelper outputHelper
) : TestScalarAsts<ScalarMemberAst, string>(outputHelper)
{
  protected override ScalarMemberAst[] MakeItems(string input)
    => new[] { input }.ScalarMembers();

  protected override AstScalar<ScalarMemberAst> MakeTyped(string name, string description = "")
    => new(AstNulls.At, name, description, ScalarDomain.Enum);
}
