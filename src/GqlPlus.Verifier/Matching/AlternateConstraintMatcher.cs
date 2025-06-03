using GqlPlus.Abstractions.Schema;
using GqlPlus.Verifying.Schema;

namespace GqlPlus.Matching;

internal class AlternateConstraintMatcher(
  ILoggerFactory logger,
  Matcher<IGqlpType>.D anyTypeMatcher
) : ConstraintMatcherBase<IGqlpObject>(logger)
{
  private readonly Matcher<IGqlpType>.L _anyTypeMatcher = anyTypeMatcher;

  public override bool MatchesConstraint(IGqlpType type, IGqlpObject constraint, EnumContext context)
    => base.MatchesConstraint(type, constraint, context)
      || constraint.Alternates.Any(MatchesUnionMember(type, context));

  private Func<IGqlpObjAlternate, bool> MatchesUnionMember(IGqlpType type, EnumContext context)
    => alternate => alternate.Name.Equals(type.Name, StringComparison.Ordinal)
      || _anyTypeMatcher.Matches(type, alternate.Name, context);
}
