using GqlPlus.Abstractions.Schema;
using GqlPlus.Verifying.Schema;

namespace GqlPlus.Matching;

internal abstract class MatchAnyTypeLogger(
  ILoggerFactory logger,
  Matcher<IGqlpType>.D anyTypeMatcher
) : MatchLogger(logger)
{
  private readonly Matcher<IGqlpType>.L _anyTypeMatcher = anyTypeMatcher;

  protected bool MatchArgOrType(string type, string constraint, EnumContext context, Func<IGqlpType, bool?>? action = null)
  {
    if (type.Equals(constraint, StringComparison.Ordinal)) {
      return true;
    }

    if (context.GetTyped(type, out IGqlpTypeParam? typeParam)) {
      return MatchArgOrType(typeParam.Constraint, constraint, context);
    }

    if (!context.GetTyped(type, out IGqlpType? argType)) {
      return false;
    }

    if (argType.Name.Equals(constraint, StringComparison.Ordinal)) {
      return true;
    }

    return action?.Invoke(argType) ?? _anyTypeMatcher.Matches(argType, constraint, context);
  }
}
