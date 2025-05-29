using GqlPlus.Abstractions.Schema;
using GqlPlus.Verifying.Schema;

namespace GqlPlus.Matching;

internal abstract class MatcherBase<TType, TConstraint>
  : IMatch<TType, TConstraint>
  , IMatcher
  where TType : IGqlpType
  where TConstraint : IGqlpType
{
  public bool MatchesTypeConstraint(IGqlpType type, IGqlpType constraint, UsageContext context)
    => type is TType theType && constraint is TConstraint theConstraint
      && Matches(theType, theConstraint, context);

  public abstract bool Matches(TType type, TConstraint constraint, UsageContext context);
}
