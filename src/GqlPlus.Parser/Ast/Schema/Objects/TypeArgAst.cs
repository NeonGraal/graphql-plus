using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Ast.Schema.Objects;

public sealed record class TypeArgAst(
  ITokenAt At,
  string Name,
  string Description
) : AstObjType(At, Name, Description)
  , IGqlpTypeArg
{
  internal override string Abbr => "OR";

  public IGqlpEnumValue? EnumValue { get; set; }

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

  internal override IEnumerable<string?> GetFields()
    => EnumValue is null
    ? base.GetFields()
    : DescriptionAt.Append(EnumValue.EnumValue);

  bool IEquatable<IGqlpTypeArg>.Equals(IGqlpTypeArg? other)
    => Equals(other as AstObjType);
  public bool Equals(TypeArgAst? other)
    => base.Equals(other)
    && EnumValue.NullEqual(other.EnumValue);
  public override int GetHashCode()
    => HashCode.Combine(base.GetHashCode(), EnumValue?.GetHashCode() ?? 0);
}
