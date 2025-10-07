using GqlPlus.Abstractions.Schema;
using GqlPlus.Verifying.Schema;

namespace GqlPlus.Matching;

internal class AlternateConstraintMatcher(
  ILoggerFactory logger,
  Matcher<IGqlpType>.D anyTypeMatcher
) : MatchConstraintBase<IGqlpObject>(logger)
{
  private readonly Matcher<IGqlpType>.L _anyTypeMatcher = anyTypeMatcher;

  public override bool MatchesConstraint(IGqlpType type, IGqlpObject constraint, EnumContext context)
    => base.MatchesConstraint(type, constraint, context)
      || constraint.Alternates.Any(MatchesAltMember(type, context));

  private Func<IGqlpObjAlt, bool> MatchesAltMember(IGqlpType type, EnumContext context)
    => alternate => MatchArgOrType<IGqlpType, EnumContext>(type.Name, alternate.Name, context, _anyTypeMatcher.Matches);
}
