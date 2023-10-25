namespace GqlPlus.Verifier.Ast.Schema;

internal abstract record class AstField(ParseAt At, string Name, string Description)
  : AstAliased(At, Name, Description), IEquatable<AstField>
{
  public ModifierAst[] Modifiers { get; set; } = Array.Empty<ModifierAst>();

  public virtual bool Equals(AstField? other)
    => base.Equals(other)
    && Modifiers.SequenceEqual(other.Modifiers);
  public override int GetHashCode()
    => HashCode.Combine(base.GetHashCode(), Modifiers.Length);
}
