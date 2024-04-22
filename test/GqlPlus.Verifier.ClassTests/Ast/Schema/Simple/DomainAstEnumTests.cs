using GqlPlus.Verifier.Ast.Schema.Simple;

namespace GqlPlus.Verifier.Ast.Schema.Types;

public class DomainAstEnumTests
  : AstDomainTests<DomainMemberInput, DomainMemberAst>
{
  protected override string MembersString(string name, DomainMemberInput input)
    => $"( !S {name} Enum !SM {input.EnumType} {input.EnumMember} )";
  protected override AstDomain<DomainMemberAst> NewDomain(string name, DomainMemberAst[] list)
    => new(AstNulls.At, name, DomainDomain.Enum, list);
  protected override DomainMemberAst[] DomainMembers(DomainMemberInput input)
    => [new DomainMemberAst(AstNulls.At, false, input.EnumMember) { EnumType = input.EnumType }];
}

public record struct DomainMemberInput(string EnumType, string EnumMember);
