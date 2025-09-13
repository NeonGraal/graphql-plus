using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Objects;
using GqlPlus.Token;

namespace GqlPlus.Parsing.Schema.Objects;

internal class ParseDualBase(
  Parser<IGqlpObjArg>.DA parseArgs
) : ObjectBaseParser<IGqlpDualBase, DualBaseAst, IGqlpObjArg>(parseArgs)
{
  protected override DualBaseAst ObjBase(TokenAt at, string param, string description)
    => new(at, param, description);
}
