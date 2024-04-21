namespace GqlPlus.Verifier.Ast.Schema.Types;

public class DomainAstNumberTests
  : AstDomainTests<DomainRangeInput, DomainRangeAst>
{
  protected override string AliasesString(string input, string aliases)
    => $"( !S {input}{aliases} Number )";

  protected override string MembersString(string name, DomainRangeInput input)
    => $"( !S {name} Number !SR < {input.Lower} !SR ! {input.Lower} ~ {input.Upper} !SR {input.Upper} > )";
  protected override DomainRangeAst[] DomainMembers(DomainRangeInput input)
  => [new(AstNulls.At, false, null, input.Lower), new(AstNulls.At, true, input.Lower, input.Upper), new(AstNulls.At, false, input.Upper, null)];
  protected override AstDomain<DomainRangeAst> NewDomain(string name, DomainRangeAst[] list)
  => new(AstNulls.At, name, DomainDomain.Number, list);
}
