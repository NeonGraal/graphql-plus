using GqlPlus.Abstractions.Schema;
using GqlPlus.Verifying.Schema;

namespace GqlPlus.Matching;

internal abstract class TypeMatcherBase<TType>(
  ILoggerFactory logger
) : MatcherBase<TType>(logger)
  , ITypeMatcher
  where TType : IGqlpType
{
  public virtual bool MatchesTypeConstraint(IGqlpType type, string constraint, EnumContext context)
    => type is TType theType && Matches(theType, constraint, context);
}
