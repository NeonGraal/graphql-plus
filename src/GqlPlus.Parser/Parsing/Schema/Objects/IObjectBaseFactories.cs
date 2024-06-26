using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Objects;
using GqlPlus.Token;

namespace GqlPlus.Parsing.Schema.Objects;

internal interface IObjectBaseFactories<TObjBase, TObjBaseAst>
  where TObjBase : IGqlpObjBase
  where TObjBaseAst : AstObjBase<TObjBase>
{
  TObjBaseAst ObjBase(TokenAt at, string name, string description = "");
}
