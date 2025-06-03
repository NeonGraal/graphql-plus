using GqlPlus.Abstractions.Schema;
using GqlPlus.Verifying.Schema;

namespace GqlPlus.Matching;

internal class UnionConstraintMatcher(
  ILoggerFactory logger,
  Matcher<IGqlpType>.D anyTypeMatcher
) : ConstraintMatcherBase<IGqlpUnion>(logger)
{
  private readonly Matcher<IGqlpType>.L _anyTypeMatcher = anyTypeMatcher;

  public override bool MatchesConstraint(IGqlpType type, IGqlpUnion constraint, EnumContext context)
    => base.MatchesConstraint(type, constraint, context)
      || constraint.Items.Any(MatchesUnionMember(type, context));

  private Func<IGqlpUnionMember, bool> MatchesUnionMember(IGqlpType type, EnumContext context)
    => member => member.Name.Equals(type.Name, StringComparison.Ordinal)
      || _anyTypeMatcher.Matches(type, member.Name, context);
}
