namespace GqlPlus.Verifier.Ast.Schema.Types;

public class ScalarRangeAstTests
  : AstAbbreviatedTests<ScalarRangeInput>
{
  private readonly AstAbbreviatedChecks<ScalarRangeInput, ScalarRangeAst> _checks
    = new(input => new ScalarRangeAst(AstNulls.At, false, input.Lower, input.Upper));

  internal override IAstAbbreviatedChecks<ScalarRangeInput> AbbreviatedChecks => _checks;
}
