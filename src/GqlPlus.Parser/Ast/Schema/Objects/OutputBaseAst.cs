using GqlPlus.Abstractions.Schema;
using GqlPlus.Token;

namespace GqlPlus.Ast.Schema.Objects;

internal sealed record class OutputBaseAst(
  ITokenAt At,
  string Name,
  string Description
) : AstObjBase(At, Name, Description)
  , IGqlpOutputBase
{
  public OutputBaseAst(TokenAt at, string name)
    : this(at, name, "") { }

  internal override string Abbr => "OR";
  public override string Label => "Output";

  public DualBaseAst ToDual()
    => new(At, Name, Description) {
      IsTypeParam = IsTypeParam,
      Args = [.. Args.Select(a => new DualArgAst(a.At, a.Name, a.Description) { IsTypeParam = a.IsTypeParam })],
    };

  IGqlpDualBase IGqlpToDual<IGqlpDualBase>.ToDual => ToDual();
}
