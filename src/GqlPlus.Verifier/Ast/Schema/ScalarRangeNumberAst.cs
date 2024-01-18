﻿using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Ast.Schema;

public sealed record class ScalarRangeNumberAst(TokenAt At)
  : AstAbbreviated(At), IEquatable<ScalarRangeNumberAst>
{
  public decimal? Lower { get; set; }
  public decimal? Upper { get; set; }

  internal override string Abbr => "SR";

  public ScalarRangeNumberAst(TokenAt at, decimal? lower, decimal? upper)
    : this(at)
    => (Lower, Upper) = (lower, upper);

  public bool Equals(ScalarRangeNumberAst? other)
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
