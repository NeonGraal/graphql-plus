using GqlPlus.Abstractions.Schema;
using GqlPlus.Verifying.Schema;

namespace GqlPlus.Matching;

public interface IMatch<TConstraint>
  where TConstraint : IGqlpType
{
  bool Matches(IGqlpType type, TConstraint constraint, UsageContext context);
}

internal interface IMatcher
{
  bool ForConstraint(IGqlpType type);
  bool MatchesConstraint(IGqlpType type, IGqlpType constraint, UsageContext context);
}
