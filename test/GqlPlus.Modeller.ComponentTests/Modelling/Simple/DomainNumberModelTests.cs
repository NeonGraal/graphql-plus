using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Simple;

namespace GqlPlus.Modelling.Simple;

public class DomainNumberModelTests(
  IDomainModeller<IGqlpDomainRange, DomainRangeModel> modeller
) : TestDomainModel<DomainRangeInput, DomainRangeAst, IGqlpDomainRange>
{
  internal override ICheckDomainModel<DomainRangeInput, DomainRangeAst, IGqlpDomainRange> DomainChecks => _checks;

  private readonly DomainNumberModelChecks _checks = new(modeller);
}

internal sealed class DomainNumberModelChecks(
  IDomainModeller<IGqlpDomainRange, DomainRangeModel> modeller
) : CheckDomainModel<DomainRangeInput, DomainRangeAst, IGqlpDomainRange, DomainRangeModel>(DomainKind.Number, modeller)
{
  protected override string[] ExpectedItem(DomainRangeInput input, string exclude, string[] domain)
    => ["- !_DomainRange", .. domain, exclude, "  from: " + input.Lower, "  to: " + input.Upper];

  protected override DomainRangeAst[]? DomainItems(DomainRangeInput[]? inputs)
    => inputs?.DomainRanges();
}
