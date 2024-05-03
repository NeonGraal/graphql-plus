﻿using GqlPlus.Token;

namespace GqlPlus.Ast;

public abstract record class AstNamed(
  TokenAt At,
  string Name
) : AstAbbreviated(At)
  , IEquatable<AstNamed>
{
  public string Name { get; set; } = Name;

  public virtual bool Equals(AstNamed? other)
    => base.Equals(other)
    && string.Equals(Name, other.Name, StringComparison.Ordinal);
  public override int GetHashCode()
    => HashCode.Combine(base.GetHashCode(), Name);

  internal override IEnumerable<string?> GetFields()
    => base.GetFields().Append(Name);
}
