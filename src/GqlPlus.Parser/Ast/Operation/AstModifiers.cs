namespace GqlPlus.Ast.Operation;

internal abstract record class AstModifiers(
  ITokenAt At,
  string Identifier
) : AstDirectives(At, Identifier)
  , IAstModifiers
{
  public IAstModifier[] Modifiers { get; set; } = [];
  IEnumerable<IAstModifier> IAstModifiers.Modifiers => Modifiers;

  public virtual bool Equals(AstModifiers? other)
    => other is IAstModifiers modifiers && Equals(modifiers);
  public bool Equals(IAstModifiers? other)
    => Equals(other as IAstDirectives)
    && other is not null
    && Modifiers.SequenceEqual(other.Modifiers);
  public override int GetHashCode()
    => HashCode.Combine(base.GetHashCode(), Modifiers.Length);

  internal override IEnumerable<string?> GetFields()
    => base.GetFields()
    .Concat(Modifiers.AsString());
}
