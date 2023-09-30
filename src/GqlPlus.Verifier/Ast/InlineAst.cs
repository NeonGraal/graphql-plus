﻿namespace GqlPlus.Verifier.Ast;

internal sealed record class InlineAst : SelectionAst, IEquatable<InlineAst>
{
  internal string? OnType { get; set; }

  internal required SelectionAst[] Selections { get; set; }

  public bool Equals(InlineAst? other)
    => other is not null
    && OnType.NullEqual(other.OnType)
    && Selections.SequenceEqual(other.Selections);

  public override int GetHashCode()
    => HashCode.Combine(OnType, Selections);
}
