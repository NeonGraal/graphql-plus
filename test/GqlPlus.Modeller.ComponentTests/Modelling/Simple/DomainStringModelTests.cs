using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Simple;

namespace GqlPlus.Modelling.Simple;

public class DomainStringModelTests(
  IDomainModeller<IGqlpDomainRegex, DomainRegexModel> modeller
) : TestDomainModel<string, DomainRegexAst, IGqlpDomainRegex>
{
  internal override ICheckDomainModel<string, DomainRegexAst, IGqlpDomainRegex> DomainChecks => _checks;

  private readonly DomainStringModelChecks _checks = new(modeller);
}

internal sealed class DomainStringModelChecks(
  IDomainModeller<IGqlpDomainRegex, DomainRegexModel> modeller
) : CheckDomainModel<string, DomainRegexAst, IGqlpDomainRegex, DomainRegexModel>(DomainKind.String, modeller)
{
  protected override string[] ExpectedItem(string input, string exclude, string[] domain)
    => ["- !_DomainRegex", .. domain, exclude, "  pattern: " + input];

  protected override DomainRegexAst[]? DomainItems(string[]? inputs)
    => inputs?.DomainRegexes();
}
