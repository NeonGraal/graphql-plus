namespace GqlPlus.Matching;

internal abstract class MatcherLogger
{
  protected ILogger Logger { get; }

  protected MatcherLogger(ILoggerFactory logger)
    => Logger = logger.CreateTypedLogger(this);

  internal void TryingMatch(object type, string constraint)
    => Logger.TryingMatch(type, constraint);
}

internal static partial class MatcherLogging
{
  internal static void TryingMatch(this ILogger logger, object type, string constraint)
    => logger.TryingMatch(type.GetType().TidyTypeName(), type, constraint);

  [LoggerMessage(LogLevel.Information, Message = "Trying to match ({Type}) {Instance} to {Constraint}")]
  internal static partial void TryingMatch(this ILogger logger, string type, object instance, string constraint);
}
