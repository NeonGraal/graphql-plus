using GqlPlus.Token;

namespace GqlPlus.Ast;

internal abstract record class AstBase(
  ITokenAt At
) : IAstError
{
  internal TokenMessage Error(string message)
    => new(At, message);
  public IMessages MakeError(string message)
    => new Messages(Error(message));
}
