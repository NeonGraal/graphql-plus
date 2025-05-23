﻿using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Ast.Schema;

internal abstract record class AstDescribed(
  ITokenAt At,
  string Description
) : AstAbbreviated(At)
  , IGqlpDescribed
  , IAstSetDescription
{
  public string Description { get; internal set; } = Description;

  public virtual bool Equals(AstDescribed? other)
    => other is IGqlpDescribed described && Equals(described);
  public bool Equals(IGqlpDescribed? other)
    => base.Equals(other)
    && Description.Equals(other.Description, StringComparison.Ordinal);
  public override int GetHashCode()
    => HashCode.Combine(base.GetHashCode(), Description);

  internal override IEnumerable<string?> GetFields()
    => base.GetFields()
      .Prepend(Description.Quoted("'"));
  void IAstSetDescription.SetDescription(string description)
    => Description = description;
}

internal interface IAstSetDescription
{
  void SetDescription(string description);
}
