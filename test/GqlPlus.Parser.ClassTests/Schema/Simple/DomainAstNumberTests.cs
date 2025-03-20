﻿using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast;
using GqlPlus.Ast.Schema.Simple;

namespace GqlPlus.Schema.Simple;

public class DomainAstNumberTests
  : AstDomainTests<DomainRangeInput>
{
  internal override IAstDomainChecks<DomainRangeInput> Checks => _checks;

  private readonly DomainAstNumberChecks _checks = new();
}

internal sealed class DomainAstNumberChecks()
 : AstDomainChecks<DomainRangeInput, DomainRangeAst, IGqlpDomainRange>(DomainKind.Number)
{
  protected override DomainRangeAst[] DomainMembers(DomainRangeInput input)
  => [new(AstNulls.At, "", false, null, input.Lower),
    new(AstNulls.At, "", true, input.Lower, input.Upper),
    new(AstNulls.At, "", false, input.Upper, null)];

  protected override string MembersString(string name, DomainRangeInput input)
    => $"( !Do {name} Number !DN < {input.Lower} !DN ! {input.Lower} ~ {input.Upper} !DN {input.Upper} > )";

  protected override AstDomain<DomainRangeAst, IGqlpDomainRange> NewDomain(string name, DomainRangeAst[] list)
    => new(AstNulls.At, name, Kind, list);
}
