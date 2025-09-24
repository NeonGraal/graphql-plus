using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Ast.Schema.Objects;

public record class ObjTypeArgAst(
  ITokenAt At,
  string Name,
  string Description
) : AstObjType(At, Name, Description)
  , IGqlpObjTypeArg
{
  internal override string Abbr => "OR";

  public string? EnumLabel { get; set; }

  public IGqlpObjType EnumType => this;

  void IGqlpObjectEnum.SetEnumType(string enumType)
  {
    EnumLabel ??= Name;
    Name = enumType;
  }

  internal override IEnumerable<string?> GetFields()
    => string.IsNullOrWhiteSpace(EnumLabel)
    ? base.GetFields()
    : [At.ToString(), $"{Name}.{EnumLabel}"];

  bool IEquatable<IGqlpObjTypeArg>.Equals(IGqlpObjTypeArg? other)
    => Equals(other as AstObjType);
}
