using GqlPlus.Token;

namespace GqlPlus.Ast.Schema.Simple;

public record class AstDomain<TMember>(
  TokenAt At,
  string Name,
  string Description,
  DomainKind DomainKind
) : AstDomain(At, Name, Description, DomainKind)
  , IAstSimple<TMember>
  , IEquatable<AstDomain<TMember>>
  where TMember : AstAbbreviated, IAstDomainItem
{
  public TMember[] Members { get; set; } = [];

  internal override string Abbr => "Do";
  public override string Label => "Domain";

  public AstDomain(TokenAt at, string name, DomainKind kind, TMember[] members)
    : this(at, name, "", kind)
    => Members = members;

  public virtual bool Equals(AstDomain<TMember>? other)
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
{ }

public enum DomainKind
{
  Boolean,
  Enum,
  Number,
  String,
}
