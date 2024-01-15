namespace GqlPlus.Verifier.Ast.Schema;

public class ScalarRegexAstTests : AstAbbreviatedTests
{
  protected override string AbbreviatedString(string input)
    => $"( !SX /{input}/ )";

  private readonly AstAbbreviatedChecks<ScalarRegexAst> _checks
    = new(regex => new ScalarRegexAst(AstNulls.At, regex, false));

  internal override IAstAbbreviatedChecks<string> AbbreviatedChecks => _checks;
}
