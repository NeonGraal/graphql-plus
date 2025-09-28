using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast;

namespace GqlPlus.Ast.Schema.Objects;

public record class ObjTypeArgAst(
  ITokenAt At,
  string Name,
  string Description
) : AstObjType(At, Name, Description)
  , IGqlpObjTypeArg
{
  internal override string Abbr => "OR";

  public IGqlpEnumValue? EnumValue { get; set; }

  public IGqlpObjType EnumType => this;
  string? IGqlpObjectEnum.EnumLabel => EnumValue?.EnumLabel;

  void IGqlpObjectEnum.SetEnumType(string enumType)
  {
    if (EnumValue == null) {
      EnumValue = new EnumValueAst(At, enumType, Name);
    } else {
      EnumValue = new EnumValueAst(At, enumType, EnumValue.EnumLabel ?? Name);
    }
    Name = enumType;
  }

  internal override IEnumerable<string?> GetFields()
    => string.IsNullOrWhiteSpace(EnumValue?.EnumLabel)
    ? base.GetFields()
    : [At.ToString(), $"{Name}.{EnumValue?.EnumLabel}"];

  bool IEquatable<IGqlpObjTypeArg>.Equals(IGqlpObjTypeArg? other)
    => Equals(other as AstObjType);
}
