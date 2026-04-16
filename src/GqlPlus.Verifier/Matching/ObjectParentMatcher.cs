using GqlPlus.Abstractions.Schema;
using GqlPlus.Verifying.Schema;

namespace GqlPlus.Matching;

internal class ObjectParentMatcher<TField>(
  IMatcherRepository matchers
) : MatchParentBase<IAstObjBase, IAstObject<TField>>(matchers)
  where TField : class, IAstObjField
{
  protected override bool MatchParent(IAstObjBase parent, string constraint, UsageContext context)
    => MatchArgOrType<IAstObject<TField>, UsageContext>(parent.TypeName, constraint, context, MatchObject);

  protected bool MatchObject<TObj>(TObj obj, string constraint, UsageContext context)
    where TObj : class, IAstObject
    => obj.Parent is not null && MatchParent(obj.Parent, constraint, context);

  internal static ObjectParentMatcher<TField> Factory(IMatcherRepository m) => new(m);
}
