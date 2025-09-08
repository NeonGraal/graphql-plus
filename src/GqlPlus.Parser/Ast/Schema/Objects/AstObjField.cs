using GqlPlus.Abstractions.Schema;

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
  public string? EnumLabel { get; set; }

  IGqlpObjType IGqlpObjectEnum.EnumType => BaseType;
  void IGqlpObjectEnum.SetEnumType(string enumType)
  {
    EnumLabel ??= BaseType.Name;
    BaseType.Name = enumType;
  }

  internal protected IEnumerable<string?> TypeFields(string suffix = "")
    => string.IsNullOrWhiteSpace(EnumLabel)
        ? [":", .. BaseType.GetFields(), .. Modifiers.AsString(), suffix]
        : ["=", .. BaseType.GetFields(), "." + EnumLabel];

  public string ModifiedType => BaseType.GetFields().Skip(2).Concat(Modifiers.AsString()).Joined();

  IEnumerable<IGqlpModifier> IGqlpModifiers.Modifiers => Modifiers;
  IGqlpObjBase IGqlpObjField.Type => BaseType;

  public virtual bool Equals(AstObjField<TObjBase>? other)
    => other is IGqlpObjField<TObjBase> field && Equals(field);
  public bool Equals(IGqlpObjField<TObjBase>? other)
    => base.Equals(other)
    && BaseType.Equals(other!.BaseType)
    && Modifiers.SequenceEqual(other.Modifiers)
    && EnumLabel == other.EnumLabel;
  public override int GetHashCode()
    => HashCode.Combine(base.GetHashCode(), BaseType, Modifiers.Length, EnumLabel);
}
