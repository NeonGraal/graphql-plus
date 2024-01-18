namespace GqlPlus.Verifier.Ast.Schema;

public class ScalarRangeAstTests : AstAbbreviatedTests<RangeInput>
{
  protected override string AbbreviatedString(RangeInput input)
    => $"( !SR {input.StringExcluded(false, false)} )";

  private readonly AstAbbreviatedChecks<RangeInput, ScalarRangeAst> _checks
    = new(input => new ScalarRangeAst(AstNulls.At, input.Lower, input.Upper));

  internal override IAstAbbreviatedChecks<RangeInput> AbbreviatedChecks => _checks;
}

public record struct RangeInput(decimal? Min, decimal? Max)
{
  internal readonly decimal? Lower => Max < Min ? Max : Min;
  internal readonly decimal? Upper => Max < Min ? Min : Max;

  internal readonly string StringExcluded(bool minEx, bool maxEx)
  {
    var upExc = maxEx ? "< " : "";
    var lowExc = minEx ? " >" : "";
    return Lower is null ? $": {upExc}{Upper}"
      : Upper is null ? $"{Lower}{lowExc} :"
      : $"{Lower}{lowExc} : {upExc}{Upper}";
  }

  public readonly ScalarRangeAst[] ScalarRanges()
    => new ScalarRangeAst[] { new(AstNulls.At, Lower, Upper) };
}
