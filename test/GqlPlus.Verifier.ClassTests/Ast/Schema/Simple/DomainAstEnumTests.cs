﻿namespace GqlPlus.Verifier.Ast.Schema.Simple;

public class DomainAstEnumTests
  : AstDomainTests<DomainMemberInput, DomainMemberAst>
{
  protected override string MembersString(string name, DomainMemberInput input)
    => $"( !Do {name} Enum !DE {input.EnumType} {input.EnumMember} )";
  protected override AstDomain<DomainMemberAst> NewDomain(string name, DomainMemberAst[] list)
    => new(AstNulls.At, name, DomainKind.Enum, list);
  protected override DomainMemberAst[] DomainMembers(DomainMemberInput input)
    => [new DomainMemberAst(AstNulls.At, false, input.EnumMember) { EnumType = input.EnumType }];
}

public record struct DomainMemberInput(string EnumType, string EnumMember);