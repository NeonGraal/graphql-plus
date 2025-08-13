using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Simple;

namespace GqlPlus.Modelling.Schema.Simple;

public class DomainStringModelTests(
  IDomainStringModelChecks checks
) : TestDomainModel<string, IGqlpDomainRegex, DomainRegexModel>(checks)
{ }

internal sealed class DomainStringModelChecks(
  CheckDomainInputs<IGqlpDomainRegex, DomainRegexModel> inputs
) : CheckDomainModel<string, DomainRegexAst, IGqlpDomainRegex, DomainRegexModel>(DomainKind.String, inputs)
  , IDomainStringModelChecks
{
  protected override string[] ExpectedItem(string input, string exclude, string[] domain)
    => ["  - !_DomainRegex", .. domain, exclude, "    pattern: " + input];

  protected override DomainRegexAst[]? DomainItems(string[]? inputs)
    => inputs?.DomainRegexes();
}

public interface IDomainStringModelChecks
  : ICheckDomainModel<string, IGqlpDomainRegex, DomainRegexModel>
{ }
