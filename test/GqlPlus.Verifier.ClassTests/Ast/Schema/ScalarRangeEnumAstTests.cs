namespace GqlPlus.Verifier.Ast.Schema;

public class ScalarRangeEnumAstTests
  : AstAbbreviatedTests<MemberInput<string>>
{
  protected override string AbbreviatedString(MemberInput<string> input)
    => $"( !SR {input} )";

  private readonly AstAbbreviatedChecks<MemberInput<string>, ScalarMemberEnumAst> _checks
    = new(input => new ScalarMemberEnumAst(AstNulls.At, false, input.Lower, input.Upper));

  internal override IAstAbbreviatedChecks<MemberInput<string>> AbbreviatedChecks => _checks;
}
