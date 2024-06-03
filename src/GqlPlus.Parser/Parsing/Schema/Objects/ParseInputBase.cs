﻿using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Objects;
using GqlPlus.Result;
using GqlPlus.Token;

namespace GqlPlus.Parsing.Schema.Objects;

internal class ParseInputBase
  : ObjectBaseParser<IGqlpInputBase, InputBaseAst>
{
  protected override InputBaseAst ObjBase(TokenAt at, string param, string description)
    => new(at, param, description);

  protected override IResult<InputBaseAst> TypeEnumValue<TContext>(TContext tokens, InputBaseAst objBase)
    => objBase.Ok();
}
