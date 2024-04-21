namespace GqlPlus.Verifier.Ast.Schema.Types;

public class DomainRegexAstTests
  : AstAbbreviatedTests
{
  protected override string AbbreviatedString(string input)
    => $"( !SX /{input}/ )";

  private readonly AstAbbreviatedChecks<DomainRegexAst> _checks
    = new(regex => new DomainRegexAst(AstNulls.At, false, regex));

  internal override IAstAbbreviatedChecks<string> AbbreviatedChecks => _checks;
}
