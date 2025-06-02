using GqlPlus.Abstractions.Schema;
using GqlPlus.Verifying.Schema;

namespace GqlPlus.Matching;

internal class AlternateConstraintMatcher(
  ILoggerFactory logger,
  Matcher<IGqlpType>.D anyTypeMatcher
) : TypeMatcherBase<IGqlpType>(logger)
{
  private readonly Matcher<IGqlpType>.L _anyTypeMatcher = anyTypeMatcher;

  public override bool Matches(IGqlpType type, string constraint, EnumContext context)
  {
    Logger.TryingMatch(type, constraint);

    return context.GetTyped(constraint, out IGqlpObject? objectType)
          && objectType.Alternates.Any(MatchesUnionMember(type, context));
  }

  private Func<IGqlpObjAlternate, bool> MatchesUnionMember(IGqlpType type, EnumContext context)
    => alternate => alternate.Name.Equals(type.Name, StringComparison.Ordinal)
      || _anyTypeMatcher.Matches(type, alternate.Name, context);
}
