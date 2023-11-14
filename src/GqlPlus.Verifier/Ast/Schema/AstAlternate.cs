namespace GqlPlus.Verifier.Ast.Schema;

internal sealed record class AstAlternate<R>(ParseAt At, R Type)
  : AstBase(At), IEquatable<AstAlternate<R>>
  where R : AstReference<R>, IEquatable<R>
{
  public ModifierAst[] Modifiers { get; set; } = Array.Empty<ModifierAst>();

  internal override string Abbr => "A";

  internal AstAlternate(R @type)
    : this(type.At, type) { }

  public bool Equals(AstAlternate<R>? other)
    => base.Equals(other)
    && (Type?.Equals(other.Type) ?? other.Type is null)
    && Modifiers.SequenceEqual(other.Modifiers);
  public override int GetHashCode()
    => HashCode.Combine(base.GetHashCode(), Type, Modifiers.Length);

  internal override IEnumerable<string?> GetFields()
  => new[] { "!" + Abbr + Type.Abbr[..1] }
    .Concat(Type.GetFields())
    .Concat(Modifiers.AsString());
}
