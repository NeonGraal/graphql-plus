using GqlPlus.Abstractions.Operation;
using GqlPlus.Token;

namespace GqlPlus.Ast.Operation;

internal sealed record class SpreadAst(
  TokenAt At,
  string Identifier
) : AstDirectives(At, Identifier)
  , IGqlpSpread
{
  internal override string Abbr => "s";
}
