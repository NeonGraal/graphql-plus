using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Objects;
using GqlPlus.Token;

namespace GqlPlus.Parsing.Schema.Objects;

internal interface IObjectAlternateFactories
  : IObjectBaseFactories
{
  ObjAlternateAst ObjAlternate(TokenAt at, string name, string description);
}
