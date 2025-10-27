using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Objects;
using GqlPlus.Token;

namespace GqlPlus.Parsing.Schema.Objects;

[ExcludeFromCodeCoverage]

internal sealed class InputFactories
  : IObjectFactories<IGqlpInputField, InputFieldAst>
{
  public InputFieldAst ObjField(TokenAt at, string name, IGqlpObjBase typeBase, string description)
    => new(at, name, description, typeBase);

  public AstObject<IGqlpInputField> Object(TokenAt at, string name, string description)
    => new(TypeKind.Input, at, name, description);
}
