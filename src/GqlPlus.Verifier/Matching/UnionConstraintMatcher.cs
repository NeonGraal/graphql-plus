using GqlPlus.Abstractions.Schema;
using GqlPlus.Verifying.Schema;

namespace GqlPlus.Matching;

internal class UnionConstraintMatcher(
  ILoggerFactory logger,
  Matcher<IGqlpType>.D anyTypeMatcher
) : TypeMatcherBase<IGqlpType>(logger)
{
  private readonly Matcher<IGqlpType>.L _anyTypeMatcher = anyTypeMatcher;

  public override bool Matches(IGqlpType type, string constraint, EnumContext context)
  {
    Logger.TryingMatch(type, constraint);

    return context.GetTyped(constraint, out IGqlpUnion? unionType)
          && unionType.Items.Any(MatchesUnionMember(type, context));
  }

  private Func<IGqlpUnionMember, bool> MatchesUnionMember(IGqlpType type, EnumContext context)
    => member => member.Name.Equals(type.Name, StringComparison.Ordinal)
      || _anyTypeMatcher.Matches(type, member.Name, context);
}
