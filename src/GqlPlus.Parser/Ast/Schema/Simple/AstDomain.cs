using GqlPlus;

namespace GqlPlus.Ast.Schema.Simple;

internal record class AstDomain<TItemAst, TItem>(
  ITokenAt At,
  string Name,
  string Description,
  DomainKind DomainKind
) : AstDomain(At, Name, Description, DomainKind)
  , IAstDomain<TItem>
  where TItemAst : AstBase, TItem
  where TItem : IAstDomainItem, IAstError
{
  public TItem[] Items { get; set; } = [];

  IEnumerable<TItem> IAstSimple<TItem>.Items => Items;

  public AstDomain(
    ITokenAt at,
    string name,
    DomainKind kind,
    TItem[] items
  ) : this(at, name, "", kind)
    => Items = items;

  public virtual bool Equals(AstDomain<TItemAst, TItem>? other)
    => other is IAstSimple<TItem> simple && Equals(simple);
  public bool Equals(IAstDomain<TItem> other)
    => Equals(other as IAstSimple<TItem>);
  public bool Equals(IAstSimple<TItem> other)
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
  , IAstDomain
{
  public override TypeKind Kind => TypeKind.Domain;

  public bool Equals(IAstDomain? other)
    => base.Equals(other)
    && DomainKind == other.DomainKind;
  public override int GetHashCode() => base.GetHashCode();
}
