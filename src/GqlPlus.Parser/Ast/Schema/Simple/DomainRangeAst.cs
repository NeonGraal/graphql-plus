using System.Globalization;
using GqlPlus.Abstractions.Schema;
using GqlPlus.Token;

namespace GqlPlus.Ast.Schema.Simple;

internal sealed record class DomainRangeAst(
  ITokenAt At,
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

  public string LowerString => Lower is null ? string.Empty
    : Lower.Value.ToString(GqlpStrings.NumberFormat, CultureInfo.InvariantCulture);
  public string UpperString => Upper is null ? string.Empty
    : Upper.Value.ToString(GqlpStrings.NumberFormat, CultureInfo.InvariantCulture);
  public string AsString
  => Lower is null ? UpperString.Prefixed("<")
    : Upper is null ? LowerString.Suffixed(">")
    : Lower.Equals(Upper) ? LowerString
    : LowerString + "~" + UpperString;
  internal override IEnumerable<string?> GetFields()
  => base.GetFields()
    .Append((Excludes ? "!" : "") + AsString);
}
