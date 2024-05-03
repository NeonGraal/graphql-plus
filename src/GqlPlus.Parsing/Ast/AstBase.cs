using GqlPlus.Token;

namespace GqlPlus.Ast;

public abstract record class AstBase(TokenAt At)
{
  internal TokenMessage Error(string message)
    => new(At, message);
}
