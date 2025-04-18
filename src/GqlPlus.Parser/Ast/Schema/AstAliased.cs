﻿using GqlPlus.Abstractions.Schema;
using GqlPlus.Token;

namespace GqlPlus.Ast.Schema;

internal abstract record class AstAliased(
  TokenAt At,
  string Name,
  string Description
) : AstNamed(At, Name, Description)
  , IEquatable<AstAliased>
  , IGqlpAliased
  , IAstSetAliases
{
  public string[] Aliases { get; set; } = [];
  IEnumerable<string> IGqlpAliased.Aliases => Aliases;

  public virtual bool Equals(AstAliased? other)
    => base.Equals(other)
    && Aliases.OrderedEqual(other.Aliases);
  public override int GetHashCode()
    => HashCode.Combine(base.GetHashCode(), Aliases.Length);

  internal override IEnumerable<string?> GetFields()
    => base.GetFields()
      .Concat(Aliases.Bracket("[", "]"));
  void IAstSetAliases.SetAliases(IEnumerable<string> aliases)
    => Aliases = [.. aliases];
}

internal interface IAstSetAliases
  : IAstSetDescription
{
  void SetAliases(IEnumerable<string> aliases);
}
