using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast;

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

  IGqlpObjType IGqlpObjectEnum.EnumType => Type;
  string? IGqlpObjectEnum.EnumLabel => EnumValue?.EnumLabel;
  void IGqlpObjectEnum.SetEnumType(string enumType)
  {
    if (EnumValue == null) {
      EnumValue = new EnumValueAst(At, enumType, Type.Name);
    } else {
      EnumValue = new EnumValueAst(At, enumType, EnumValue.EnumLabel ?? Type.Name);
    }
    Type.SetName(enumType);
  }

  protected internal IEnumerable<string?> TypeFields(string suffix = "")
    => string.IsNullOrWhiteSpace(EnumValue?.EnumLabel)
        ? [":", .. Type.GetFields(), .. Modifiers.AsString(), suffix]
        : ["=", .. Type.GetFields(), "." + EnumValue?.EnumLabel];

  public string ModifiedType => Type.GetFields().Skip(2).Concat(Modifiers.AsString()).Joined();

  IEnumerable<IGqlpModifier> IGqlpModifiers.Modifiers => Modifiers;

  public virtual bool Equals(AstObjField? other)
    => other is IGqlpObjField field && Equals(field);
  public bool Equals(IGqlpObjField? other)
    => base.Equals(other)
    && Type.Equals(other!.Type)
    && Modifiers.SequenceEqual(other.Modifiers)
    && EnumValue?.EnumLabel == other.EnumLabel;
  public override int GetHashCode()
    => HashCode.Combine(base.GetHashCode(), Type, Modifiers.Length, EnumValue?.EnumLabel);
}
