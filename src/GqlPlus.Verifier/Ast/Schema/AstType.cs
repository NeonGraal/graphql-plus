using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Ast.Schema;

public abstract record class AstType(
  TokenAt At,
  string Name,
  string Description
) : AstDeclaration(At, Name, Description), IAstType
{
  public abstract string Label { get; }
}

public interface IAstType
{
  string Name { get; }
  string Label { get; }
}

public abstract record class AstType<TParent>(
  TokenAt At,
  string Name,
  string Description
) : AstType(At, Name, Description), IEquatable<AstType<TParent>>
  where TParent : IEquatable<TParent>
{
  public TParent? Parent { get; set; }

  public virtual bool Equals(AstType<TParent>? other)
    => base.Equals(other)
      && Parent.NullEqual(other.Parent);
  public override int GetHashCode()
    => HashCode.Combine(base.GetHashCode(), Parent);
}

public interface IAstType<TParent> : IAstType
{
  TParent? Parent { get; }
}
