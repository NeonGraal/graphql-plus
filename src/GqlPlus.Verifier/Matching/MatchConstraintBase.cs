using GqlPlus.Abstractions.Schema;
using GqlPlus.Verifying.Schema;

namespace GqlPlus.Matching;

internal abstract class MatchConstraintBase<TType>(
  IMatcherRepository matchers
) : MatchLogger(matchers)
  , IConstraintMatcher<TType>
  where TType : IAstType
{
  public virtual bool MatchesConstraint(IAstType type, TType constraint, EnumContext context)
  {
    TryingMatch(type, $"!{constraint.Kind}:{constraint.Name}");

    return false;
  }

  public bool MatchesTypeConstraint(IAstType type, string constraint, EnumContext context)
    => context.GetTyped(constraint, out TType? constraintType)
      && MatchesConstraint(type, constraintType, context);
}
