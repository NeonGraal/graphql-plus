using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Simple;

namespace GqlPlus.Modelling.Simple;

public class DomainNumberModelTests(
  IDomainNumberModelChecks checks
) : TestDomainModel<DomainRangeInput, IGqlpDomainRange, DomainRangeModel>(checks)
{ }

internal sealed class DomainNumberModelChecks(
  IDomainModeller<IGqlpDomainRange, DomainRangeModel> modeller,
  IRenderer<BaseDomainModel<DomainRangeModel>> rendering
) : CheckDomainModel<DomainRangeInput, DomainRangeAst, IGqlpDomainRange, DomainRangeModel>(DomainKind.Number, modeller, rendering)
  , IDomainNumberModelChecks
{
  protected override string[] ExpectedItem(DomainRangeInput input, string exclude, string[] domain)
    => ["- !_DomainRange", .. domain, exclude, "  from: " + input.Lower, "  to: " + input.Upper];

  protected override DomainRangeAst[]? DomainItems(DomainRangeInput[]? inputs)
    => inputs?.DomainRanges();
}

public interface IDomainNumberModelChecks
  : ICheckDomainModel<DomainRangeInput, IGqlpDomainRange, DomainRangeModel>
{ }
