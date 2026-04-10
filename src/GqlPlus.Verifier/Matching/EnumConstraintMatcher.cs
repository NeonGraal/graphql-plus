using GqlPlus.Abstractions.Schema;
using GqlPlus.Verifying.Schema;

namespace GqlPlus.Matching;

internal class EnumConstraintMatcher(
  IMatcherRepository matchers
) : MatchConstraintBase<IGqlpEnum>(matchers)
{
  private readonly Matcher<IGqlpEnum>.L _enumMatcher = matchers.MatcherFor<IGqlpEnum>();

  public override bool MatchesConstraint(IAstType type, IGqlpEnum constraint, EnumContext context)
    => base.MatchesConstraint(type, constraint, context)
      || _enumMatcher.Matches(constraint, type.Name, context);
}
