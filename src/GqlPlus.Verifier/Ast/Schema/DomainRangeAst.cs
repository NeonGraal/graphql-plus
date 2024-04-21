using System.Globalization;
using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Ast.Schema;

public sealed record class DomainRangeAst(TokenAt At, bool Excludes)
  : AstDomainItem(At, Excludes), IEquatable<DomainRangeAst>
{
  public decimal? Lower { get; set; }
  public decimal? Upper { get; set; }

  internal override string Abbr => "SR";

  public DomainRangeAst(TokenAt at, bool excludes, decimal? lower, decimal? upper)
    : this(at, excludes)
    => (Lower, Upper) = (lower, upper);

  public bool Equals(DomainRangeAst? other)
    => base.Equals(other)
      && Lower.NullEqual(other.Lower)
      && Upper.NullEqual(other.Upper);
  public override int GetHashCode()
    => HashCode.Combine(base.GetHashCode(), Lower, Upper);
  internal override IEnumerable<string?> GetFields()
  => Lower is null
    ? base.GetFields()
      .Append("<")
      .Append(Upper?.ToString(CultureInfo.InvariantCulture))
    : Upper is null
    ? base.GetFields()
      .Append(Lower?.ToString(CultureInfo.InvariantCulture))
      .Append(">")
    : Lower.Equals(Upper)
    ? base.GetFields()
      .Append(Lower?.ToString(CultureInfo.InvariantCulture))
    : base.GetFields()
      .Append(Lower?.ToString(CultureInfo.InvariantCulture))
      .Append("~")
      .Append(Upper?.ToString(CultureInfo.InvariantCulture));
}
