using GqlPlus.Ast.Schema;
using GqlPlus.Verifying.Schema;

namespace GqlPlus.Matching;

internal class MatchObjectParentDualBase<TField>(
  IMatcherRepository matchers
) : ObjectParentMatcher<TField>(matchers)
  where TField : class, IAstObjField
{
  protected override bool MatchParent(IAstObjBase parent, string constraint, UsageContext context)
    => parent is not null && (
      MatchArgOrType<IAstObject<TField>, UsageContext>(parent.TypeName, constraint, context, MatchObject)
    || MatchArgOrType<IAstObject<IAstDualField>, UsageContext>(parent.TypeName, constraint, context, MatchDual));

  private bool MatchDual(IAstObject<IAstDualField> dual, string constraint, UsageContext context)
    => MatchObject(dual, constraint, context);

  internal static new MatchObjectParentDualBase<TField> Factory(IMatcherRepository m) => new(m);
}
