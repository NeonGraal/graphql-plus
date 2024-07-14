﻿using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Objects;
using GqlPlus.Token;

namespace GqlPlus.Parsing.Schema.Objects;

internal class ParseInputArgs
  : ObjectArgsParser<IGqlpInputArg, InputArgAst>
{
  protected override InputArgAst ObjType(TokenAt at, string type, string description)
    => new(at, type, description);
}
