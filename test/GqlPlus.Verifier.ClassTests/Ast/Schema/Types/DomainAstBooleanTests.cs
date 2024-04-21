namespace GqlPlus.Verifier.Ast.Schema.Types;

public class DomainAstBooleanTests
  : AstDomainTests<bool, DomainTrueFalseAst>
{
  protected override string MembersString(string name, bool input)
    => $"( !S {name} Boolean !STF {input} )";
  protected override AstDomain<DomainTrueFalseAst> NewDomain(string name, DomainTrueFalseAst[] list)
    => new(AstNulls.At, name, DomainDomain.Boolean, list);
  protected override DomainTrueFalseAst[] DomainMembers(bool input)
    => [new(AstNulls.At, false, input)];
}
