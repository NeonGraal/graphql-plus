using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Ast.Schema.Simple;

public record class AstDomain<TMember>(
  TokenAt At,
  string Name,
  string Description,
  DomainKind DomainKind
) : AstDomain(At, Name, Description, DomainKind), IEquatable<AstDomain<TMember>>
  where TMember : IAstDomainItem
{
  public TMember[] Items { get; set; } = [];

  internal override string Abbr => "Do";
  public override string Label => "Domain";

  public AstDomain(TokenAt at, string name, DomainKind kind, TMember[] members)
    : this(at, name, "", kind)
    => Items = members;

  public virtual bool Equals(AstDomain<TMember>? other)
    => base.Equals(other)
      && DomainKind == other.DomainKind
      && Items.SequenceEqual(other.Items);
  public override int GetHashCode()
    => HashCode.Combine(base.GetHashCode(), DomainKind, Items.Length);
  internal override IEnumerable<string?> GetFields()
    => base.GetFields()
      .Append(DomainKind.ToString())
      .Append(Parent.Prefixed(":"))
      .Concat(Items.Bracket());
}

public abstract record class AstDomain(
  TokenAt At,
  string Name,
  string Description,
  DomainKind DomainKind
) : AstSimple(At, Name, Description)
{ }

public enum DomainKind
{
  Boolean,
  Enum,
  Number,
  String,
}
