using GqlPlus.Verifier.Ast.Schema.Objects;
using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Parse.Schema.Objects;

internal sealed class DualFactories
  : IObjectFactories<DualDeclAst, DualFieldAst, DualBaseAst>
{
  public DualFieldAst ObjField(TokenAt at, string name, DualBaseAst typeBase, string description)
    => new(at, name, description, typeBase);

  public DualDeclAst Object(TokenAt at, string name, string description)
    => new(at, name, description);

  public DualBaseAst ObjBase(TokenAt at, string name, string description)
    => new(at, name, description);
}
