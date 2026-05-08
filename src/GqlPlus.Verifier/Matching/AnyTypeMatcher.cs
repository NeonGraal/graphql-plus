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

    ITypeMatcher[] typeMatchers = [.. matchers.TypeMatchers.Select(f => f(matchers))];
    if (typeMatchers is null || typeMatchers.Length == 0) {
      throw new InvalidOperationException("No matchers available to match types.");
    }

    return typeMatchers.Any(m => m.MatchesTypeConstraint(type, constraint, context));
  }

  internal static AnyTypeMatcher Factory(IMatcherRepository m) => new(m);
}
