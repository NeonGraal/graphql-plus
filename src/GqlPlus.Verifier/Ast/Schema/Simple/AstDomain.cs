using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Ast.Schema.Simple;

public record class AstDomain<TMember>(
  TokenAt At,
  string Name,
  string Description,
  DomainDomain Domain
) : AstDomain(At, Name, Description, Domain), IEquatable<AstDomain<TMember>>
  where TMember : IAstDomainItem
{
  public TMember[] Items { get; set; } = [];

  internal override string Abbr => "S";
  public override string Label => "Domain";

  public AstDomain(TokenAt at, string name, DomainDomain domain, TMember[] members)
    : this(at, name, "", domain)
    => Items = members;

  public virtual bool Equals(AstDomain<TMember>? other)
    => base.Equals(other)
      && Domain == other.Domain
      && Items.SequenceEqual(other.Items);
  public override int GetHashCode()
    => HashCode.Combine(base.GetHashCode(), Domain, Items.Length);
  internal override IEnumerable<string?> GetFields()
    => base.GetFields()
      .Append(Domain.ToString())
      .Append(Parent.Prefixed(":"))
      .Concat(Items.Bracket());
}

public abstract record class AstDomain(
  TokenAt At,
  string Name,
  string Description,
  DomainDomain Domain
) : AstSimple(At, Name, Description)
{ }

public enum DomainDomain
{
  Boolean,
  Enum,
  Number,
  String,
}
