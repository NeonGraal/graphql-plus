using GqlPlus.Abstractions.Schema;
using GqlPlus.Token;

namespace GqlPlus.Ast.Schema.Objects;

internal sealed record class OutputArgAst(
  ITokenAt At,
  string Name,
  string Description
) : AstObjArg(At, Name, Description)
  , IGqlpOutputArg
{
  public OutputArgAst(TokenAt at, string name)
    : this(at, name, "") { }

  public string? EnumLabel { get; set; }

  internal override string Abbr => "OR";
  public override string Label => "Output";

  internal override IEnumerable<string?> GetFields()
    => EnumLabel.IsWhiteSpace()
    ? base.GetFields()
    : [At.ToString(), $"{Name}.{EnumLabel}"];

  public DualArgAst ToDual()
    => new(At, Name, Description) {
      IsTypeParam = IsTypeParam,
    };

  IGqlpDualArg IGqlpToDual<IGqlpDualArg>.ToDual => ToDual();

  public IGqlpObjType EnumType => this;

  void IGqlpOutputEnum.SetEnumType(string enumType)
  {
    EnumLabel ??= Name;
    Name = enumType;
  }
}
