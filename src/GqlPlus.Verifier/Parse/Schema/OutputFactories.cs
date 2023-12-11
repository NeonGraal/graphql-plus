using GqlPlus.Verifier.Ast.Schema;
using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Parse.Schema;

internal class OutputFactories
  : IObjectFactories<OutputDeclAst, OutputFieldAst, OutputReferenceAst>
{
  public OutputFieldAst Field(TokenAt at, string name, OutputReferenceAst typeReference, string description)
    => new(at, name, description, typeReference);

  public OutputDeclAst Object(TokenAt at, string name, string description)
    => new(at, name, description);

  public OutputReferenceAst Reference(TokenAt at, string name, string description)
    => new(at, name, description);
}
