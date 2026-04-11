using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Ast.Schema.Objects;

internal record class AlternateAst(
  ITokenAt At,
  string Name,
  string Description
) : ObjBaseAst(At, Name, Description)
  , IAstAlternate
{
  internal override string Abbr => "OA";
  public IAstModifier[] Modifiers { get; set; } = [];

  public IAstEnumValue? EnumValue { get; set; }

  IEnumerable<IAstModifier> IAstModifiers.Modifiers => Modifiers;

  string IAstObjEnum.EnumTypeName => IsTypeParam ? "" : Name;
  void IAstObjEnum.SetEnumType(string enumType)
  {
    if (EnumValue == null) {
      EnumValue = new EnumValueAst(At, enumType, Name);
    } else {
      EnumValue = new EnumValueAst(EnumValue.At, enumType, EnumValue.EnumLabel ?? Name);
    }

    Name = enumType;
  }

  public virtual bool Equals(AlternateAst? other)
    => other is IAstAlternate alternate && Equals(alternate);
  public bool Equals(IAstAlternate? other)
    => base.Equals(other)
    && Modifiers.SequenceEqual(other.Modifiers)
    && EnumValue.NullEqual(other.EnumValue);
  public override int GetHashCode()
    => HashCode.Combine(base.GetHashCode(), Modifiers.Length, EnumValue.NullHashCode());

  internal override IEnumerable<string?> GetFields()
    => EnumValue is null
    ? base.GetFields()
      .Concat(Modifiers.AsString())
    : DescriptionAt.Append(EnumValue.EnumValue);
}
