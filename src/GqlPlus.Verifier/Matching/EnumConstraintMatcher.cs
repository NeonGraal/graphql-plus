using GqlPlus.Abstractions.Schema;
using GqlPlus.Verifying.Schema;

namespace GqlPlus.Matching;

internal class EnumConstraintMatcher(
  ILoggerFactory logger,
  Matcher<IGqlpEnum>.D enumMatcher
) : TypeMatcherBase<IGqlpType>(logger)
{
  private readonly Matcher<IGqlpEnum>.L _enumMatcher = enumMatcher;

  public override bool Matches(IGqlpType type, string constraint, EnumContext context)
  {
    Logger.TryingMatch(type, constraint);

    return context.GetTyped(constraint, out IGqlpEnum? enumType)
          && _enumMatcher.Matches(enumType, type.Name, context);
  }
}
