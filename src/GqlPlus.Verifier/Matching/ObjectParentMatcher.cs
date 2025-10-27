using GqlPlus.Abstractions.Schema;
using GqlPlus.Verifying.Schema;

namespace GqlPlus.Matching;

internal class ObjectParentMatcher<TField>(
  ILoggerFactory logger
) : MatchParentBase<IGqlpObjBase, IGqlpObject<TField>>(logger)
  where TField : class, IGqlpObjField
{
  protected override bool MatchParent(IGqlpObjBase parent, string constraint, UsageContext context)
    => MatchArgOrType<IGqlpObject<TField>, UsageContext>(parent.TypeName, constraint, context, MatchObject);

  protected bool MatchObject<TObj>(TObj obj, string constraint, UsageContext context)
    where TObj : class, IGqlpObject
    => obj.Parent is not null && MatchParent(obj.Parent, constraint, context);
}
