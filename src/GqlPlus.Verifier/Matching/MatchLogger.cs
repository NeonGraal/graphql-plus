using GqlPlus.Abstractions.Schema;
using GqlPlus.Verifying.Schema;

namespace GqlPlus.Matching;

internal abstract class MatchLogger
{
  private readonly ILogger _logger;

  protected MatchLogger(ILoggerFactory logger)
    => _logger = logger.CreateTypedLogger(this);

  internal void TryingMatch(object type, string constraint)
    => _logger.TryingMatch(type, constraint);

  protected delegate bool MatchAction<TType, TContext>(TType type, string constraint, TContext context)
    where TType : class, IGqlpNamed
    where TContext : UsageContext;

  protected bool MatchArgOrType<TType, TContext>(
    string type,
    string constraint,
    TContext context,
    MatchAction<TType, TContext> action
  )
    where TType : class, IGqlpNamed
    where TContext : UsageContext
  {
    if (type.Equals(constraint, StringComparison.Ordinal)) {
      return true;
    }

    if (context.GetTyped(type, out IGqlpTypeParam? typeParam)) {
      return MatchArgOrType(typeParam.Constraint, constraint, context, action);
    }

    if (!context.GetTyped(type, out TType? argType)) {
      return false;
    }

    if (argType.Name.Equals(constraint, StringComparison.Ordinal)) {
      return true;
    }

    return action.Invoke(argType, constraint, context);
  }
}

internal static partial class MatcherLogging
{
  internal static void TryingMatch(this ILogger logger, object type, string constraint)
    => logger.TryingMatch(type.GetType().TidyTypeName(), type, constraint);

  [LoggerMessage(LogLevel.Information, Message = "Trying to match ({Type}) {Instance} to {Constraint}")]
  internal static partial void TryingMatch(this ILogger logger, string type, object instance, string constraint);
}
