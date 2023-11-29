using GqlPlus.Verifier.Ast.Schema;

namespace GqlPlus.Verifier.Parse.Schema;

internal class InputFactories
  : IObjectFactories<InputAst, InputFieldAst, InputReferenceAst>
{
  public InputFieldAst Field(ParseAt at, string name, string description, InputReferenceAst typeReference)
    => new(at, name, description, typeReference);

  public InputAst Object(ParseAt at, string name, string description)
    => new(at, name, description);

  public InputReferenceAst Reference(ParseAt at, string name)
    => new(at, name);
}
