﻿using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Ast.Schema;

public sealed record class ScalarMemberEnumAst(TokenAt At, bool Excludes)
  : AstScalarMember(At, Excludes), IEquatable<ScalarMemberEnumAst>
{
  public string? Lower { get; set; }
  public string? Upper { get; set; }

  internal override string Abbr => "SR";

  public ScalarMemberEnumAst(TokenAt at, bool excludes, string? lower, string? upper)
    : this(at, excludes)
    => (Lower, Upper) = (lower, upper);

  public bool Equals(ScalarMemberEnumAst? other)
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
