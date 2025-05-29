using GqlPlus.Abstractions.Schema;
using GqlPlus.Verifying.Schema;

namespace GqlPlus.Matching;

internal abstract class MatcherBase<TType>
  : IMatch<TType>
  , IMatcher
  where TType : IGqlpType
{
  public bool MatchesTypeConstraint(IGqlpType type, string constraint, UsageContext context)
    => type is TType theType && Matches(theType, constraint, context);

  public abstract bool Matches(TType type, string constraint, UsageContext context);
}
