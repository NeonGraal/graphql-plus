using GqlPlus.Ast.Schema.Objects;
using GqlPlus.Token;

namespace GqlPlus.Parse.Schema.Objects;

internal sealed class InputFactories
  : IObjectFactories<InputDeclAst, InputFieldAst, InputBaseAst>
{
  public InputFieldAst ObjField(TokenAt at, string name, InputBaseAst typeBase, string description)
    => new(at, name, description, typeBase);

  public InputDeclAst Object(TokenAt at, string name, string description)
    => new(at, name, description);

  public InputBaseAst ObjBase(TokenAt at, string name, string description)
    => new(at, name, description);
}
