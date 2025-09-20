using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Objects;
using GqlPlus.Token;

namespace GqlPlus.Parsing.Schema.Objects;

[ExcludeFromCodeCoverage]
internal sealed class DualFactories
  : IObjectFactories<DualDeclAst, IGqlpDualField, DualFieldAst>
{
  public DualFieldAst ObjField(TokenAt at, string name, IGqlpObjBase typeBase, string description)
    => new(at, name, description, typeBase);

  public DualDeclAst Object(TokenAt at, string name, string description)
    => new(at, name, description);

  public ObjBaseAst ObjBase(TokenAt at, string name, string description)
    => new(at, name, description);

  public ObjAlternateAst ObjAlternate(TokenAt at, string name, string description)
    => new(at, name, description);

  public ObjArgAst ObjArg(TokenAt at, string name, string description = "")
    => new(at, name, description);
}
