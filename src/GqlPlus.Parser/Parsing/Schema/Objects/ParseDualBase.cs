using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Objects;
using GqlPlus.Token;

namespace GqlPlus.Parsing.Schema.Objects;

internal class ParseDualBase(
  Parser<IGqlpObjArg>.DA parseArgs
) : ParseObjBase(parseArgs)
{ }
