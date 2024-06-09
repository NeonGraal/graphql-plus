using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Simple;
using GqlPlus.Rendering;

namespace GqlPlus.Modelling.Simple;

public class DomainNumberModelTests(
  IDomainModeller<IGqlpDomainRange, DomainRangeModel> modeller,
  IRenderer<BaseDomainModel<DomainRangeModel>> rendering
) : TestDomainModel<DomainRangeInput, DomainRangeAst, IGqlpDomainRange>
{
  internal override ICheckDomainModel<DomainRangeInput, DomainRangeAst, IGqlpDomainRange> DomainChecks => _checks;

  private readonly DomainNumberModelChecks _checks = new(modeller, rendering);
}

internal sealed class DomainNumberModelChecks(
  IDomainModeller<IGqlpDomainRange, DomainRangeModel> modeller,
  IRenderer<BaseDomainModel<DomainRangeModel>> rendering
) : CheckDomainModel<DomainRangeInput, DomainRangeAst, IGqlpDomainRange, DomainRangeModel>(DomainKind.Number, modeller, rendering)
{
  protected override string[] ExpectedItem(DomainRangeInput input, string exclude, string[] domain)
    => ["- !_DomainRange", .. domain, exclude, "  from: " + input.Lower, "  to: " + input.Upper];

  protected override DomainRangeAst[]? DomainItems(DomainRangeInput[]? inputs)
    => inputs?.DomainRanges();
}
