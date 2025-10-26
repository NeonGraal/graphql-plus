using GqlPlus.Abstractions.Schema;
using GqlPlus.Verifying.Schema;

namespace GqlPlus.Matching;

internal class AnyTypeMatcher(
  ILoggerFactory logger,
  IEnumerable<ITypeMatcher> matchers
) : MatchBase<IGqlpType>(logger)
{
  public override bool Matches(IGqlpType type, string constraint, EnumContext context)
  {
    TryingMatch(type, constraint);

    if (matchers is null || !matchers.Any()) {
      throw new InvalidOperationException("No matchers available to match types.");
    }

    return matchers.Any(m => m.MatchesTypeConstraint(type, constraint, context));
  }
}
