using GqlPlus.Abstractions.Schema;
using GqlPlus.Token;

namespace GqlPlus.Ast.Schema.Simple;

public record class AstDomain<TMember, TItem>(
  TokenAt At,
  string Name,
  string Description,
  DomainKind DomainKind
) : AstDomain(At, Name, Description, DomainKind)
  , IEquatable<AstDomain<TMember, TItem>>
  , IGqlpDomain<TItem>
  where TMember : AstBase, TItem
  where TItem : IGqlpDomainItem, IGqlpError
{
  public TMember[] Members { get; set; } = [];

  internal override string Abbr => "Do";
  public override string Label => "Domain";

  public IEnumerable<TItem> Items => Members;

  public AstDomain(TokenAt at, string name, DomainKind kind, TMember[] members)
    : this(at, name, "", kind)
    => Members = members;

  public virtual bool Equals(AstDomain<TMember, TItem>? other)
    => base.Equals(other)
      && DomainKind == other.DomainKind
      && Members.SequenceEqual(other.Members);
  public override int GetHashCode()
    => HashCode.Combine(base.GetHashCode(), DomainKind, Members.Length);
  internal override IEnumerable<string?> GetFields()
    => base.GetFields()
      .Append(DomainKind.ToString())
      .Append(Parent.Prefixed(":"))
      .Concat(Members.Bracket());
}

public abstract record class AstDomain(
  TokenAt At,
  string Name,
  string Description,
  DomainKind DomainKind
) : AstSimple(At, Name, Description)
  , IGqlpDomain
{ }
