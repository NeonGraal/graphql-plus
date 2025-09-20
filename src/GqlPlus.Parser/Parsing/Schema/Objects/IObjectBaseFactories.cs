using GqlPlus.Ast.Schema.Objects;
using GqlPlus.Token;

namespace GqlPlus.Parsing.Schema.Objects;

internal interface IObjectBaseFactories
  : IObjectArgFactories
{
  ObjBaseAst ObjBase(TokenAt at, string name, string description = "");
}
