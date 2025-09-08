using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Objects;
using GqlPlus.Token;

namespace GqlPlus.Parsing.Schema.Objects;

internal class ParseInputArgs
  : ObjectArgumentsParser<IGqlpInputArg, InputArgAst>
{
  protected override InputArgAst ObjArgument(TokenAt at, string type, string description)
    => new(at, type, description);
}
