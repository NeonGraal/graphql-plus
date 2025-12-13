namespace GqlPlus;

public static class LoggerHelpers
{
  public static ILogger CreateTypedLogger(this ILoggerFactory factory, [NotNull] object instance)
      => factory.CreateTypedLogger(instance.GetType().ExpandTypeName());
}
