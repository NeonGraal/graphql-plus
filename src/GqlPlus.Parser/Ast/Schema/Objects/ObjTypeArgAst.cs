using System.Linq;
using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast;

namespace GqlPlus.Ast.Schema.Objects;

public sealed record class ObjTypeArgAst(
  ITokenAt At,
  string Name,
  string Description
) : AstObjType(At, Name, Description)
  , IGqlpObjTypeArg
{
  internal override string Abbr => "OR";

  public IGqlpEnumValue? EnumValue { get; set; }

  void IGqlpObjectEnum.SetEnumType(string enumType)
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

  bool IEquatable<IGqlpObjTypeArg>.Equals(IGqlpObjTypeArg? other)
    => Equals(other as AstObjType);
  public bool Equals(ObjTypeArgAst? other)
    => base.Equals(other)
    && EnumValue.NullEqual(other.EnumValue);
  public override int GetHashCode()
    => HashCode.Combine(base.GetHashCode(), EnumValue?.GetHashCode() ?? 0);
}
