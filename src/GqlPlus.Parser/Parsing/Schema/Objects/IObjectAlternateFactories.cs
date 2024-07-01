﻿using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Objects;
using GqlPlus.Token;

namespace GqlPlus.Parsing.Schema.Objects;

internal interface IObjectAlternateFactories<TObjAltAst, TObjBase, TObjBaseAst, TObjArg, TObjArgAst>
  : IObjectBaseFactories<TObjBase, TObjBaseAst, TObjArg, TObjArgAst>
  where TObjAltAst : AstObjAlternate<TObjBase>, IGqlpObjAlternate
  where TObjBase : IGqlpObjBase
  where TObjBaseAst : AstObjBase<TObjArg>, TObjBase
  where TObjArg : IGqlpObjArgument
  where TObjArgAst : AstObjArgument, TObjArg
{
  TObjAltAst ObjAlternate(TokenAt at, TObjBase typeBase);
}
