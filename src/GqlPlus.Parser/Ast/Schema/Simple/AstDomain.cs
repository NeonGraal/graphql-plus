using GqlPlus;
using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Ast.Schema.Simple;

internal record class AstDomain<TItemAst, TItem>(
  ITokenAt At,
  string Name,
  string Description,
  DomainKind DomainKind
) : AstDomain(At, Name, Description, DomainKind)
  , IGqlpDomain<TItem>
  where TItemAst : AstBase, TItem
  where TItem : IGqlpDomainItem, IGqlpError
{
  public TItem[] Items { get; set; } = [];

  IEnumerable<TItem> IGqlpSimple<TItem>.Items => Items;

  public AstDomain(ITokenAt at, string name, DomainKind kind, TItem[] items)
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
  ITokenAt At,
  string Name,
  string Description,
  DomainKind DomainKind
) : AstSimple(At, Name, Description)
  , IGqlpDomain
{
  public override TypeKind Kind => TypeKind.Domain;

  public bool Equals(IGqlpDomain? other)
    => base.Equals(other)
    && DomainKind == other.DomainKind;
  public override int GetHashCode() => base.GetHashCode();
}
