using GqlPlus.Verifier.Ast.Schema.Simple;
using GqlPlus.Verifier.Rendering;

namespace GqlPlus.Verifier.Modelling.Simple;

public class DomainBooleanModelTests(
  IDomainModeller<DomainTrueFalseAst, DomainTrueFalseModel> modeller
) : TestDomainModel<bool, DomainTrueFalseAst>
{
  internal override ICheckDomainModel<bool, DomainTrueFalseAst> DomainChecks => _checks;

  private readonly DomainBooleanModelChecks _checks = new(modeller);
}

internal sealed class DomainBooleanModelChecks(
  IDomainModeller<DomainTrueFalseAst, DomainTrueFalseModel> modeller
) : CheckDomainModel<bool, DomainTrueFalseAst, DomainTrueFalseModel>(DomainKind.Boolean, modeller)
{
  protected override string[] ExpectedItem(bool input, string exclude, string[] domain)
    => ["- !_DomainTrueFalse", .. domain, exclude, "  value: " + input.TrueFalse()];

  protected override DomainTrueFalseAst[]? DomainItems(bool[]? inputs)
    => inputs?.DomainTrueFalses();
}
