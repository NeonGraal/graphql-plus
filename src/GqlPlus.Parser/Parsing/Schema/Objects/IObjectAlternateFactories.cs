using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Objects;
using GqlPlus.Token;

namespace GqlPlus.Parsing.Schema.Objects;

internal interface IObjectAlternateFactories<TObjAltAst, TObjBase, TObjBaseAst, TObjArgAst>
  : IObjectBaseFactories<TObjBase, TObjBaseAst, TObjArgAst>
  where TObjAltAst : AstObjAlternate, IGqlpObjAlternate
  where TObjBase : IGqlpObjBase
  where TObjBaseAst : AstObjBase, TObjBase
  where TObjArgAst : AstObjArg
{
  TObjAltAst ObjAlternate(TokenAt at, string name, string description);
}
