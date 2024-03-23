using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Ast.Schema;

public abstract record class AstSimple(
  TokenAt At,
  string Name,
  string Description
) : AstType<string>(At, Name, Description)
{ }
