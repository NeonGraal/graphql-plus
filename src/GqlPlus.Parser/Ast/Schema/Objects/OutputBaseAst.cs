using GqlPlus.Abstractions.Schema;
using GqlPlus.Token;

namespace GqlPlus.Ast.Schema.Objects;

internal sealed record class OutputBaseAst(
  TokenAt At,
  string Name,
  string Description
) : AstObjBase<IGqlpOutputArgument>(At, Name, Description)
  , IGqlpOutputBase
{
  public OutputBaseAst(TokenAt at, string name)
    : this(at, name, "") { }

  public string? EnumMember { get; set; }

  internal override string Abbr => "OR";
  public override string Label => "Output";

  internal override IEnumerable<string?> GetFields()
    => string.IsNullOrWhiteSpace(EnumMember)
    ? base.GetFields()
    : [At.ToString(), $"{Name}.{EnumMember}"];

  public DualBaseAst ToDual()
    => new(At, Name, Description) {
      IsTypeParameter = IsTypeParameter,
      BaseArguments = [.. BaseArguments.Select(a => a.ToDual)],
    };

  IGqlpDualBase IGqlpToDual<IGqlpDualBase>.ToDual => ToDual();

  string IGqlpOutputBase.Output => Name;

  string IGqlpOutputEnum.EnumType => TypeName;
  void IGqlpOutputEnum.SetEnumType(string enumType)
  {
    EnumMember ??= Name;
    Name = enumType;
  }
}
