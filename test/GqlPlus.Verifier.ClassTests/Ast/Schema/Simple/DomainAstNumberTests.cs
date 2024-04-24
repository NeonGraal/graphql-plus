namespace GqlPlus.Verifier.Ast.Schema.Simple;

public class DomainAstNumberTests
  : AstDomainTests<DomainRangeInput, DomainRangeAst>
{
  protected override string AliasesString(string input, string aliases)
    => $"( !Do {input}{aliases} Number )";

  protected override string MembersString(string name, DomainRangeInput input)
    => $"( !Do {name} Number !DN < {input.Lower} !DN ! {input.Lower} ~ {input.Upper} !DN {input.Upper} > )";
  protected override DomainRangeAst[] DomainMembers(DomainRangeInput input)
  => [new(AstNulls.At, false, null, input.Lower), new(AstNulls.At, true, input.Lower, input.Upper), new(AstNulls.At, false, input.Upper, null)];
  protected override AstDomain<DomainRangeAst> NewDomain(string name, DomainRangeAst[] list)
  => new(AstNulls.At, name, DomainKind.Number, list);
}
