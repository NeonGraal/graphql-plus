using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Ast.Schema.Simple;

public class DomainAstEnumTests
  : AstDomainTests<DomainMemberInput>
{
  internal override IAstDomainChecks<DomainMemberInput> Checks => _checks;

  private DomainAstEnumChecks _checks = new();
}

internal sealed class DomainAstEnumChecks()
 : AstDomainChecks<DomainMemberInput, DomainMemberAst, IGqlpDomainMember>(DomainKind.Enum)
{
  protected override DomainMemberAst[] DomainMembers(DomainMemberInput input)
    => [new(AstNulls.At, false, input.EnumMember)];

  protected override string MembersString(string name, DomainMemberInput input)
    => $"( !Do {name} Enum !DE {input.EnumMember} )";

  protected override AstDomain<DomainMemberAst, IGqlpDomainMember> NewDomain(string name, DomainMemberAst[] list)
    => new(AstNulls.At, name, Kind, list);
}

public record struct DomainMemberInput(string EnumType, string EnumMember);
