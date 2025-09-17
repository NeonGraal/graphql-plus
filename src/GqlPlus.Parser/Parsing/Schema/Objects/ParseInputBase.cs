using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Objects;
using GqlPlus.Token;

namespace GqlPlus.Parsing.Schema.Objects;

internal class ParseInputBase(
  Parser<IGqlpObjArg>.DA parseArgs
) : ObjectBaseParser<IGqlpInputBase, InputBaseAst>(parseArgs)
{
  protected override InputBaseAst ObjBase(TokenAt at, string param, string description)
    => new(at, param, description);
}
