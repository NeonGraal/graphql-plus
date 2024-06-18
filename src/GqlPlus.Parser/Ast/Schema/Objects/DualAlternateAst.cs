using GqlPlus.Abstractions.Schema;
using GqlPlus.Token;

namespace GqlPlus.Ast.Schema.Objects;

public sealed record class DualAlternateAst(
  TokenAt At,
  IGqlpDualBase Type
) : AstObjAlternate<IGqlpDualBase>(At, Type)
  , IEquatable<DualAlternateAst>
  , IGqlpDualAlternate
{
  internal override string Abbr => "DA";
}
