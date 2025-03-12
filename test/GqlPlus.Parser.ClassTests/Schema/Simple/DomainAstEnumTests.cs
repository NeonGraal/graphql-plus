using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast;
using GqlPlus.Ast.Schema.Simple;

namespace GqlPlus.Schema.Simple;

public class DomainAstEnumTests
  : AstDomainTests<DomainMemberInput>
{
  [Theory, RepeatData]
  public void Inequality_BetweenSpecifcMembers(string name, string type1, string type2, string member)
    => Checks.Inequality_BetweenMembers(name, new(type1, member), new(type2, member));

  internal override IAstDomainChecks<DomainMemberInput> Checks => _checks;

  private readonly DomainAstEnumChecks _checks = new();
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

  protected override bool SkipEquals(DomainMemberInput input1, DomainMemberInput input2)
    => input1.EnumMember == input2.EnumMember;
}

public record struct DomainMemberInput(string EnumType, string EnumMember);
