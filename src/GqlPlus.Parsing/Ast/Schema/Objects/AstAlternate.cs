using GqlPlus.Token;

namespace GqlPlus.Ast.Schema.Objects;

public record class AstAlternate<TObjBase>(
  TokenAt At,
  TObjBase Type
) : AstAbbreviated(At), IEquatable<AstAlternate<TObjBase>>
  , IAstDescribed
  , IGqlpModifiers
  where TObjBase : AstObjectBase<TObjBase>, IEquatable<TObjBase>
{
  public ModifierAst[] Modifiers { get; set; } = [];

  internal override string Abbr => "A";

  public string Description => Type.Description;

  IEnumerable<IGqlpModifier> IGqlpModifiers.Modifiers => Modifiers;

  internal AstAlternate(TObjBase objBase)
    : this(objBase.At, objBase) { }

  public virtual bool Equals(AstAlternate<TObjBase>? other)
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
