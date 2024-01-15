﻿using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Ast;

public abstract record class AstAbbreviated(TokenAt At)
  : IEquatable<AstAbbreviated>, IAstBase
{
  internal abstract string Abbr { get; }

  public sealed override string ToString()
    => "( "
      + GetFields().Cast<string>().Joined()
      + " )";

  protected string AbbrAt
    => new[] { "!" + Abbr, At.ToString() }.Joined();

  internal virtual IEnumerable<string?> GetFields()
    => new[] { AbbrAt };

  internal TokenMessage Error(string message)
    => new(At, message);
  // override object.Equals
  public virtual bool Equals(AstAbbreviated? other)
    => other is not null;

  // override object.GetHashCode
  public override int GetHashCode() => 0;
}

internal interface IAstBase { }
