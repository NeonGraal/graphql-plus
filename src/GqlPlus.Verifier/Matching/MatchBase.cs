using GqlPlus.Verifying.Schema;

namespace GqlPlus.Matching;

internal abstract class MatchBase<TType>(
  ILoggerFactory logger
) : MatchLogger(logger)
  , Matcher<TType>.I
{
  public abstract bool Matches(TType type, string constraint, EnumContext context);
}
