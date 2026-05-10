using GqlPlus.Ast.Schema;
using GqlPlus.Verifying.Schema;

namespace GqlPlus.Matching;

internal class AnyTypeMatcher(
  IMatcherRepository matchers
) : MatchBase<IAstType>(matchers)
{
  private readonly Defer<ITypeMatcher>.LA _typeMatchers = matchers.TypeMatchers();

  public override bool Matches(IAstType type, string constraint, EnumContext context)
  {
    TryingMatch(type, constraint);

    if (_typeMatchers.IA.Any()) {
      return _typeMatchers.IA.Any(m => m.MatchesTypeConstraint(type, constraint, context));
    }

    throw new InvalidOperationException("No matchers available to match types.");
  }

  internal static AnyTypeMatcher Factory(IMatcherRepository m) => new(m);
}
