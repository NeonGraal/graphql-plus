using GqlPlus.Abstractions.Schema;
using GqlPlus.Verifying.Schema;

namespace GqlPlus.Matching;

internal class AnyTypeMatcher(
  IMatcherRepository matchers
) : MatchBase<IGqlpType>(matchers)
{
  public override bool Matches(IGqlpType type, string constraint, EnumContext context)
  {
    TryingMatch(type, constraint);

    IEnumerable<ITypeMatcher> typeMatchers = matchers.TypeMatchers;
    if (typeMatchers is null || !typeMatchers.Any()) {
      throw new InvalidOperationException("No matchers available to match types.");
    }

    return typeMatchers.Any(m => m.MatchesTypeConstraint(type, constraint, context));
  }
}
