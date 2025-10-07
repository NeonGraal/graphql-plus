using GqlPlus.Abstractions.Schema;
using GqlPlus.Verifying.Schema;

namespace GqlPlus.Matching;

internal class MatchObjectParentDualBase<TType>(
  ILoggerFactory logger
) : ObjectParentMatcher<TType>(logger)
  where TType : class, IGqlpObject
{
  protected override bool MatchParent(IGqlpObjBase parent, string constraint, UsageContext context)
    => parent is not null && (
      MatchArgOrType<TType, UsageContext>(parent.TypeName, constraint, context, MatchObject)
    || MatchArgOrType<IGqlpDualObject, UsageContext>(parent.TypeName, constraint, context, MatchDual));

  private bool MatchDual(IGqlpDualObject dual, string constraint, UsageContext context)
    => MatchObject(dual, constraint, context);
}
