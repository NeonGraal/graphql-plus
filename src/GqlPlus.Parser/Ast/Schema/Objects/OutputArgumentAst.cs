using GqlPlus.Abstractions.Schema;
using GqlPlus.Token;

namespace GqlPlus.Ast.Schema.Objects;

internal sealed record class OutputArgAst(
  TokenAt At,
  string Name,
  string Description
) : AstObjArg(At, Name, Description)
  , IGqlpOutputArg
{
  public OutputArgAst(TokenAt at, string name)
    : this(at, name, "") { }

  public string? EnumMember { get; set; }

  internal override string Abbr => "OR";
  public override string Label => "Output";

  internal override IEnumerable<string?> GetFields()
    => string.IsNullOrWhiteSpace(EnumMember)
    ? base.GetFields()
    : [At.ToString(), $"{Name}.{EnumMember}"];

  public DualArgAst ToDual()
    => new(At, Name, Description) {
      IsTypeParam = IsTypeParam,
    };

  IGqlpDualArg IGqlpToDual<IGqlpDualArg>.ToDual => ToDual();

  string IGqlpOutputArg.Output => Name;

  string IGqlpOutputEnum.EnumType => TypeName;
  void IGqlpOutputEnum.SetEnumType(string enumType)
  {
    EnumMember ??= Name;
    Name = enumType;
  }
}
