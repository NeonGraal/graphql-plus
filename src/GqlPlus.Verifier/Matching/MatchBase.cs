using GqlPlus.Verifying.Schema;

namespace GqlPlus.Matching;

internal abstract class MatchBase<TType>(
  IMatcherRepository matchers
) : MatchLogger(matchers)
  , Matcher<TType>.I
{
  public abstract bool Matches(TType type, string constraint, EnumContext context);
}
