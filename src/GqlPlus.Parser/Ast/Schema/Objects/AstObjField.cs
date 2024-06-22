using GqlPlus.Abstractions.Schema;
using GqlPlus.Token;

namespace GqlPlus.Ast.Schema.Objects;

public abstract record class AstObjField<TObjBase>(
  TokenAt At,
  string Name,
  string Description,
  TObjBase BaseType
) : AstAliased(At, Name, Description)
  , IEquatable<AstObjField<TObjBase>>
  , IGqlpObjField<TObjBase>
  where TObjBase : IGqlpObjBase
{
  public TObjBase BaseType { get; set; } = BaseType;
  public ModifierAst[] Modifiers { get; set; } = [];

  public string ModifiedType => BaseType.GetFields().Skip(1).Concat(Modifiers.AsString()).Joined();

  IEnumerable<IGqlpModifier> IGqlpModifiers.Modifiers => Modifiers;
  IGqlpObjBase IGqlpObjField.Type => BaseType;

  public virtual bool Equals(AstObjField<TObjBase>? other) =>
    base.Equals(other)
    && BaseType.Equals(other!.BaseType)
    && Modifiers.SequenceEqual(other.Modifiers);
  public override int GetHashCode()
    => HashCode.Combine(base.GetHashCode(), BaseType, Modifiers.Length);
}
