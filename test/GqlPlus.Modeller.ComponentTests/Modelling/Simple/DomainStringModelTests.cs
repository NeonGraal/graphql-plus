using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Simple;

namespace GqlPlus.Modelling.Simple;

public class DomainStringModelTests(
  IDomainModeller<IGqlpDomainRegex, DomainRegexModel> modeller,
  IRenderer<BaseDomainModel<DomainRegexModel>> rendering
) : TestDomainModel<string, IGqlpDomainRegex>
{
  internal override ICheckDomainModel<string, IGqlpDomainRegex> DomainChecks => _checks;

  private readonly DomainStringModelChecks _checks = new(modeller, rendering);
}

internal sealed class DomainStringModelChecks(
  IDomainModeller<IGqlpDomainRegex, DomainRegexModel> modeller,
  IRenderer<BaseDomainModel<DomainRegexModel>> rendering
) : CheckDomainModel<string, DomainRegexAst, IGqlpDomainRegex, DomainRegexModel>(DomainKind.String, modeller, rendering)
{
  protected override string[] ExpectedItem(string input, string exclude, string[] domain)
    => ["- !_DomainRegex", .. domain, exclude, "  pattern: " + input];

  protected override DomainRegexAst[]? DomainItems(string[]? inputs)
    => inputs?.DomainRegexes();
}
