using GqlPlus.Ast.Schema;
using GqlPlus.Ast.Schema.Objects;
using GqlPlus.Token;

namespace GqlPlus.Parsing.Schema.Objects;

internal sealed class InputFactories
  : IObjectFactories<IAstInputField, InputFieldAst>
{
  public InputFieldAst ObjField(
    TokenAt at,
    string name,
    IAstObjBase typeBase,
    string description
  ) => new(at, name, description, typeBase);

  public AstObject<IAstInputField> Object(TokenAt at, string name, string description)
    => new(TypeKind.Input, at, name, description);
}
