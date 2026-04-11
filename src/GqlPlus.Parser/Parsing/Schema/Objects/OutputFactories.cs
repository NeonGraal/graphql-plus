using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Objects;
using GqlPlus.Token;

namespace GqlPlus.Parsing.Schema.Objects;

internal class OutputFactories
  : IObjectFactories<IAstOutputField, OutputFieldAst>
{
  public OutputFieldAst ObjField(
    TokenAt at,
    string name,
    IAstObjBase typeBase,
    string description
  ) => new(at, name, description, typeBase);

  public AstObject<IAstOutputField> Object(TokenAt at, string name, string description)
    => new(TypeKind.Output, at, name, description);
}
