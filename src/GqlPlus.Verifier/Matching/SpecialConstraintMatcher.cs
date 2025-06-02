using GqlPlus.Abstractions.Schema;
using GqlPlus.Verifying.Schema;

namespace GqlPlus.Matching;

internal class SpecialConstraintMatcher(
  ILoggerFactory logger
) : TypeMatcherBase<IGqlpType>(logger)
{
  public override bool Matches(IGqlpType type, string constraint, EnumContext context)
  {
    Logger.TryingMatch(type, constraint);

    return context.GetTyped(constraint, out IGqlpTypeSpecial? typespecialType)
          && typespecialType.MatchesTypeSpecial(type);
  }
}
