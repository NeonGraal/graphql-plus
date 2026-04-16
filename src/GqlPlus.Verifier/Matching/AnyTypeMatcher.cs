using GqlPlus.Ast.Schema;
using GqlPlus.Verifying.Schema;

namespace GqlPlus.Matching;

internal class AnyTypeMatcher(
  IMatcherRepository matchers
) : MatchBase<IAstType>(matchers)
{
  public override bool Matches(IAstType type, string constraint, EnumContext context)
  {
    TryingMatch(type, constraint);

    IEnumerable<ITypeMatcher> typeMatchers = matchers.TypeMatchers;
    if (typeMatchers is null || !typeMatchers.Any()) {
      throw new InvalidOperationException("No matchers available to match types.");
    }

    return typeMatchers.Any(m => m.MatchesTypeConstraint(type, constraint, context));
  }

  internal static AnyTypeMatcher Factory(IMatcherRepository m) => new(m);
}
