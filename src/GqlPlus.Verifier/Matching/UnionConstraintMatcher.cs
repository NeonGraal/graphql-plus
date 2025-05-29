using GqlPlus.Abstractions.Schema;
using GqlPlus.Verifying.Schema;

namespace GqlPlus.Matching;

internal class UnionConstraintMatcher(
  Matcher<IGqlpType>.D anyTypeMatcher
) : MatcherBase<IGqlpType>
{
  private readonly Matcher<IGqlpType>.L _anyTypeMatcher = anyTypeMatcher;

  public override bool Matches(IGqlpType type, string constraint, UsageContext context)
  {
    return context.GetTyped(constraint, out IGqlpUnion? unionType)
        && unionType.Items.Any(t => t.Name.Equals(type.Name, StringComparison.Ordinal)
          || _anyTypeMatcher.Matches(type, t.Name, context));
  }
}
