using GqlPlus.Abstractions.Operation;

namespace GqlPlus.Ast.Operation;

internal sealed record class SpreadAst(
  ITokenAt At,
  string Identifier
) : AstDirectives(At, Identifier)
  , IAstSpread
{
  internal override string Abbr => "s";
}
