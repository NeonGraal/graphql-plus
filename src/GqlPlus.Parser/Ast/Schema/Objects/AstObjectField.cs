using GqlPlus.Abstractions.Schema;
using GqlPlus.Token;

namespace GqlPlus.Ast.Schema.Objects;

public abstract record class AstObjectField<TObjBase>(
  TokenAt At,
  string Name,
  string Description,
  TObjBase Type
) : AstAliased(At, Name, Description)
  , IEquatable<AstObjectField<TObjBase>>
  , IGqlpObjectField<TObjBase>
  where TObjBase : IGqlpObjectBase<TObjBase>, IEquatable<TObjBase>
{
  public TObjBase Type { get; set; } = Type;
  public ModifierAst[] Modifiers { get; set; } = [];

  public string ModifiedType => Type.GetFields().Skip(1).Concat(Modifiers.AsString()).Joined();

  IEnumerable<IGqlpModifier> IGqlpModifiers.Modifiers => Modifiers;

  public virtual bool Equals(AstObjectField<TObjBase>? other)
    => base.Equals(other)
    && (Type?.Equals(other.Type) ?? other.Type is null)
    && Modifiers.SequenceEqual(other.Modifiers);
  public override int GetHashCode()
    => HashCode.Combine(base.GetHashCode(), Type, Modifiers.Length);
}
