using GqlPlus.Abstractions.Schema;
using GqlPlus.Verifying.Schema;

namespace GqlPlus.Matching;

internal class EnumConstraintMatcher(
  IMatcherRepository matchers
) : MatchConstraintBase<IAstEnum>(matchers)
{
  private readonly Matcher<IAstEnum>.L _enumMatcher = matchers.MatcherFor<IAstEnum>();

  public override bool MatchesConstraint(IAstType type, IAstEnum constraint, EnumContext context)
    => base.MatchesConstraint(type, constraint, context)
      || _enumMatcher.Matches(constraint, type.Name, context);
}
