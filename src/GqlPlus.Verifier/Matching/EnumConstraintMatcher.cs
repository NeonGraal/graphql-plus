using GqlPlus.Abstractions.Schema;
using GqlPlus.Verifying.Schema;

namespace GqlPlus.Matching;

internal class EnumConstraintMatcher(
  ILoggerFactory logger,
  Matcher<IGqlpType>.D anyTypeMatcher,
  Matcher<IGqlpEnum>.D enumMatcher
) : MatchConstraintBase<IGqlpEnum>(logger, anyTypeMatcher)
{
  private readonly Matcher<IGqlpEnum>.L _enumMatcher = enumMatcher;

  public override bool MatchesConstraint(IGqlpType type, IGqlpEnum constraint, EnumContext context)
    => base.MatchesConstraint(type, constraint, context)
      || _enumMatcher.Matches(constraint, type.Name, context);
}
