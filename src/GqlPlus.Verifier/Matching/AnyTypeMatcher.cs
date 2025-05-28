using GqlPlus.Abstractions.Schema;
using GqlPlus.Verifying.Schema;

namespace GqlPlus.Matching;

internal class AnyTypeMatcher(
  IEnumerable<IMatcher> matchers
) : IMatch<IGqlpType>
{
  public bool Matches(IGqlpType type, IGqlpType constraint, UsageContext context)
    => matchers
      .SingleOrDefault(m => m.ForConstraint(constraint))
      ?.MatchesConstraint(type, constraint, context)
      ?? throw new InvalidOperationException($"No Constraint Matcher for {constraint.Name}");
}
