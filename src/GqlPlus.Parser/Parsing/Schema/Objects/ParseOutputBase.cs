using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Objects;
using GqlPlus.Token;

namespace GqlPlus.Parsing.Schema.Objects;

internal class ParseOutputBase(
  Parser<IGqlpOutputArg>.DA parseArgs
) : ObjectBaseParser<IGqlpOutputBase, OutputBaseAst, IGqlpOutputArg>(parseArgs)
{
  protected override OutputBaseAst ObjBase(TokenAt at, string param, string description)
    => new(at, param, description);
}
