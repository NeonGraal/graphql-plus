﻿using GqlPlus.Abstractions.Schema;
using GqlPlus.Token;

namespace GqlPlus.Ast.Schema.Simple;

internal record class AstDomain<TItemAst, TItem>(
  TokenAt At,
  string Name,
  string Description,
  DomainKind DomainKind
) : AstDomain(At, Name, Description, DomainKind)
  , IGqlpDomain<TItem>
  where TItemAst : AstBase, TItem
  where TItem : IGqlpDomainItem, IGqlpError
{
  public TItemAst[] Items { get; set; } = [];

  internal override string Abbr => "Do";
  public override string Label => "Domain";

  IEnumerable<TItem> IGqlpSimple<TItem>.Items => Items;

  public AstDomain(TokenAt at, string name, DomainKind kind, TItemAst[] items)
    : this(at, name, "", kind)
    => Items = items;

  public virtual bool Equals(AstDomain<TItemAst, TItem>? other)
    => other is IGqlpSimple<TItem> simple && Equals(simple);
  public bool Equals(IGqlpDomain<TItem> other)
    => Equals(other as IGqlpSimple<TItem>);
  public bool Equals(IGqlpSimple<TItem> other)
    => base.Equals(other)
      && Items.SequenceEqual(other.Items);
  public override int GetHashCode()
    => HashCode.Combine(base.GetHashCode(), DomainKind, Items.Length);
  internal override IEnumerable<string?> GetFields()
    => base.GetFields()
      .Append(DomainKind.ToString())
      .Append(Parent.Prefixed(":"))
      .Concat(Items.Bracket());
}

internal abstract record class AstDomain(
  TokenAt At,
  string Name,
  string Description,
  DomainKind DomainKind
) : AstSimple(At, Name, Description)
  , IGqlpDomain
{
  public virtual bool Equals(AstDomain? other)
    => other is IGqlpDomain domain && Equals(domain);
  public bool Equals(IGqlpDomain? other)
    => base.Equals(other)
    && DomainKind == other.DomainKind;
  public override int GetHashCode() => base.GetHashCode();
}
