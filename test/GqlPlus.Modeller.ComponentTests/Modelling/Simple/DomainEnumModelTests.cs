using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Simple;

namespace GqlPlus.Modelling.Simple;

public class DomainEnumModelTests(
  IDomainModeller<IGqlpDomainMember, DomainMemberModel> modeller,
  IRenderer<BaseDomainModel<DomainMemberModel>> rendering
) : TestDomainModel<string, IGqlpDomainMember>
{
  internal override ICheckDomainModel<string, IGqlpDomainMember> DomainChecks => _checks;

  private readonly DomainEnumModelChecks _checks = new(modeller, rendering);
}

internal sealed class DomainEnumModelChecks(
  IDomainModeller<IGqlpDomainMember, DomainMemberModel> modeller,
  IRenderer<BaseDomainModel<DomainMemberModel>> rendering
) : CheckDomainModel<string, DomainMemberAst, IGqlpDomainMember, DomainMemberModel>(DomainKind.Enum, modeller, rendering)
{
  protected override string[] ExpectedItem(string input, string exclude, string[] domain)
    => [
      "- !_DomainMember",
      .. domain,
      exclude,
      "  value: !_EnumValue",
      "    member: " + input,
      "    typeKind: !_SimpleKind Enum"
      ];

  protected override DomainMemberAst[]? DomainItems(string[]? inputs)
    => inputs?.DomainMembers();
}
