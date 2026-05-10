using GqlPlus.Ast.Schema;
using GqlPlus.Verifying.Schema;

namespace GqlPlus.Matching;

internal class AnyTypeMatcher(
  IMatcherRepository matchers
) : MatchBase<IAstType>(matchers)
{
  private readonly DeferList<ITypeMatcher> _typeMatchers = matchers.TypeMatchers();

  public override bool Matches(IAstType type, string constraint, EnumContext context)
  {
    TryingMatch(type, constraint);

    if (_typeMatchers.I.Any()) {
      return _typeMatchers.I.Any(m => m.MatchesTypeConstraint(type, constraint, context));
    }

    throw new InvalidOperationException("No matchers available to match types.");
  }

  internal static AnyTypeMatcher Factory(IMatcherRepository m) => new(m);
}
