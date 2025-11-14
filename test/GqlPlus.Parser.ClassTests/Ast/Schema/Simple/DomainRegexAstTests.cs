namespace GqlPlus.Ast.Schema.Simple;

public class DomainRegexAstTests
  : AstAbbreviatedBaseTests
{
  internal override IAstAbbreviatedChecks<string> AbbreviatedChecks { get; }
    = new DomainRegexAstChecks();
}

internal sealed class DomainRegexAstChecks()
  : AstAbbreviatedChecks<DomainRegexAst>(CreateRegex, CloneRegex)
{
  protected override string AbbreviatedString(string input)
    => $"( !DX /{input}/ )";

  private static DomainRegexAst CloneRegex(DomainRegexAst original, string input)
    => original with { Pattern = input };
  private static DomainRegexAst CreateRegex(string input)
    => new(AstNulls.At, "", false, input);
}
