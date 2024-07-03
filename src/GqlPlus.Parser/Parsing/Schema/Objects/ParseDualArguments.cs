using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Objects;
using GqlPlus.Token;

namespace GqlPlus.Parsing.Schema.Objects;

internal class ParseDualArguments
  : ObjectArgumentsParser<IGqlpDualArgument, DualArgumentAst>
{
  protected override DualArgumentAst ObjType(TokenAt at, string type, string description)
    => new(at, type, description);
}
