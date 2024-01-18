using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Ast.Schema;

public sealed record class ScalarRangeAst(TokenAt At)
  : AstAbbreviated(At), IEquatable<ScalarRangeAst>
{
  public decimal? Lower { get; set; }
  public decimal? Upper { get; set; }

  internal override string Abbr => "SR";

  public ScalarRangeAst(TokenAt at, decimal? lower, decimal? upper)
    : this(at)
    => (Lower, Upper) = (lower, upper);

  public bool Equals(ScalarRangeAst? other)
    => base.Equals(other)
      && (Lower == other.Lower || Lower is null && other.Lower is null)
      && (Upper == other.Upper || Upper is null && other.Upper is null);
  public override int GetHashCode()
    => HashCode.Combine(base.GetHashCode(), Lower, Upper);
  internal override IEnumerable<string?> GetFields()
  => Lower == Upper
    ? base.GetFields().Append(Lower?.ToString())
    : base.GetFields()
      .Append(Lower?.ToString())
      .Append(":")
      .Append(Upper?.ToString());
}
