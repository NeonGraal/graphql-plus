namespace GqlPlus.Ast.Schema.Objects;

internal abstract record class AstObjField(
  ITokenAt At,
  string Name,
  string Description,
  IAstObjBase Type
) : AstAliased(At, Name, Description)
  , IAstObjField
{
  public IAstObjBase Type { get; set; } = Type;
  public IAstModifier[] Modifiers { get; set; } = [];
  public IAstEnumValue? EnumValue { get; set; }

  string IAstObjEnum.EnumTypeName => Type.Name;
  void IAstObjEnum.SetEnumType(string enumType)
  {
    string enumLabel = EnumValue?.EnumLabel ?? Type.Name;
    Type.SetName(enumType);
    EnumValue = new EnumValueAst(At, enumType, enumLabel);
  }

  IEnumerable<IAstModifier> IAstModifiers.Modifiers => Modifiers;

  protected internal IEnumerable<string?> TypeFields(string suffix = "")
    => string.IsNullOrWhiteSpace(EnumValue?.EnumLabel)
        ? [":", .. Type.GetFields(), .. Modifiers.AsString(), suffix]
        : ["=", .. Type.GetFields(), "." + EnumValue?.EnumLabel];

  public string ModifiedType => Type.GetFields().Skip(2).Concat(Modifiers.AsString()).Joined();

  public virtual bool Equals(AstObjField? other)
    => other is IAstObjField field && Equals(field);
  public bool Equals(IAstObjField? other)
    => base.Equals(other)
    && Type.Equals(other.Type)
    && Modifiers.SequenceEqual(other.Modifiers)
    && EnumValue.NullEqual(other.EnumValue);
  public override int GetHashCode()
    => HashCode.Combine(base.GetHashCode(), Type.NullHashCode(), Modifiers.Length, EnumValue.NullHashCode());
}
