using GqlPlus.Token;

namespace GqlPlus.Ast;

internal abstract record class AstBase(
  ITokenAt At
) : IGqlpError
{
  internal TokenMessage Error(string message)
    => new(At, message);
  public IMessages MakeError(string message)
    => new Messages(Error(message));
}
