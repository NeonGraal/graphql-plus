﻿namespace GqlPlus.Verifier.Ast.Schema;

public class ScalarRangeAstTests : AstAbbreviatedTests<RangeInput>
{

  [Theory, RepeatData(Repeats)]
  public void HashCode_WithExcluded(RangeInput input, bool lowerExcluded, bool upperExcluded)
      => _checks.HashCode(
        () => new ScalarRangeAst(AstNulls.At, input.Lower, input.Upper) { LowerExcluded = lowerExcluded, UpperExcluded = upperExcluded });

  [Theory, RepeatData(Repeats)]
  public void String_WithExcluded(RangeInput input, bool lowerExcluded, bool upperExcluded)
    => _checks.String(
      () => new ScalarRangeAst(AstNulls.At, input.Lower, input.Upper) { LowerExcluded = lowerExcluded, UpperExcluded = upperExcluded },
      $"( !SR {input.StringExcluded(lowerExcluded, upperExcluded)} )");

  [Theory, RepeatData(Repeats)]
  public void Equality_WithExcluded(RangeInput input, bool lowerExcluded, bool upperExcluded)
    => _checks.Equality(
      () => new ScalarRangeAst(AstNulls.At, input.Lower, input.Upper) { LowerExcluded = lowerExcluded, UpperExcluded = upperExcluded });

  [Theory, RepeatData(Repeats)]
  public void Inequality_BetweenExcludeds(RangeInput input, (bool, bool) excluded1, (bool, bool) excluded2)
    => _checks.InequalityBetween<(bool, bool)>(excluded1, excluded2,
      param => new ScalarRangeAst(AstNulls.At, input.Lower, input.Upper) { LowerExcluded = param.Item1, UpperExcluded = param.Item2 },
      excluded1 == excluded2);

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
