namespace GqlPlus.Verifier.Ast.Schema.Types;

public class ScalarMemberAstTests : AstAbbreviatedTests
{
  private readonly AstAbbreviatedChecks<ScalarMemberAst> _checks
    = new(member => new ScalarMemberAst(AstNulls.At, false, member));

  internal override IAstAbbreviatedChecks<string> AbbreviatedChecks => _checks;
}
