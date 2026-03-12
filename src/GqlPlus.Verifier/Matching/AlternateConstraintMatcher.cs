using GqlPlus.Abstractions.Schema;
using GqlPlus.Verifying.Schema;

namespace GqlPlus.Matching;

internal class AlternateConstraintMatcher(
  IMatcherRepository matchers
) : MatchConstraintBase<IGqlpObject>(matchers)
{
  private readonly Matcher<IGqlpType>.L _anyTypeMatcher = matchers.MatcherFor<IGqlpType>();

  public override bool MatchesConstraint(IGqlpType type, IGqlpObject constraint, EnumContext context)
    => base.MatchesConstraint(type, constraint, context)
      || constraint.Alternates.Any(MatchesAltMember(type, context));

  private Func<IGqlpAlternate, bool> MatchesAltMember(IGqlpType type, EnumContext context)
    => alternate => MatchArgOrType<IGqlpType, EnumContext>(type.Name, alternate.Name, context, _anyTypeMatcher.Matches);
}
