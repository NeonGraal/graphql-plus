﻿using GqlPlus.Abstractions.Schema;
using GqlPlus.Token;

namespace GqlPlus.Ast.Schema.Simple;

internal abstract record class AstSimple(
  TokenAt At,
  string Name,
  string Description
) : AstType<string>(At, Name, Description)
{ }

internal abstract record class AstSimple<TItemAst>(
  TokenAt At,
  string Name,
  string Description,
  TItemAst[] Items
) : AstSimple(At, Name, Description)
  , IGqlpSimple<TItemAst>
  where TItemAst : IGqlpNamed
{
  IEnumerable<TItemAst> IGqlpSimple<TItemAst>.Items => Items;

  public virtual bool Equals(AstSimple<TItemAst>? other)
    => base.Equals(other)
      && Items.SequenceEqual(other.Items);
  public override int GetHashCode()
    => HashCode.Combine(base.GetHashCode(), Items.Length);
  internal override IEnumerable<string?> GetFields()
    => base.GetFields()
      .Append(Parent.Prefixed(":"))
      .Concat(Items.Bracket());
}
