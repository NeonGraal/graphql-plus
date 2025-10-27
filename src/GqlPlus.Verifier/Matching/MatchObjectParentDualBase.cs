using GqlPlus.Abstractions.Schema;
using GqlPlus.Verifying.Schema;

namespace GqlPlus.Matching;

internal class MatchObjectParentDualBase<TField>(
  ILoggerFactory logger
) : ObjectParentMatcher<TField>(logger)
  where TField : class, IGqlpObjField
{
  protected override bool MatchParent(IGqlpObjBase parent, string constraint, UsageContext context)
    => parent is not null && (
      MatchArgOrType<IGqlpObject<TField>, UsageContext>(parent.TypeName, constraint, context, MatchObject)
    || MatchArgOrType<IGqlpObject<IGqlpDualField>, UsageContext>(parent.TypeName, constraint, context, MatchDual));

  private bool MatchDual(IGqlpObject<IGqlpDualField> dual, string constraint, UsageContext context)
    => MatchObject(dual, constraint, context);
}
