using GqlPlus.Abstractions.Schema;
using GqlPlus.Token;

namespace GqlPlus.Ast.Schema.Objects;

internal sealed record class OutputArgumentAst(
  TokenAt At,
  string Name,
  string Description
) : AstObjArgument(At, Name, Description)
  , IGqlpOutputArgument
{
  public OutputArgumentAst(TokenAt at, string name)
    : this(at, name, "") { }

  public string? EnumMember { get; set; }

  internal override string Abbr => "OR";
  public override string Label => "Output";

  IGqlpDualArgument IGqlpToDual<IGqlpDualArgument>.ToDual => ToDual();

  string IGqlpOutputArgument.Output => Name;

  internal override IEnumerable<string?> GetFields()
    => string.IsNullOrWhiteSpace(EnumMember)
    ? base.GetFields()
    : [At.ToString(), $"{Name}.{EnumMember}"];

  public DualArgumentAst ToDual()
    => new(At, Name, Description) {
      IsTypeParameter = IsTypeParameter,
    };

  void IGqlpOutputEnum.SetEnumType(string enumType)
  {
    EnumMember ??= Name;
    Name = enumType;
  }
}
