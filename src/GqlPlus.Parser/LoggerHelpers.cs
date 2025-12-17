namespace GqlPlus;

public static class LoggerHelpers
{
  public static ILogger CreateTypedLogger(this ILoggerFactory factory, [NotNull] object instance)
      => factory.ThrowIfNull().CreateLogger(instance.GetType().ExpandTypeName());
}
