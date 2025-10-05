using GqlPlus.Abstractions.Schema;
using GqlPlus.Verifying.Schema;

namespace GqlPlus.Matching;

internal abstract class MatchConstraintBase<TType>(
  ILoggerFactory logger,
  Matcher<IGqlpType>.D anyTypeMatcher
) : MatchAnyTypeLogger(logger, anyTypeMatcher)
  , IConstraintMatcher<TType>
  where TType : IGqlpType
{
  public virtual bool MatchesConstraint(IGqlpType type, TType constraint, EnumContext context)
  {
    TryingMatch(type, $"!{constraint.Abbr}:{constraint.Name}");

    return false;
  }

  public bool MatchesTypeConstraint(IGqlpType type, string constraint, EnumContext context)
    => context.GetTyped(constraint, out TType? constraintType)
      && MatchesConstraint(type, constraintType, context);
}
