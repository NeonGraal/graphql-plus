using GqlPlus.Abstractions.Schema;
using GqlPlus.Verifying.Schema;

namespace GqlPlus.Matching;

internal class UnionConstraintMatcher(
  IMatcherRepository matchers
) : MatchConstraintBase<IGqlpUnion>(matchers)
{
  private readonly Matcher<IAstType>.L _anyTypeMatcher = matchers.MatcherFor<IAstType>();

  public override bool MatchesConstraint(IAstType type, IGqlpUnion constraint, EnumContext context)
    => base.MatchesConstraint(type, constraint, context)
      || constraint.Items.Any(MatchesUnionMember(type, context));

  private Func<IGqlpUnionMember, bool> MatchesUnionMember(IAstType type, EnumContext context)
    => member => MatchArgOrType<IAstType, EnumContext>(type.Name, member.Name, context, _anyTypeMatcher.Matches);
}
