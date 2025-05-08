﻿using GqlPlus.Abstractions.Operation;

namespace GqlPlus.Ast.Operation;

internal sealed record class SpreadAst(
  ITokenAt At,
  string Identifier
) : AstDirectives(At, Identifier)
  , IGqlpSpread
{
  internal override string Abbr => "s";

  public bool Equals(IGqlpSpread? other)
    => base.Equals(other);
  public override int GetHashCode()
    => base.GetHashCode();
}
