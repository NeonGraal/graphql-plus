using GqlPlus.Abstractions.Schema;
using GqlPlus.Verifying.Schema;

namespace GqlPlus.Matching;

internal class AlternateConstraintMatcher(
  IMatcherRepository matchers
) : MatchConstraintBase<IAstObject>(matchers)
{
  private readonly Matcher<IAstType>.L _anyTypeMatcher = matchers.MatcherFor<IAstType>();

  public override bool MatchesConstraint(IAstType type, IAstObject constraint, EnumContext context)
    => base.MatchesConstraint(type, constraint, context)
      || constraint.Alternates.Any(MatchesAltMember(type, context));

  private Func<IAstAlternate, bool> MatchesAltMember(IAstType type, EnumContext context)
    => alternate => MatchArgOrType<IAstType, EnumContext>(type.Name, alternate.Name, context, _anyTypeMatcher.Matches);
}
