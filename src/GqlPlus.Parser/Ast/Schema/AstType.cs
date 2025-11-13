using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Ast.Schema;

internal abstract record class AstType(
  ITokenAt At,
  string Name,
  string Description
) : AstDeclaration(At, Name, Description)
  , IGqlpType
{
  protected string? _abbr;
  protected string? _label;

  public abstract TypeKind Kind { get; }

  internal override string Abbr => _abbr ??= Label[..2];
  public override string Label => _label ??= Kind.ToString();
}

internal abstract record class AstType<TParent>(
  ITokenAt At,
  string Name,
  string Description
) : AstType(At, Name, Description)
  , IGqlpType<TParent>
  where TParent : IGqlpDescribed, IEquatable<TParent>
{
  public TParent? Parent { get; set; }

  public virtual bool Equals(IGqlpType<TParent>? other)
    => base.Equals(other)
      && Parent.NullEqual(other.Parent);
  public override int GetHashCode()
    => HashCode.Combine(base.GetHashCode(), Parent);
}
