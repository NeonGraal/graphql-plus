﻿using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Ast.Schema;

public sealed record class ScalarRegexAst(TokenAt At, bool Excludes, string Regex)
  : AstScalarMember(At, Excludes), IEquatable<ScalarRegexAst>
{
  internal override string Abbr => "SX";

  public bool Equals(ScalarRegexAst? other)
    => base.Equals(other)
      && Regex == other.Regex
      && Excludes == other.Excludes;
  public override int GetHashCode()
    => HashCode.Combine(base.GetHashCode(), Regex, Excludes);

  internal override IEnumerable<string?> GetFields()
  => base.GetFields()
      .Append(Regex.Quoted("/").Prefixed(Excludes ? "!" : ""));
}
