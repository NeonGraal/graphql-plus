using System.Globalization;

using GqlPlus.Abstractions.Schema;
using GqlPlus.Token;

namespace GqlPlus.Ast.Schema.Simple;

internal sealed record class DomainRangeAst(
  TokenAt At,
  string Description,
  bool Excludes
) : AstDomainItem(At, Description, Excludes)
  , IGqlpDomainRange
{
  public decimal? Lower { get; set; }
  public decimal? Upper { get; set; }

  internal override string Abbr => "DN";

  public DomainRangeAst(TokenAt at, string description, bool excludes, decimal? lower, decimal? upper)
    : this(at, description, excludes)
    => (Lower, Upper) = (lower, upper);

  public bool Equals(DomainRangeAst? other)
    => other is IGqlpDomainRange range && Equals(range);
  public bool Equals(IGqlpDomainRange? other)
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
