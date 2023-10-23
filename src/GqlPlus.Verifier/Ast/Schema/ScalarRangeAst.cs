namespace GqlPlus.Verifier.Ast.Schema;

internal sealed record class ScalarRangeAst(ParseAt At)
  : AstBase(At), IEquatable<ScalarRangeAst>
{
  public decimal? Lower { get; set; }
  public bool LowerExcluded { get; set; }
  public decimal? Upper { get; set; }
  public bool UpperExcluded { get; set; }

  internal override string Abbr => "SR";

  public ScalarRangeAst(ParseAt at, decimal? lower, decimal? upper)
    : this(at)
  {
    if (upper < lower) {
      Lower = upper;
      Upper = lower;
    } else {
      Lower = lower;
      Upper = upper;
    }
  }

  public bool Equals(ScalarRangeAst? other)
    => base.Equals(other)
      && (Lower == other.Lower || Lower is null && other.Lower is null)
      && LowerExcluded == other.LowerExcluded
      && (Upper == other.Upper || Upper is null && other.Upper is null)
      && UpperExcluded == other.UpperExcluded;
  public override int GetHashCode()
    => HashCode.Combine(base.GetHashCode(), Lower, LowerExcluded, Upper, UpperExcluded);
  internal override IEnumerable<string?> GetFields()
  => base.GetFields()
      .Append(Lower?.ToString().Suffixed(LowerExcluded ? " >" : ""))
      .Append("..")
      .Append(Upper?.ToString().Prefixed(UpperExcluded ? "< " : ""));
}
