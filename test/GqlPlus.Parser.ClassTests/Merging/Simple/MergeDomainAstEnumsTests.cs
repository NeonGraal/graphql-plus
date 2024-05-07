using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast;
using GqlPlus.Ast.Schema.Simple;
using Xunit.Abstractions;

namespace GqlPlus.Merging.Simple;

public class MergeDomainAstEnumsTests(
  ITestOutputHelper outputHelper
) : TestDomainAsts<DomainMemberAst, string>(outputHelper)
{
  protected override DomainMemberAst[] MakeItems(string input)
    => new[] { input }.DomainMembers();

  protected override AstDomain<DomainMemberAst> MakeTyped(string name, string[]? aliases = null, string description = "", string? parent = default)
    => new(AstNulls.At, name, description, DomainKind.Enum) {
      Aliases = aliases ?? [],
      Parent = parent,
    };
}
