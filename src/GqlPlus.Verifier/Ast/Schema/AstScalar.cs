using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Ast.Schema;

public record class AstScalar<TMember>(
  TokenAt At,
  string Name,
  string Description,
  ScalarDomain Domain
) : AstScalar(At, Name, Description, Domain), IEquatable<AstScalar<TMember>>
  where TMember : IAstScalarItem
{
  public TMember[] Items { get; set; } = [];

  internal override string Abbr => "S";
  public override string Label => "Scalar";

  public AstScalar(TokenAt at, string name, ScalarDomain domain, TMember[] members)
    : this(at, name, "", domain)
    => Items = members;

  public virtual bool Equals(AstScalar<TMember>? other)
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

public abstract record class AstScalar(
  TokenAt At,
  string Name,
  string Description,
  ScalarDomain Domain
) : AstSimple(At, Name, Description)
{ }

[SuppressMessage("Naming", "CA1720:Identifier contains type name")]
public enum ScalarDomain
{
  Boolean,
  Enum,
  Number,
  String,
}
