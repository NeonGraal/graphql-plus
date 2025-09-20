using GqlPlus.Ast.Schema.Objects;
using GqlPlus.Parsing.Schema.Objects;
using GqlPlus.Token;

namespace GqlPlus.Schema.Objects;

internal sealed class ObjFactories
  : IObjectBaseFactories
{
  public ObjArgAst ObjArg(TokenAt at, string name, string description = "") => new(at, name, description);
  public ObjBaseAst ObjBase(TokenAt at, string name, string description = "") => new(at, name, description);
}
