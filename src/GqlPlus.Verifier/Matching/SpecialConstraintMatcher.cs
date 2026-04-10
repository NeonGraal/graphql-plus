using GqlPlus.Abstractions.Schema;
using GqlPlus.Verifying.Schema;

namespace GqlPlus.Matching;

internal class SpecialConstraintMatcher(
  IMatcherRepository matchers
) : MatchConstraintBase<IAstTypeSpecial>(matchers)
{
  public override bool MatchesConstraint(IAstType type, IAstTypeSpecial constraint, EnumContext context)
    => base.MatchesConstraint(type, constraint, context)
      || constraint.MatchesTypeSpecial(type);
}
