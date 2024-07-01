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

  string IGqlpOutputBase.Output => Name;
  IGqlpDualBase IGqlpToDual<IGqlpDualBase>.ToDual => ToDual();

  internal override IEnumerable<string?> GetFields()
    => string.IsNullOrWhiteSpace(EnumMember)
    ? base.GetFields()
    : [At.ToString(), $"{Name}.{EnumMember}"];

  public DualBaseAst ToDual()
    => new(At, Name, Description) {
      IsTypeParameter = IsTypeParameter,
      BaseArguments = [.. BaseArguments.Select(a => a.ToDual)],
    };
}
