using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Objects;
using GqlPlus.Result;
using GqlPlus.Token;

namespace GqlPlus.Parsing.Schema.Objects;

internal class ParseOutputArgs
  : ObjectArgumentsParser<IGqlpObjArg, OutputArgAst>
{
  protected override OutputArgAst ObjArgument(TokenAt at, string type, string description)
    => new(at, type, description);
}
