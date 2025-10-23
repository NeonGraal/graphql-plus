namespace GqlPlus.Building;

public class ErrorBuilder
  : IMockBuilder
{
  protected IList<Type> Types { get; } = [];

  protected void Add<T>()
    => Types.Add(typeof(T));

  public ErrorBuilder()
    => Add<IGqlpError>();

  protected T Build<T>()
    where T : class, IGqlpError
  {
    T result = (T)Substitute.For([.. Types], []);

    result.MakeError("").ReturnsForAnyArgs(c => c.ThrowIfNull().Arg<string>().MakeMessages());

    return result;
  }
}

public static class ErrorBuilderHelper
{
  public static T FluentAction<T>(this T? target, Action<T>? action)
  {
    target.ThrowIfNull();
    action?.Invoke(target);
    return target;
  }
}
