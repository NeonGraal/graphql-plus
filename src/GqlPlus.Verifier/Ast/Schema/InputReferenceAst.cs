﻿namespace GqlPlus.Verifier.Ast.Schema;

public sealed record class InputReferenceAst(TokenAt At, string Name)
  : AstReference<InputReferenceAst>(At, Name), IEquatable<InputReferenceAst>
{
  internal override string Abbr => "IR";

  public override bool Equals(InputReferenceAst? other)
    => base.Equals(other);
  public override int GetHashCode()
    => base.GetHashCode();
}
