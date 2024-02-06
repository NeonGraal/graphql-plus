namespace GqlPlus.Verifier.Ast.Schema;

public class ScalarReferenceAstTests : AstAbbreviatedTests
{
  private readonly AstAbbreviatedChecks<ScalarReferenceAst> _checks
    = new(name => new ScalarReferenceAst(AstNulls.At, name));

  internal override IAstAbbreviatedChecks<string> AbbreviatedChecks => _checks;
}
