namespace GqlPlus.Verifier.Ast.Schema;

public class ScalarRangeNumberAstTests
  : AstAbbreviatedTests<RangeNumberInput>
{
  protected override string AbbreviatedString(RangeNumberInput input)
    => $"( !SR {input} )";

  private readonly AstAbbreviatedChecks<RangeNumberInput, ScalarRangeNumberAst> _checks
    = new(input => new ScalarRangeNumberAst(AstNulls.At, false, input.Lower, input.Upper));

  internal override IAstAbbreviatedChecks<RangeNumberInput> AbbreviatedChecks => _checks;
}

public record struct RangeNumberInput(decimal? Min, decimal? Max)
{
  internal readonly decimal? Lower => Max < Min ? Max : Min;
  internal readonly decimal? Upper => Max < Min ? Min : Max;

  public override readonly string ToString()
  {
    if (Lower is null) {
      return $"< {Upper}";
    }

    var result = $"{Lower}";

    if (Upper is null) {
      result += " >";
    } else if (Upper != Lower) {
      result += $" ~ {Upper}";
    }

    return result;
  }

  public readonly ScalarRangeNumberAst[] ScalarRanges()
    => new ScalarRangeNumberAst[] { new(AstNulls.At, false, Lower, Upper) };
}
