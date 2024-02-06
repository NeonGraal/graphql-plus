namespace GqlPlus.Verifier.Ast.Schema;

public class ScalarFalseAstTests : AstAbbreviatedTests<bool>
{
  private readonly AstAbbreviatedChecks<bool, ScalarFalseAst> _checks
    = new(input => new ScalarFalseAst(AstNulls.At, input));

  internal override IAstAbbreviatedChecks<bool> AbbreviatedChecks => _checks;
}
