using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Ast.Schema;

public record class AstScalar<TMember>(
  TokenAt At,
  string Name,
  string Description,
  ScalarKind Kind
) : AstScalar(At, Name, Description, Kind), IEquatable<AstScalar<TMember>>
  where TMember : IAstScalarItem
{
  public TMember[] Items { get; set; } = [];

  internal override string Abbr => "S";
  public override string Label => "Scalar";

  public AstScalar(TokenAt at, string name, ScalarKind kind, TMember[] members)
    : this(at, name, "", kind)
    => Items = members;

  public virtual bool Equals(AstScalar<TMember>? other)
    => base.Equals(other)
      && Kind == other.Kind
      && Items.SequenceEqual(other.Items);
  public override int GetHashCode()
    => HashCode.Combine(base.GetHashCode(), Kind, Items.Length);
  internal override IEnumerable<string?> GetFields()
    => base.GetFields()
      .Append(Kind.ToString())
      .Append(Parent.Prefixed(":"))
      .Concat(Items.Bracket());
}

public abstract record class AstScalar(
  TokenAt At,
  string Name,
  string Description,
  ScalarKind Kind
) : AstType<string>(At, Name, Description)
{
}

public enum ScalarKind
{
  Boolean,
  Enum,
  Number,
  String,
  Union,
}
