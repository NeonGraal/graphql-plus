using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Simple;
using GqlPlus.Rendering;

namespace GqlPlus.Modelling.Simple;

public class DomainBooleanModelTests(
  IDomainModeller<IGqlpDomainTrueFalse, DomainTrueFalseModel> modeller,
  IRenderer<BaseDomainModel<DomainTrueFalseModel>> rendering
) : TestDomainModel<bool, DomainTrueFalseAst, IGqlpDomainTrueFalse>
{
  internal override ICheckDomainModel<bool, DomainTrueFalseAst, IGqlpDomainTrueFalse> DomainChecks => _checks;

  private readonly DomainBooleanModelChecks _checks = new(modeller, rendering);
}

internal sealed class DomainBooleanModelChecks(
  IDomainModeller<IGqlpDomainTrueFalse, DomainTrueFalseModel> modeller,
  IRenderer<BaseDomainModel<DomainTrueFalseModel>> rendering
) : CheckDomainModel<bool, DomainTrueFalseAst, IGqlpDomainTrueFalse, DomainTrueFalseModel>(DomainKind.Boolean, modeller, rendering)
{
  protected override string[] ExpectedItem(bool input, string exclude, string[] domain)
    => ["- !_DomainTrueFalse", .. domain, exclude, "  value: " + input.TrueFalse()];

  protected override DomainTrueFalseAst[]? DomainItems(bool[]? inputs)
    => inputs?.DomainTrueFalses();
}
