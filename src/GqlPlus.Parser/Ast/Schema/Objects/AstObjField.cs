﻿using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Ast.Schema.Objects;

internal abstract record class AstObjField<TObjBase>(
  ITokenAt At,
  string Name,
  string Description,
  TObjBase BaseType
) : AstAliased(At, Name, Description)
  , IGqlpObjField<TObjBase>
  where TObjBase : IGqlpObjBase
{
  public TObjBase BaseType { get; set; } = BaseType;
  public IGqlpModifier[] Modifiers { get; set; } = [];

  public string ModifiedType => BaseType.GetFields().Skip(2).Concat(Modifiers.AsString()).Joined();

  IEnumerable<IGqlpModifier> IGqlpModifiers.Modifiers => Modifiers;
  IGqlpObjBase IGqlpObjField.Type => BaseType;

  public virtual bool Equals(AstObjField<TObjBase>? other)
    => other is IGqlpObjField<TObjBase> field && Equals(field);
  public bool Equals(IGqlpObjField<TObjBase>? other)
    => base.Equals(other)
    && BaseType.Equals(other!.BaseType)
    && Modifiers.SequenceEqual(other.Modifiers);
  public override int GetHashCode()
    => HashCode.Combine(base.GetHashCode(), BaseType, Modifiers.Length);
}
