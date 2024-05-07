using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Ast.Schema.Simple;

public class DomainAstStringTests
  : AstDomainTests<string, DomainRegexAst>
{
  protected override string MembersString(string name, string input)
    => $"( !Do {name} String !DX /{input}/ )";
  protected override AstDomain<DomainRegexAst> NewDomain(string name, DomainRegexAst[] list)
    => new(AstNulls.At, name, DomainKind.String, list);
  protected override DomainRegexAst[] DomainMembers(string input)
    => [new(AstNulls.At, false, input)];
}
