namespace GqlPlus.Verifier.Ast.Schema;

public class ScalarRangeAstTests
  : AstAbbreviatedTests<ScalarRangeInput>
{
  protected override string AbbreviatedString(ScalarRangeInput input)
    => $"( !SR {input} )";

  private readonly AstAbbreviatedChecks<ScalarRangeInput, ScalarRangeAst> _checks
    = new(input => new ScalarRangeAst(AstNulls.At, false, input.Lower, input.Upper));

  internal override IAstAbbreviatedChecks<ScalarRangeInput> AbbreviatedChecks => _checks;
}
