using GqlPlus.Abstractions.Schema;
using GqlPlus.Token;

namespace GqlPlus.Ast.Schema.Objects;

public sealed record class OutputAlternateAst(
  TokenAt At,
  IGqlpOutputBase Type
) : AstObjAlternate<IGqlpOutputBase>(At, Type)
  , IEquatable<OutputAlternateAst>
  , IGqlpOutputAlternate
{
  internal override string Abbr => "OA";
}
