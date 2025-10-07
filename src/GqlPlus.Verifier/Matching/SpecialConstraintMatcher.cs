using GqlPlus.Abstractions.Schema;
using GqlPlus.Verifying.Schema;

namespace GqlPlus.Matching;

internal class SpecialConstraintMatcher(
  ILoggerFactory logger
) : MatchConstraintBase<IGqlpTypeSpecial>(logger)
{
  public override bool MatchesConstraint(IGqlpType type, IGqlpTypeSpecial constraint, EnumContext context)
    => base.MatchesConstraint(type, constraint, context)
      || constraint.MatchesTypeSpecial(type);
}
