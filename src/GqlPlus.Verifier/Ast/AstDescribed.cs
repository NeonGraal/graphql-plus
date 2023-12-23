﻿using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Ast;

public abstract record class AstDescribed(TokenAt At, string Name, string Description)
  : AstNamed(At, Name), IEquatable<AstDescribed>, IAstDescribed
{
  public virtual bool Equals(AstDescribed? other)
    => base.Equals(other)
    && Description.Equals(other.Description);
  public override int GetHashCode()
    => HashCode.Combine(base.GetHashCode(), Description);

  internal override IEnumerable<string?> GetFields()
    => base.GetFields()
      .Prepend(Description.Quoted("\""));
}

public interface IAstDescribed
{
  string Description { get; }
}
