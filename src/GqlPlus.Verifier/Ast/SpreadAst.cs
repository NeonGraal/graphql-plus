﻿namespace GqlPlus.Verifier.Ast;

internal sealed record class SpreadAst(ParseAt At, string Name)
  : AstNamedDirectives(At, Name), AstSelection, IEquatable<SpreadAst>
{
  internal override string Abbr => "S";

  public bool Equals(SpreadAst? other)
    => base.Equals(other);
  public override int GetHashCode()
    => base.GetHashCode();
}
