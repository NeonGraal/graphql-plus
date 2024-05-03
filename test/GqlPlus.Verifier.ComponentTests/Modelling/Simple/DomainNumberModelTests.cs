using GqlPlus.Ast.Schema.Simple;

namespace GqlPlus.Modelling.Simple;

public class DomainNumberModelTests(
  IDomainModeller<DomainRangeAst, DomainRangeModel> modeller
) : TestDomainModel<DomainRangeInput, DomainRangeAst>
{
  internal override ICheckDomainModel<DomainRangeInput, DomainRangeAst> DomainChecks => _checks;

  private readonly DomainNumberModelChecks _checks = new(modeller);
}

internal sealed class DomainNumberModelChecks(
  IDomainModeller<DomainRangeAst, DomainRangeModel> modeller
) : CheckDomainModel<DomainRangeInput, DomainRangeAst, DomainRangeModel>(DomainKind.Number, modeller)
{
  protected override string[] ExpectedItem(DomainRangeInput input, string exclude, string[] domain)
    => ["- !_DomainRange", .. domain, exclude, "  from: " + input.Lower, "  to: " + input.Upper];

  protected override DomainRangeAst[]? DomainItems(DomainRangeInput[]? inputs)
    => inputs?.DomainRanges();
}
