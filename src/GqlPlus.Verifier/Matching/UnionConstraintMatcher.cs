using GqlPlus.Abstractions.Schema;
using GqlPlus.Verifying.Schema;

namespace GqlPlus.Matching;

internal class UnionConstraintMatcher(
  ILoggerFactory logger,
  Matcher<IGqlpType>.D anyTypeMatcher
) : MatchConstraintBase<IGqlpUnion>(logger, anyTypeMatcher)
{
  public override bool MatchesConstraint(IGqlpType type, IGqlpUnion constraint, EnumContext context)
    => base.MatchesConstraint(type, constraint, context)
      || constraint.Items.Any(MatchesUnionMember(type, context));

  private Func<IGqlpUnionMember, bool> MatchesUnionMember(IGqlpType type, EnumContext context)
    => member => MatchArgOrType(type.Name, member.Name, context);
}
