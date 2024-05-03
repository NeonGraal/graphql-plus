using GqlPlus.Token;

namespace GqlPlus.Ast;

public abstract record class AstBase(
  TokenAt At
) : IGqlpError
{
  internal TokenMessage Error(string message)
    => new(At, message);
  public ITokenMessage MakeError(string message)
    => Error(message);
}
