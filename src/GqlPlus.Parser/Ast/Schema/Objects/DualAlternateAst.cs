using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Ast.Schema.Objects;

internal sealed record class DualAlternateAst(
  ITokenAt At,
  string Dual,
  string Description
) : AstObjAlternate<IGqlpDualArg>(At, Dual, Description)
  , IGqlpDualAlternate
{
  internal override string Abbr => "DA";
  public override string Label => "Dual";
}
