using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Ast.Schema;

public abstract record class AstField<R>(TokenAt At, string Name, string Description, R Type)
  : AstAliased(At, Name, Description), IEquatable<AstField<R>>
  where R : AstReference<R>, IEquatable<R>
{
  public R Type { get; set; } = Type;
  public ModifierAst[] Modifiers { get; set; } = [];

  public string ModifiedType => Type.GetFields().Skip(1).Concat(Modifiers.AsString()).Joined();

  public virtual bool Equals(AstField<R>? other)
    => base.Equals(other)
    && (Type?.Equals(other.Type) ?? other.Type is null)
    && Modifiers.SequenceEqual(other.Modifiers);
  public override int GetHashCode()
    => HashCode.Combine(base.GetHashCode(), Type, Modifiers.Length);
}
