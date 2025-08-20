using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Objects;
using GqlPlus.Token;

namespace GqlPlus.Parsing.Schema.Objects;

internal class ParseDualBase(
  Parser<IGqlpDualArg>.DA parseArgs
) : ObjectBaseParser<IGqlpDualBase, DualBaseAst, IGqlpDualArg>(parseArgs)
{
  protected override DualBaseAst ObjBase(TokenAt at, string param, string description)
    => new(at, param, description);
}
