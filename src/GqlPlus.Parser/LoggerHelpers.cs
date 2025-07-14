namespace GqlPlus;

public static class LoggerHelpers
{
  public static ILogger CreateTypedLogger<T>(this ILoggerFactory factory)
      => factory.CreateTypedLogger(typeof(T));

  public static ILogger CreateTypedLogger(this ILoggerFactory factory, [NotNull] object instance)
      => factory.CreateTypedLogger(instance.GetType());

  public static ILogger CreateTypedLogger([NotNull] this ILoggerFactory factory, Type type)
      => factory.CreateLogger(type.ExpandTypeName());
}
