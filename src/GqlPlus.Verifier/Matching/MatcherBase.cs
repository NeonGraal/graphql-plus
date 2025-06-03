using GqlPlus.Verifying.Schema;

namespace GqlPlus.Matching;

internal abstract class MatcherBase<TType>(
  ILoggerFactory logger
) : MatcherLogger(logger)
  , Matcher<TType>.I
{
  public abstract bool Matches(TType type, string constraint, EnumContext context);
}
