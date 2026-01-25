namespace GqlPlus.Ast.Schema.Simple;

public partial class DomainRegexAstTests
{
  [CheckTests(Inherited = true)]
  private IAstAbbreviatedChecks<string> AbbreviatedChecks { get; }
    = new DomainRegexAstChecks();

  [CheckTests]
  internal ICloneChecks<string> CloneChecks { get; }
    = new CloneChecks<string, DomainRegexAst>(DomainRegexAstChecks.CreateRegex, CloneRegex);
  private static DomainRegexAst CloneRegex(DomainRegexAst original, string input)
    => original with { Pattern = input };
}

internal sealed class DomainRegexAstChecks()
  : AstAbbreviatedChecks<DomainRegexAst>(CreateRegex)
{
  protected override string AbbreviatedString(string input)
    => $"( !DX /{input}/ )";

  internal static DomainRegexAst CreateRegex(string input)
    => new(AstNulls.At, input, false, input);
}
