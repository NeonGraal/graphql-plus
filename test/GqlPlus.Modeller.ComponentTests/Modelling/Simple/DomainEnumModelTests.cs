using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Simple;

namespace GqlPlus.Modelling.Simple;

public class DomainEnumModelTests(
  IDomainEnumModelChecks checks
) : TestDomainModel<string, IGqlpDomainMember, DomainMemberModel>(checks)
{ }

internal sealed class DomainEnumModelChecks(
  IDomainModeller<IGqlpDomainMember, DomainMemberModel> modeller,
  IRenderer<BaseDomainModel<DomainMemberModel>> rendering
) : CheckDomainModel<string, DomainMemberAst, IGqlpDomainMember, DomainMemberModel>(DomainKind.Enum, modeller, rendering)
  , IDomainEnumModelChecks
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

public interface IDomainEnumModelChecks
  : ICheckDomainModel<string, IGqlpDomainMember, DomainMemberModel>
{ }
