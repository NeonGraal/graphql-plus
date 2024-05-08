using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Simple;

namespace GqlPlus.Modelling.Simple;

public class DomainBooleanModelTests(
  IDomainModeller<IGqlpDomainTrueFalse, DomainTrueFalseModel> modeller
) : TestDomainModel<bool, DomainTrueFalseAst, IGqlpDomainTrueFalse>
{
  internal override ICheckDomainModel<bool, DomainTrueFalseAst, IGqlpDomainTrueFalse> DomainChecks => _checks;

  private readonly DomainBooleanModelChecks _checks = new(modeller);
}

internal sealed class DomainBooleanModelChecks(
  IDomainModeller<IGqlpDomainTrueFalse, DomainTrueFalseModel> modeller
) : CheckDomainModel<bool, DomainTrueFalseAst, IGqlpDomainTrueFalse, DomainTrueFalseModel>(DomainKind.Boolean, modeller)
{
  protected override string[] ExpectedItem(bool input, string exclude, string[] domain)
    => ["- !_DomainTrueFalse", .. domain, exclude, "  value: " + input.TrueFalse()];

  protected override DomainTrueFalseAst[]? DomainItems(bool[]? inputs)
    => inputs?.DomainTrueFalses();
}
