namespace GqlPlus.Ast.Schema.Simple;

public class DomainRegexAstTests
  : AstAbbreviatedTests
{
  protected override string AbbreviatedString(string input)
    => $"( !DX /{input}/ )";

  private readonly AstAbbreviatedChecks<DomainRegexAst> _checks
    = new(CreateRegex, CloneRegex);

  private static DomainRegexAst CloneRegex(DomainRegexAst original, string input)
    => original with { Pattern = input };
  private static DomainRegexAst CreateRegex(string input)
    => new(AstNulls.At, "", false, input);

  internal override IAstAbbreviatedChecks<string> AbbreviatedChecks => _checks;
}
