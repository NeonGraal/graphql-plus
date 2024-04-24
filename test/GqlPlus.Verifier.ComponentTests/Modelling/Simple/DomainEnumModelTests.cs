﻿using GqlPlus.Verifier.Ast.Schema.Simple;

namespace GqlPlus.Verifier.Modelling.Simple;

public class DomainEnumModelTests(
  IDomainModeller<DomainMemberAst, DomainMemberModel> modeller
) : TestDomainModel<string, DomainMemberAst>
{
  internal override ICheckDomainModel<string, DomainMemberAst> DomainChecks => _checks;

  private readonly DomainEnumModelChecks _checks = new(modeller);
}

internal sealed class DomainEnumModelChecks(
  IDomainModeller<DomainMemberAst, DomainMemberModel> modeller
) : CheckDomainModel<string, DomainMemberAst, DomainMemberModel>(DomainKind.Enum, modeller)
{
  protected override string[] ExpectedItem(string input, string exclude, string[] domain)
    => ["- !_DomainMember", .. domain, exclude, "  typeKind: !_SimpleKind Enum", "  value: " + input];

  protected override DomainMemberAst[]? DomainItems(string[]? inputs)
    => inputs?.DomainMembers();
}
