using GqlPlus.Verifier.Ast.Schema.Simple;

namespace GqlPlus.Verifier.Ast.Schema.Types;

public class DomainAstStringTests
  : AstDomainTests<string, DomainRegexAst>
{
  protected override string MembersString(string name, string input)
    => $"( !S {name} String !SX /{input}/ )";
  protected override AstDomain<DomainRegexAst> NewDomain(string name, DomainRegexAst[] list)
    => new(AstNulls.At, name, DomainDomain.String, list);
  protected override DomainRegexAst[] DomainMembers(string input)
    => [new(AstNulls.At, false, input)];
}
