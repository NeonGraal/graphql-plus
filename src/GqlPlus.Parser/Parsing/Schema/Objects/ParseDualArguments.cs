﻿using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Objects;
using GqlPlus.Token;

namespace GqlPlus.Parsing.Schema.Objects;

internal class ParseDualArgs
  : ObjectArgumentsParser<IGqlpDualArg, DualArgAst>
{
  protected override DualArgAst ObjType(TokenAt at, string type, string description)
    => new(at, type, description);
}
