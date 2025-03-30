﻿using GqlPlus.Abstractions.Operation;
using GqlPlus.Token;

namespace GqlPlus.Ast.Operation;

internal sealed record class SpreadAst(
  TokenAt At,
  string Identifier
) : AstDirectives(At, Identifier)
  , IEquatable<SpreadAst>
  , IGqlpSpread
{
  internal override string Abbr => "s";

  public bool Equals(SpreadAst? other)
    => base.Equals(other);
  public override int GetHashCode()
    => base.GetHashCode();
}
