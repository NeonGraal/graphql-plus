using GqlPlus.Verifying.Schema;

namespace GqlPlus.Matching;

internal abstract class MatcherBase<TType>(
  ILoggerFactory logger
) : Matcher<TType>.I
{
  protected ILogger Logger { get; } = logger.CreateLogger(typeof(Matcher<TType>).ExpandTypeName());

  public abstract bool Matches(TType type, string constraint, EnumContext context);
}

internal static partial class MatcherLogging
{
  internal static void TryingMatch(this ILogger logger, object type, string constraint)
    => logger.TryingMatch(type.GetType().TidyTypeName(), type, constraint);

  [LoggerMessage(LogLevel.Information, Message = "Trying to match ({Type}) {Instance} to {Constraint}")]
  internal static partial void TryingMatch(this ILogger logger, string type, object instance, string constraint);
}
