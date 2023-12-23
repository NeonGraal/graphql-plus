namespace GqlPlus.Verifier.Ast.Schema;

public class ScalarRegexAstTests : AstBaseTests
{
  protected override string InputString(string input)
    => $"( !SX /{input}/ )";

  private readonly AstBaseChecks<ScalarRegexAst> _checks
    = new(regex => new ScalarRegexAst(AstNulls.At, regex, false));

  internal override IAstBaseChecks NamedChecks => _checks;
}
