using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Objects;
using GqlPlus.Token;

namespace GqlPlus.Parsing.Schema.Objects;

internal interface IObjectArgumentFactories<TObjArg, TObjArgAst>
  where TObjArg : IGqlpObjArgument
  where TObjArgAst : AstObjArgument, TObjArg
{
  TObjArgAst ObjArgument(TokenAt at, string name, string description = "");
}
