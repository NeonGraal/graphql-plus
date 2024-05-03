using GqlPlus.Ast.Schema.Simple;

namespace GqlPlus.Modelling.Simple;

public class DomainStringModelTests(
  IDomainModeller<DomainRegexAst, DomainRegexModel> modeller
) : TestDomainModel<string, DomainRegexAst>
{
  internal override ICheckDomainModel<string, DomainRegexAst> DomainChecks => _checks;

  private readonly DomainStringModelChecks _checks = new(modeller);
}

internal sealed class DomainStringModelChecks(
  IDomainModeller<DomainRegexAst, DomainRegexModel> modeller
) : CheckDomainModel<string, DomainRegexAst, DomainRegexModel>(DomainKind.String, modeller)
{
  protected override string[] ExpectedItem(string input, string exclude, string[] domain)
    => ["- !_DomainRegex", .. domain, exclude, "  regex: " + input];

  protected override DomainRegexAst[]? DomainItems(string[]? inputs)
    => inputs?.DomainRegexes();
}
