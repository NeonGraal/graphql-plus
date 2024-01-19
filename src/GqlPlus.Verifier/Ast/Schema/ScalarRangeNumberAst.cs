using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Ast.Schema;

public sealed record class ScalarRangeNumberAst(TokenAt At, bool Excludes)
  : AstScalarMember(At, Excludes), IEquatable<ScalarRangeNumberAst>
{
  public decimal? Lower { get; set; }
  public decimal? Upper { get; set; }

  internal override string Abbr => "SR";

  public ScalarRangeNumberAst(TokenAt at, bool excludes, decimal? lower, decimal? upper)
    : this(at, excludes)
    => (Lower, Upper) = (lower, upper);

  public bool Equals(ScalarRangeNumberAst? other)
    => base.Equals(other)
      && Lower.NullEqual(other.Lower)
      && Upper.NullEqual(other.Upper);
  public override int GetHashCode()
    => HashCode.Combine(base.GetHashCode(), Lower, Upper);
  internal override IEnumerable<string?> GetFields()
  => Lower is null
    ? base.GetFields()
      .Append("<")
      .Append(Upper?.ToString())
    : Upper is null
    ? base.GetFields()
      .Append(Lower?.ToString())
      .Append(">")
    : Lower.Equals(Upper)
    ? base.GetFields()
      .Append(Lower?.ToString())
    : base.GetFields()
      .Append(Lower?.ToString())
      .Append("~")
      .Append(Upper?.ToString());
}
