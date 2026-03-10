using GqlPlus.Abstractions.Schema;
using GqlPlus.Verifying.Schema;

namespace GqlPlus.Matching;

internal class SpecialConstraintMatcher(
  IMatcherRepository matchers
) : MatchConstraintBase<IGqlpTypeSpecial>(matchers)
{
  public override bool MatchesConstraint(IGqlpType type, IGqlpTypeSpecial constraint, EnumContext context)
    => base.MatchesConstraint(type, constraint, context)
      || constraint.MatchesTypeSpecial(type);
}
