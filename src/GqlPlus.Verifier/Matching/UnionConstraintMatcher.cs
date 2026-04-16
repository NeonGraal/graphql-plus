using GqlPlus.Ast.Schema;
using GqlPlus.Verifying.Schema;

namespace GqlPlus.Matching;

internal class UnionConstraintMatcher(
  IMatcherRepository matchers
) : MatchConstraintBase<IAstUnion>(matchers)
{
  private readonly Matcher<IAstType>.L _anyTypeMatcher = matchers.MatcherFor<IAstType>();

  public override bool MatchesConstraint(IAstType type, IAstUnion constraint, EnumContext context)
    => base.MatchesConstraint(type, constraint, context)
      || constraint.Items.Any(MatchesUnionMember(type, context));

  private Func<IAstUnionMember, bool> MatchesUnionMember(IAstType type, EnumContext context)
    => member => MatchArgOrType<IAstType, EnumContext>(type.Name, member.Name, context, _anyTypeMatcher.Matches);

  internal static UnionConstraintMatcher Factory(IMatcherRepository m) => new(m);
}
