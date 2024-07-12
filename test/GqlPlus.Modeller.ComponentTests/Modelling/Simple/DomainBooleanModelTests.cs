using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Simple;

namespace GqlPlus.Modelling.Simple;

public class DomainBooleanModelTests(
  IDomainBooleanModelChecks checks
) : TestDomainModel<bool, IGqlpDomainTrueFalse, DomainTrueFalseModel>(checks)
{ }

internal sealed class DomainBooleanModelChecks(
  IDomainModeller<IGqlpDomainTrueFalse, DomainTrueFalseModel> modeller,
  IRenderer<BaseDomainModel<DomainTrueFalseModel>> rendering
) : CheckDomainModel<bool, DomainTrueFalseAst, IGqlpDomainTrueFalse, DomainTrueFalseModel>(DomainKind.Boolean, modeller, rendering)
  , IDomainBooleanModelChecks
{
  protected override string[] ExpectedItem(bool input, string exclude, string[] domain)
    => ["- !_DomainTrueFalse", .. domain, exclude, "  value: " + input.TrueFalse()];

  protected override DomainTrueFalseAst[]? DomainItems(bool[]? inputs)
    => inputs?.DomainTrueFalses();
}

public interface IDomainBooleanModelChecks
  : ICheckDomainModel<bool, IGqlpDomainTrueFalse, DomainTrueFalseModel>
{ }
