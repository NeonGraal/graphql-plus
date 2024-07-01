using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Objects;
using GqlPlus.Token;

namespace GqlPlus.Parsing.Schema.Objects;

internal class ParseInputArguments
  : ObjectArgumentsParser<IGqlpInputArgument, InputArgumentAst>
{
  protected override InputArgumentAst ObjType(TokenAt at, string type, string description)
    => new(at, type, description);
}
