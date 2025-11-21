using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Objects;
using GqlPlus.Token;

namespace GqlPlus.Parsing.Schema.Objects;

internal sealed class DualFactories
  : IObjectFactories<IGqlpDualField, DualFieldAst>
{
  public DualFieldAst ObjField(TokenAt at, string name, IGqlpObjBase typeBase, string description)
    => new(at, name, description, typeBase);

  public AstObject<IGqlpDualField> Object(TokenAt at, string name, string description)
    => new(TypeKind.Dual, at, name, description);
}
