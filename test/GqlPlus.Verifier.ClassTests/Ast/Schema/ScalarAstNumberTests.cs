namespace GqlPlus.Verifier.Ast.Schema;

public class ScalarAstNumberTests
  : AstScalarTests<ScalarRangeInput, ScalarRangeAst>
{
  protected override string AliasesString(string input, string aliases)
    => $"( !S {input}{aliases} Number )";

  private readonly AstAliasedChecks<AstScalar<ScalarRangeAst>> _checks
    = new(name => new(AstNulls.At, name, ScalarKind.Number, []));

  internal override IAstAliasedChecks<string> AliasedChecks => _checks;

  protected override string MembersString(string name, ScalarRangeInput input)
    => $"( !S {name} Number !SR < {input.Lower} !SR ! {input.Lower} ~ {input.Upper} !SR {input.Upper} > )";
  protected override ScalarRangeAst[] ScalarMembers(ScalarRangeInput input)
  => [new(AstNulls.At, false, null, input.Lower), new(AstNulls.At, true, input.Lower, input.Upper), new(AstNulls.At, false, input.Upper, null)];
  protected override AstScalar<ScalarRangeAst> NewScalar(string name, ScalarRangeAst[] list)
  => new(AstNulls.At, name, ScalarKind.Number, list);
}

public record struct ScalarRangeInput(decimal? Min, decimal? Max)
{
  private bool? _minLtMax;
  private bool MinLtMax
  {
    get {
      _minLtMax ??= Min is null || Max is null || Min <= Max;
      return _minLtMax.Value;
    }
  }

  internal decimal? Lower => MinLtMax ? Min : Max;
  internal decimal? Upper => MinLtMax ? Max : Min;

  public override string ToString()
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

  public ScalarRangeAst[] ScalarRange()
    => [new(AstNulls.At, false, Lower, Upper)];
}
