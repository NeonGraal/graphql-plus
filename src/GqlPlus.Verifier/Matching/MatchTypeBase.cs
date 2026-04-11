using GqlPlus.Ast.Schema;
using GqlPlus.Verifying.Schema;

namespace GqlPlus.Matching;

internal abstract class MatchTypeBase<TType>(
  IMatcherRepository matchers
) : MatchBase<TType>(matchers)
  , ITypeMatcher
  where TType : IAstType
{
  public bool MatchesTypeConstraint(IAstType type, string constraint, EnumContext context)
    => type is TType theType && Matches(theType, constraint, context);
}
