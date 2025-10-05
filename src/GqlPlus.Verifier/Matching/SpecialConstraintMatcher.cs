using GqlPlus.Abstractions.Schema;
using GqlPlus.Verifying.Schema;

namespace GqlPlus.Matching;

internal class SpecialConstraintMatcher(
  ILoggerFactory logger,
  Matcher<IGqlpType>.D anyTypeMatcher
) : MatchConstraintBase<IGqlpTypeSpecial>(logger, anyTypeMatcher)
{
  public override bool MatchesConstraint(IGqlpType type, IGqlpTypeSpecial constraint, EnumContext context)
    => base.MatchesConstraint(type, constraint, context)
      || constraint.MatchesTypeSpecial(type);
}
