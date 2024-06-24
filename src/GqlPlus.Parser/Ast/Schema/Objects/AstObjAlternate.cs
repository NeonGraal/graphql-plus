using GqlPlus.Abstractions.Schema;
using GqlPlus.Token;

namespace GqlPlus.Ast.Schema.Objects;

internal abstract record class AstObjAlternate<TObjBase>(
  TokenAt At,
  TObjBase BaseType
) : AstAbbreviated(At)
  , IEquatable<AstObjAlternate<TObjBase>>
  , IGqlpObjAlternate
  where TObjBase : IGqlpObjBase
{
  public ModifierAst[] Modifiers { get; set; } = [];

  public string ModifiedType => BaseType.GetFields().Skip(1).Concat(Modifiers.AsString()).Joined();
  public string Description => BaseType.Description;

  IEnumerable<IGqlpModifier> IGqlpModifiers.Modifiers => Modifiers;
  IGqlpObjBase IGqlpObjAlternate.Type => BaseType;

  internal AstObjAlternate(TObjBase objBase)
    : this((TokenAt)objBase.At, objBase) { }

  public virtual bool Equals(AstObjAlternate<TObjBase>? other)
    => base.Equals(other)
    && (BaseType?.Equals(other.BaseType) ?? other.BaseType is null)
    && Modifiers.SequenceEqual(other.Modifiers);
  public override int GetHashCode()
    => HashCode.Combine(base.GetHashCode(), BaseType, Modifiers.Length);

  internal override IEnumerable<string?> GetFields()
    => base.GetFields()
      .Concat(BaseType.GetFields())
      .Concat(Modifiers.AsString());
}
