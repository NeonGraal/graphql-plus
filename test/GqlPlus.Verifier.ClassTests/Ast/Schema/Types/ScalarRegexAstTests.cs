namespace GqlPlus.Verifier.Ast.Schema.Types;

public class ScalarRegexAstTests : AstAbbreviatedTests
{
  protected override string AbbreviatedString(string input)
    => $"( !SX /{input}/ )";

  private readonly AstAbbreviatedChecks<ScalarRegexAst> _checks
    = new(regex => new ScalarRegexAst(AstNulls.At, false, regex));

  internal override IAstAbbreviatedChecks<string> AbbreviatedChecks => _checks;
}
