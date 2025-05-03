using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Ast.Schema;

internal abstract record class AstType(
  ITokenAt At,
  string Name,
  string Description
) : AstDeclaration(At, Name, Description)
  , IGqlpType
{ }

internal abstract record class AstType<TParent>(
  ITokenAt At,
  string Name,
  string Description
) : AstType(At, Name, Description)
  , IEquatable<AstType<TParent>>
  , IGqlpType<TParent>
  where TParent : IEquatable<TParent>
{
  public TParent? Parent { get; set; }

  public virtual bool Equals(AstType<TParent>? other)
    => base.Equals(other)
      && Parent.NullEqual(other.Parent);
  public override int GetHashCode()
    => HashCode.Combine(base.GetHashCode(), Parent);
}
