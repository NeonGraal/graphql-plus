namespace GqlPlus.Verifier.Ast.Schema;

internal abstract record class AstField<R>(ParseAt At, string Name, string Description, R Type)
  : AstAliased(At, Name, Description), IEquatable<AstField<R>>
{
  public ModifierAst[] Modifiers { get; set; } = Array.Empty<ModifierAst>();

  public virtual bool Equals(AstField<R>? other)
    => base.Equals(other)
    && (Type?.Equals(other.Type) ?? other.Type is null)
    && Modifiers.SequenceEqual(other.Modifiers);
  public override int GetHashCode()
    => HashCode.Combine(base.GetHashCode(), Type, Modifiers.Length);
}
