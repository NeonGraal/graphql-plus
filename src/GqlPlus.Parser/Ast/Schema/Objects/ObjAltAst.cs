using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Ast.Schema.Objects;

internal record class ObjAltAst(
  ITokenAt At,
  string Name,
  string Description
) : ObjBaseAst(At, Name, Description)
  , IGqlpObjAlt
{
  internal override string Abbr => "OA";
  public IGqlpModifier[] Modifiers { get; set; } = [];

  public IGqlpEnumValue? EnumValue { get; set; }

  public string ModifiedType => GetFields().Skip(2).Joined();

  IEnumerable<IGqlpModifier> IGqlpModifiers.Modifiers => Modifiers;

  void IGqlpObjectEnum.SetEnumType(string enumType)
  {
    if (EnumValue == null) {
      EnumValue = new EnumValueAst(At, enumType, Name);
    } else {
      EnumValue = new EnumValueAst(EnumValue.At, enumType, EnumValue.EnumLabel ?? Name);
    }

    Name = enumType;
  }

  public virtual bool Equals(ObjAltAst? other)
    => other is IGqlpObjAlt alternate && Equals(alternate);
  public bool Equals(IGqlpObjAlt? other)
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
