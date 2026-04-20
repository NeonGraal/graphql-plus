using GqlPlus.Ast.Schema;
using GqlPlus.Ast.Schema.Objects;
using GqlPlus.Token;

namespace GqlPlus.Parsing.Schema.Objects;

internal sealed class DualFactories
  : IObjectFactories<IAstDualField, DualFieldAst>
{
  public DualFieldAst ObjField(
    TokenAt at,
    string name,
    IAstObjBase typeBase,
    string description
  ) => new(at, name, description, typeBase);

  public AstObject<IAstDualField> Object(TokenAt at, string name, string description)
    => new(TypeKind.Dual, at, name, description);
}
