using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Ast.Schema.Objects;

internal abstract record class AstObjField(
  ITokenAt At,
  string Name,
  string Description,
  IGqlpObjBase Type
) : AstAliased(At, Name, Description)
  , IGqlpObjField
{
  public IGqlpObjBase Type { get; set; } = Type;
  public IGqlpModifier[] Modifiers { get; set; } = [];
  public IGqlpEnumValue? EnumValue { get; set; }

  string IGqlpObjEnum.EnumTypeName => Type.Name;
  void IGqlpObjEnum.SetEnumType(string enumType)
  {
    string enumLabel = EnumValue?.EnumLabel ?? Type.Name;
    Type.SetName(enumType);
    EnumValue = new EnumValueAst(At, enumType, enumLabel);
  }

  IEnumerable<IGqlpModifier> IGqlpModifiers.Modifiers => Modifiers;

  protected internal IEnumerable<string?> TypeFields(string suffix = "")
    => string.IsNullOrWhiteSpace(EnumValue?.EnumLabel)
        ? [":", .. Type.GetFields(), .. Modifiers.AsString(), suffix]
        : ["=", .. Type.GetFields(), "." + EnumValue?.EnumLabel];

  public string ModifiedType => Type.GetFields().Skip(2).Concat(Modifiers.AsString()).Joined();

  public virtual bool Equals(AstObjField? other)
    => other is IGqlpObjField field && Equals(field);
  public bool Equals(IGqlpObjField? other)
    => base.Equals(other)
    && Type.Equals(other!.Type)
    && Modifiers.SequenceEqual(other.Modifiers)
    && EnumValue.NullEqual(other.EnumValue);
  public override int GetHashCode()
    => HashCode.Combine(base.GetHashCode(), Type.NullHashCode(), Modifiers.Length, EnumValue.NullHashCode());
}
