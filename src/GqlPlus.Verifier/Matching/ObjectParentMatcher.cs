using GqlPlus.Abstractions.Schema;
using GqlPlus.Verifying.Schema;

namespace GqlPlus.Matching;

internal class ObjectParentMatcher<TType>(
  ILoggerFactory logger
) : MatchParentBase<IGqlpObjBase, TType>(logger)
  where TType : class, IGqlpObject
{
  protected override bool MatchParent(IGqlpObjBase parent, string constraint, UsageContext context)
    => MatchArgOrType<TType, UsageContext>(parent.TypeName, constraint, context, MatchObject);

  protected bool MatchObject<TObj>(TObj obj, string constraint, UsageContext context)
    where TObj : class, IGqlpObject
    => obj.Parent is not null && MatchParent(obj.Parent, constraint, context);
}
