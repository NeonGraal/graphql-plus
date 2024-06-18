using GqlPlus.Abstractions.Schema;
using GqlPlus.Token;

namespace GqlPlus.Ast.Schema.Objects;

public sealed record class InputAlternateAst(
  TokenAt At,
  IGqlpInputBase Type
) : AstObjAlternate<IGqlpInputBase>(At, Type)
  , IEquatable<InputAlternateAst>
  , IGqlpInputAlternate
{
  internal override string Abbr => "IA";
}
