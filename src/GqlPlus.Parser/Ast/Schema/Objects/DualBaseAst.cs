using GqlPlus.Abstractions.Schema;
using GqlPlus.Token;

namespace GqlPlus.Ast.Schema.Objects;

internal sealed record class DualBaseAst(
  TokenAt At,
  string Name,
  string Description
) : AstObjBase<IGqlpDualArgument>(At, Name, Description)
  , IGqlpDualBase
{
  public DualBaseAst(TokenAt at, string name)
    : this(at, name, "") { }

  internal override string Abbr => "DB";
  public override string Label => "Dual";

  string IGqlpDualBase.Dual => Name;
}
