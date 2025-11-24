using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Ast.Schema.Objects;

internal record class AlternateAst(
  ITokenAt At,
  string Name,
  string Description
) : ObjBaseAst(At, Name, Description)
  , IGqlpAlternate
{
  internal override string Abbr => "OA";
  public IGqlpModifier[] Modifiers { get; set; } = [];

  public IGqlpEnumValue? EnumValue { get; set; }

  IEnumerable<IGqlpModifier> IGqlpModifiers.Modifiers => Modifiers;

  string IGqlpObjEnum.EnumTypeName => IsTypeParam ? "" : Name;
  void IGqlpObjEnum.SetEnumType(string enumType)
  {
    if (EnumValue == null) {
      EnumValue = new EnumValueAst(At, enumType, Name);
    } else {
      EnumValue = new EnumValueAst(EnumValue.At, enumType, EnumValue.EnumLabel ?? Name);
    }

    Name = enumType;
  }


  public virtual bool Equals(AlternateAst? other)
    => other is IGqlpAlternate alternate && Equals(alternate);
  public bool Equals(IGqlpAlternate? other)
    => base.Equals(other)
    && Modifiers.SequenceEqual(other.Modifiers)
    && EnumValue.NullEqual(other.EnumValue);
  public override int GetHashCode()
    => HashCode.Combine(base.GetHashCode(), Modifiers.Length, EnumValue);

  internal override IEnumerable<string?> GetFields()
    => EnumValue is null
    ? base.GetFields()
      .Concat(Modifiers.AsString())
    : DescriptionAt.Append(EnumValue.EnumValue);
}
