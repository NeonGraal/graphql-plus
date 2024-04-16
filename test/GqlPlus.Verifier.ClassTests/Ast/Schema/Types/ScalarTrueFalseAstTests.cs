namespace GqlPlus.Verifier.Ast.Schema.Types;

public class ScalarTrueFalseAstTests : AstAbbreviatedTests<bool>
{
  private readonly AstAbbreviatedChecks<bool, ScalarTrueFalseAst> _checks
    = new(input => new ScalarTrueFalseAst(AstNulls.At, false, input));

  internal override IAstAbbreviatedChecks<bool> AbbreviatedChecks => _checks;
}
