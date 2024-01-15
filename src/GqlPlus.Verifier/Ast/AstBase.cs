using GqlPlus.Verifier.Token;

namespace GqlPlus.Verifier.Ast;

public abstract record class AstBase(TokenAt At)
{
  internal TokenMessage Error(string message)
    => new(At, message);
}
