﻿using GqlPlus.Abstractions.Schema;
using GqlPlus.Token;

namespace GqlPlus.Ast.Schema.Simple;

internal sealed record class EnumLabelAst(
  TokenAt At,
  string Name,
  string Description
) : AstAliased(At, Name, Description)
  , IGqlpEnumLabel
{
  public EnumLabelAst(TokenAt at, string name)
    : this(at, name, "") { }

  internal override string Abbr => "EL";

  public bool Equals(EnumLabelAst? other)
    => other is IGqlpEnumLabel label && Equals(label);
  public bool Equals(IGqlpEnumLabel? other)
    => base.Equals(other);
  public override int GetHashCode()
    => base.GetHashCode();
}
