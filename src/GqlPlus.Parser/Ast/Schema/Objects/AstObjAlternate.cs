using GqlPlus.Abstractions.Schema;
using GqlPlus.Token;

namespace GqlPlus.Ast.Schema.Objects;

public abstract record class AstObjAlternate<TObjBase>(
  TokenAt At,
  TObjBase Type
) : AstAbbreviated(At)
  , IEquatable<AstObjAlternate<TObjBase>>
  , IGqlpObjAlternate<TObjBase>
  where TObjBase : IGqlpObjBase<TObjBase>
{
  public ModifierAst[] Modifiers { get; set; } = [];

  public string Description => Type.Description;

  IEnumerable<IGqlpModifier> IGqlpModifiers.Modifiers => Modifiers;

  internal AstObjAlternate(TObjBase objBase)
    : this((TokenAt)objBase.At, objBase) { }

  public virtual bool Equals(AstObjAlternate<TObjBase>? other)
    => base.Equals(other)
    && (Type?.Equals(other.Type) ?? other.Type is null)
    && Modifiers.SequenceEqual(other.Modifiers);
  public override int GetHashCode()
    => HashCode.Combine(base.GetHashCode(), Type, Modifiers.Length);

  internal override IEnumerable<string?> GetFields()
    => base.GetFields()
      .Concat(Type.GetFields())
      .Concat(Modifiers.AsString());
}
