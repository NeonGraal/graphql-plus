using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Objects;
using GqlPlus.Token;

namespace GqlPlus.Parsing.Schema.Objects;

[ExcludeFromCodeCoverage]

internal class OutputFactories
  : IObjectFactories<IGqlpOutputField, OutputFieldAst>
{
  public OutputFieldAst ObjField(TokenAt at, string name, IGqlpObjBase typeBase, string description)
    => new(at, name, description, typeBase);

  public AstObject<IGqlpOutputField> Object(TokenAt at, string name, string description)
    => new(TypeKind.Output, at, name, description);
}
