using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Objects;
using GqlPlus.Token;

namespace GqlPlus.Parsing.Schema.Objects;

internal interface IObjectAlternateFactories<TObjAltAst, TObjBase, TObjBaseAst>
  : IObjectBaseFactories<TObjBase, TObjBaseAst>
  where TObjAltAst : AstObjAlternate<TObjBase>, IGqlpObjAlternate<TObjBase>
  where TObjBase : IGqlpObjBase<TObjBase>, IEquatable<TObjBase>
  where TObjBaseAst : AstObjBase<TObjBase>, TObjBase
{
  TObjAltAst ObjAlternate(TokenAt at, TObjBase typeBase);
}
