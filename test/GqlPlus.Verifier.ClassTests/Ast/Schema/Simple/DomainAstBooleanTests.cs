namespace GqlPlus.Ast.Schema.Simple;

public class DomainAstBooleanTests
  : AstDomainTests<bool, DomainTrueFalseAst>
{
  protected override string MembersString(string name, bool input)
    => $"( !Do {name} Boolean !DT {input} )";
  protected override AstDomain<DomainTrueFalseAst> NewDomain(string name, DomainTrueFalseAst[] list)
    => new(AstNulls.At, name, DomainKind.Boolean, list);
  protected override DomainTrueFalseAst[] DomainMembers(bool input)
    => [new(AstNulls.At, false, input)];
}
