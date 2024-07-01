using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Objects;
using GqlPlus.Token;

namespace GqlPlus.Parsing.Schema.Objects;

internal class ParseOutputArguments
  : ObjectArgumentsParser<IGqlpOutputArgument, OutputArgumentAst>
{
  protected override OutputArgumentAst ObjType(TokenAt at, string type, string description)
    => new(at, type, description);
}
