namespace GqlPlus.Verifier.Ast.Schema;

public class ScalarRegexAstTests : BaseNamedAstTests
{
  protected override string InputString(string input)
    => $"( !SX /{input}/ )";

  private readonly BaseNamedAstChecks<ScalarRegexAst> _checks
    = new(regex => new ScalarRegexAst(AstNulls.At, regex, false));

  internal override IBaseNamedAstChecks NamedChecks => _checks;
}
