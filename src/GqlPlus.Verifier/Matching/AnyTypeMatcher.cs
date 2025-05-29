using GqlPlus.Abstractions.Schema;
using GqlPlus.Verifying.Schema;

namespace GqlPlus.Matching;

internal class AnyTypeMatcher(
  IEnumerable<IMatcher> matchers
) : IMatch<IGqlpType, IGqlpType>
{
  public bool Matches(IGqlpType type, IGqlpType constraint, UsageContext context)
  {
    if (matchers is null || !matchers.Any()) {
      throw new InvalidOperationException("No matchers available to match types.");
    }

    return matchers
        .Any(m => m.MatchesTypeConstraint(type, constraint, context));
  }
}
