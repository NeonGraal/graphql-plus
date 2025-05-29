using GqlPlus.Abstractions.Schema;
using GqlPlus.Verifying.Schema;

namespace GqlPlus.Matching;

public interface IMatch<TType>
  where TType : IGqlpType
{
  bool Matches(TType type, string constraint, UsageContext context);
}

public interface IMatcher
{
  bool MatchesTypeConstraint(IGqlpType type, string constraint, UsageContext context);
}
