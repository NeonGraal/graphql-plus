using GqlPlus.Verifier.Ast.Schema;
using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Parse.Schema;

internal class InputFactories
  : IObjectFactories<InputAst, InputFieldAst, InputReferenceAst>
{
  public InputFieldAst Field(TokenAt at, string name, string description, InputReferenceAst typeReference)
    => new(at, name, description, typeReference);

  public InputAst Object(TokenAt at, string name, string description)
    => new(at, name, description);

  public InputReferenceAst Reference(TokenAt at, string name)
    => new(at, name);
}
