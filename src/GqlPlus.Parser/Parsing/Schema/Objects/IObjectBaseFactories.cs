using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Objects;
using GqlPlus.Token;

namespace GqlPlus.Parsing.Schema.Objects;

internal interface IObjectBaseFactories<TObjBase, TObjBaseAst, TObjArg, TObjArgAst>
  : IObjectArgumentFactories<TObjArg, TObjArgAst>
  where TObjBase : IGqlpObjBase
  where TObjBaseAst : AstObjBase<TObjArg>
  where TObjArg : IGqlpObjArgument
  where TObjArgAst : AstObjArgument, TObjArg
{
  TObjBaseAst ObjBase(TokenAt at, string name, string description = "");
}
