﻿namespace GqlPlus.Verifier.Ast.Schema;

public class ScalarRangeAstTests
  : AstAbbreviatedTests<RangeInput>
{
  protected override string AbbreviatedString(RangeInput input)
    => $"( !SR {input} )";

  private readonly AstAbbreviatedChecks<RangeInput, ScalarRangeAst> _checks
    = new(input => new ScalarRangeAst(AstNulls.At, false, input.Lower, input.Upper));

  internal override IAstAbbreviatedChecks<RangeInput> AbbreviatedChecks => _checks;
}

public record struct RangeInput(decimal? Min, decimal? Max)
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

  public readonly ScalarRangeAst[] ScalarRanges()
    => new ScalarRangeAst[] { new(AstNulls.At, false, Lower, Upper) };
}
