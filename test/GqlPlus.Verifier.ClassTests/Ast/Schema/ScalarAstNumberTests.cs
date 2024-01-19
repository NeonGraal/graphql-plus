namespace GqlPlus.Verifier.Ast.Schema;

public class ScalarAstNumberTests
  : AstAliasedTests
{
  [Theory, RepeatData(Repeats)]
  public void HashCode_WithRanges(string name, MemberInput<decimal> input)
      => _checks.HashCode(
        () => ScalarNumber(name, input.ScalarMembers(ScalarRangeNumber)));

  [Theory, RepeatData(Repeats)]
  public void String_WithRanges(string name, MemberInput<decimal> input)
    => _checks.String(
      () => ScalarNumber(name, input.ScalarMembers(ScalarRangeNumber)),
      $"( !S {name} Number !SR < {input.Lower} !SR ! {input.Lower} ~ {input.Upper} !SR {input.Upper} > )");

  [Theory, RepeatData(Repeats)]
  public void Equality_WithRanges(string name, MemberInput<decimal> input)
    => _checks.Equality(
      () => ScalarNumber(name, input.ScalarMembers(ScalarRangeNumber)));

  [Theory, RepeatData(Repeats)]
  public void Inequality_BetweenRanges(string name, MemberInput<decimal> input1, MemberInput<decimal> input2)
    => _checks.InequalityBetween(input1, input2,
      input => ScalarNumber(name, input.ScalarMembers(ScalarRangeNumber)),
      input1 == input2);

  protected override string AliasesString(string input, string aliases)
    => $"( !S {input}{aliases} Number )";

  private readonly AstAliasedChecks<ScalarDeclAst> _checks
    = new(name => ScalarNumber(name, []));

  internal override IAstAliasedChecks<string> AliasedChecks => _checks;

  private static ScalarRangeNumberAst ScalarRangeNumber(decimal lower, decimal upper, bool? rightNull)
    => rightNull switch {
      false => new(AstNulls.At, false, null, upper),
      true => new(AstNulls.At, false, lower, null),
      _ => new(AstNulls.At, false, lower, upper),
    };

  private static ScalarDeclAst ScalarNumber(string name, ScalarRangeNumberAst[] list)
    => new(AstNulls.At, name, list) { Kind = ScalarKind.Number };
}
