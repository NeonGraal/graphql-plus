using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast;
using GqlPlus.Ast.Schema.Simple;

namespace GqlPlus.Schema.Simple;

public class DomainAstStringTests
  : AstDomainTests<string>
{
  internal override IAstDomainChecks<string> Checks => _checks;

  private readonly DomainAstStringChecks _checks = new();
}

internal sealed class DomainAstStringChecks()
 : AstDomainChecks<string, DomainRegexAst, IGqlpDomainRegex>(DomainKind.String)
{
  protected override DomainRegexAst[] DomainItems(string input)
    => [new(AstNulls.At, "", false, input)];

  protected override string ItemsString(string name, string input)
    => $"( !Do {name} String !DX /{input}/ )";

  protected override AstDomain<DomainRegexAst, IGqlpDomainRegex> NewDomain(string name, DomainRegexAst[] list)
    => new(AstNulls.At, name, Kind, list);
}
