using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Ast.Schema;

public sealed record class ScalarMemberEnumAst(TokenAt At)
  : AstAbbreviated(At), IEquatable<ScalarMemberEnumAst>
{
  public string? Lower { get; set; }
  public string? Upper { get; set; }

  internal override string Abbr => "SR";

  public ScalarMemberEnumAst(TokenAt at, string? lower, string? upper)
    : this(at)
    => (Lower, Upper) = (lower, upper);

  public bool Equals(ScalarMemberEnumAst? other)
    => base.Equals(other)
      && Lower.NullEqual(other.Lower)
      && Upper.NullEqual(other.Upper);
  public override int GetHashCode()
    => HashCode.Combine(base.GetHashCode(), Lower, Upper);
  internal override IEnumerable<string?> GetFields()
  => Lower.NullEqual(Upper)
    ? base.GetFields()
      .Append(Lower?.ToString())
    : base.GetFields()
      .Append(Lower?.ToString())
      .Append("~")
      .Append(Upper?.ToString());
}
