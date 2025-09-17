using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Objects;
using GqlPlus.Token;

namespace GqlPlus.Parsing.Schema.Objects;

internal interface IObjectBaseFactories<TObjBase, TObjBaseAst, TObjArgAst>
  : IObjectArgFactories<IGqlpObjArg, TObjArgAst>
  where TObjBase : IGqlpObjBase
  where TObjBaseAst : AstObjBase
  where TObjArgAst : AstObjArg
{
  TObjBaseAst ObjBase(TokenAt at, string name, string description = "");
}
