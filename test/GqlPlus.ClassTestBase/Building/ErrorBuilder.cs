using GqlPlus.Ast;

namespace GqlPlus.Building;

public class ErrorBuilder
  : IMockBuilder
{
  protected IList<Type> Types { get; } = [];

  protected void Add<T>()
    => Types.Add(typeof(T));

  public ErrorBuilder()
    => Add<IAstError>();

  protected T Build<T>()
    where T : class, IAstError
  {
    T result = (T)Substitute.For([.. Types], []);

    result.MakeError("").ReturnsForAnyArgs(c => c.ThrowIfNull().Arg<string>().MakeMessages());

    return result;
  }
}
