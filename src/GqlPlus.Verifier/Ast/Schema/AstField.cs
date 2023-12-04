using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Ast.Schema;

public abstract record class AstField<R>(TokenAt At, string Name, string Description, R Type)
  : AstAliased(At, Name, Description), IEquatable<AstField<R>>
{
  public R Type { get; set; } = Type;
  public ModifierAst[] Modifiers { get; set; } = Array.Empty<ModifierAst>();

  public virtual bool Equals(AstField<R>? other)
    => base.Equals(other)
    && (Type?.Equals(other.Type) ?? other.Type is null)
    && Modifiers.SequenceEqual(other.Modifiers);
  public override int GetHashCode()
    => HashCode.Combine(base.GetHashCode(), Type, Modifiers.Length);
}
