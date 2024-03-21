using GqlPlus.Verifier.Ast.Schema;
using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Parse.Schema;

internal sealed class DualFactories
  : IObjectFactories<DualDeclAst, DualFieldAst, DualReferenceAst>
{
  public DualFieldAst Field(TokenAt at, string name, DualReferenceAst typeReference, string description)
    => new(at, name, description, typeReference);

  public DualDeclAst Object(TokenAt at, string name, string description)
    => new(at, name, description);

  public DualReferenceAst Reference(TokenAt at, string name, string description)
    => new(at, name, description);
}
