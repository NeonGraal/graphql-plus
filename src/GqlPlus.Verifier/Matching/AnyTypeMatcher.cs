using GqlPlus.Abstractions.Schema;
using GqlPlus.Verifying.Schema;

namespace GqlPlus.Matching;

internal class AnyTypeMatcher(
  ILoggerFactory logger,
  IEnumerable<ITypeMatcher> matchers
) : MatcherBase<IGqlpType>(logger)
{
  public override bool Matches(IGqlpType type, string constraint, UsageContext context)
  {
    Logger.TryingMatch(type, constraint);

    if (matchers is null || !matchers.Any()) {
      throw new InvalidOperationException("No matchers available to match types.");
    }

    return matchers.Any(m => m.MatchesTypeConstraint(type, constraint, context));
  }
}
