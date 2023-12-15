using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Ast.Schema;

public abstract record class AstType(TokenAt At, string Name, string Description)
  : AstDeclaration(At, Name, Description)
{
}
