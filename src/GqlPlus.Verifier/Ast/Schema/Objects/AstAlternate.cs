using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Ast.Schema.Objects;

public record class AstAlternate<TRef>(TokenAt At, TRef Type)
  : AstAbbreviated(At), IEquatable<AstAlternate<TRef>>, IAstDescribed, IAstModified
  where TRef : AstReference<TRef>, IEquatable<TRef>
{
  public ModifierAst[] Modifiers { get; set; } = [];

  internal override string Abbr => "A";

  public string Description => Type.Description;

  internal AstAlternate(TRef @type)
    : this(type.At, type) { }

  public virtual bool Equals(AstAlternate<TRef>? other)
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
