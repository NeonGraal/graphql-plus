using GqlPlus.Abstractions.Schema;
using GqlPlus.Token;

namespace GqlPlus.Ast.Schema.Objects;

internal sealed record class OutputBaseAst(
  TokenAt At,
  string Name,
  string Description
) : AstObjBase<IGqlpOutputArg>(At, Name, Description)
  , IGqlpOutputBase
{
  public OutputBaseAst(TokenAt at, string name)
    : this(at, name, "") { }

  public string? EnumLabel { get; set; }

  internal override string Abbr => "OR";
  public override string Label => "Output";

  internal override IEnumerable<string?> GetFields()
    => string.IsNullOrWhiteSpace(EnumLabel)
    ? base.GetFields()
    : [At.ToString(), $"{Name}.{EnumLabel}"];

  public DualBaseAst ToDual()
    => new(At, Name, Description) {
      IsTypeParam = IsTypeParam,
      BaseArgs = [.. BaseArgs.Select(a => a.ToDual)],
    };

  IGqlpDualBase IGqlpToDual<IGqlpDualBase>.ToDual => ToDual();

  string IGqlpOutputBase.Output => Name;

  string IGqlpOutputEnum.EnumType => TypeName;
  void IGqlpOutputEnum.SetEnumType(string enumType)
  {
    EnumLabel ??= Name;
    Name = enumType;
  }
}
