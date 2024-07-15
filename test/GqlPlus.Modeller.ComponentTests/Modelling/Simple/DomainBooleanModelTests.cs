using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Simple;

namespace GqlPlus.Modelling.Simple;

public class DomainBooleanModelTests(
  IDomainBooleanModelChecks checks
) : TestDomainModel<bool, IGqlpDomainTrueFalse, DomainTrueFalseModel>(checks)
{ }

internal sealed class DomainBooleanModelChecks(
  CheckDomainInputs<IGqlpDomainTrueFalse, DomainTrueFalseModel> inputs
) : CheckDomainModel<bool, DomainTrueFalseAst, IGqlpDomainTrueFalse, DomainTrueFalseModel>(DomainKind.Boolean, inputs)
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
