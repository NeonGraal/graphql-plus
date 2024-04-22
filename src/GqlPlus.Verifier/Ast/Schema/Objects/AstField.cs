using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Ast.Schema.Objects;

public abstract record class AstField<TRef>(TokenAt At, string Name, string Description, TRef Type)
  : AstAliased(At, Name, Description), IEquatable<AstField<TRef>>, IAstModified
  where TRef : AstReference<TRef>, IEquatable<TRef>
{
  public TRef Type { get; set; } = Type;
  public ModifierAst[] Modifiers { get; set; } = [];

  public string ModifiedType => Type.GetFields().Skip(1).Concat(Modifiers.AsString()).Joined();

  public virtual bool Equals(AstField<TRef>? other)
    => base.Equals(other)
    && (Type?.Equals(other.Type) ?? other.Type is null)
    && Modifiers.SequenceEqual(other.Modifiers);
  public override int GetHashCode()
    => HashCode.Combine(base.GetHashCode(), Type, Modifiers.Length);
}
