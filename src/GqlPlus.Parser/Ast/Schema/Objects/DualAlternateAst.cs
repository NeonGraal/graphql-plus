using GqlPlus.Abstractions.Schema;
using GqlPlus.Token;

namespace GqlPlus.Ast.Schema.Objects;

internal sealed record class DualAlternateAst(
  TokenAt At,
  string Name,
  string Description
) : AstObjAlternate<IGqlpDualArg>(At, Name, Description)
  , IEquatable<DualAlternateAst>
  , IGqlpDualAlternate
{
  internal override string Abbr => "DA";
  public override string Label => "Dual";
  public string Dual => Name;
}
