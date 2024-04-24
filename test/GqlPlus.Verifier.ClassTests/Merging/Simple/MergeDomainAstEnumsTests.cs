using GqlPlus.Verifier.Ast;
using GqlPlus.Verifier.Ast.Schema.Simple;
using Xunit.Abstractions;

namespace GqlPlus.Verifier.Merging.Simple;

public class MergeDomainAstEnumsTests(
  ITestOutputHelper outputHelper
) : TestDomainAsts<DomainMemberAst, string>(outputHelper)
{
  protected override DomainMemberAst[] MakeItems(string input)
    => new[] { input }.DomainMembers();

  protected override AstDomain<DomainMemberAst> MakeTyped(string name, string description = "")
    => new(AstNulls.At, name, description, DomainKind.Enum);
}
