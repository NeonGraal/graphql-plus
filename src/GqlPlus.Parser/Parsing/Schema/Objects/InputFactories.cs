using GqlPlus.Abstractions.Schema;
using GqlPlus.Ast.Schema.Objects;
using GqlPlus.Token;

namespace GqlPlus.Parsing.Schema.Objects;

[ExcludeFromCodeCoverage]

internal sealed class InputFactories
  : IObjectFactories<InputDeclAst, IGqlpInputField, InputFieldAst>
{
  public InputFieldAst ObjField(TokenAt at, string name, IGqlpObjBase typeBase, string description)
    => new(at, name, description, typeBase);

  public InputDeclAst Object(TokenAt at, string name, string description)
    => new(at, name, description);
}
