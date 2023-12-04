using GqlPlus.Verifier.Ast.Schema;
using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Parse.Schema;

internal class OutputFactories
  : IObjectFactories<OutputAst, OutputFieldAst, OutputReferenceAst>
{
  public OutputFieldAst Field(TokenAt at, string name, string description, OutputReferenceAst typeReference)
    => new(at, name, description, typeReference);

  public OutputAst Object(TokenAt at, string name, string description)
    => new(at, name, description);

  public OutputReferenceAst Reference(TokenAt at, string name)
    => new(at, name);
}
