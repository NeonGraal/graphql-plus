﻿using GqlPlus.Ast.Schema.Objects;
using GqlPlus.Token;

namespace GqlPlus.Parsing.Schema.Objects;

public interface IObjectBaseFactories<TObjBase>
  where TObjBase : AstObjectBase<TObjBase>
{
  TObjBase ObjBase(TokenAt at, string name, string description = "");
}