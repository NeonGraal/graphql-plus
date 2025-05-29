using GqlPlus.Abstractions.Schema;
using GqlPlus.Verifying.Schema;

namespace GqlPlus.Matching;

public interface IMatch<TType, TConstraint>
  where TType : IGqlpType
  where TConstraint : IGqlpType
{
  bool Matches(TType type, TConstraint constraint, UsageContext context);
}

public interface IMatcher
{
  bool MatchesTypeConstraint(IGqlpType type, IGqlpType constraint, UsageContext context);
}
