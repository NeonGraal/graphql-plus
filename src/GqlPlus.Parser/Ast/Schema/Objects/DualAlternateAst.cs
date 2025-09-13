using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Ast.Schema.Objects;

internal sealed record class DualAlternateAst(
  ITokenAt At,
  string Name,
  string Description
) : AstObjAlternate<IGqlpObjArg>(At, Name, Description)
  , IGqlpDualAlternate
{
  internal override string Abbr => "DA";
  public override string Label => "Dual";
}
