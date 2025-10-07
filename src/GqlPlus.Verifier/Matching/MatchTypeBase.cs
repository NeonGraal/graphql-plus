using GqlPlus.Abstractions.Schema;
using GqlPlus.Verifying.Schema;

namespace GqlPlus.Matching;

internal abstract class MatchTypeBase<TType>(
  ILoggerFactory logger
) : MatcherBase<TType>(logger)
  , ITypeMatcher
  where TType : IGqlpType
{
  public bool MatchesTypeConstraint(IGqlpType type, string constraint, EnumContext context)
    => type is TType theType && Matches(theType, constraint, context);
}
