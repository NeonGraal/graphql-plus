using GqlPlus.Abstractions.Schema;
using GqlPlus.Verifying.Schema;

namespace GqlPlus.Matching;

internal class ObjectSameMatcher<TType>(
  ILoggerFactory logger
) : MatchParentSameBase<IGqlpObjBase, TType>(logger)
  where TType : IGqlpObject
{
  protected override bool MatchParent(IGqlpObjBase? parent, string constraint, UsageContext context)
  {
    if (base.MatchParent(parent, constraint, context)) {
      return true;
    }

    if (context.GetTyped(parent?.Name, out IGqlpTypeParam? typeParam)) {
      // return MatchArgOrType(typeParam.Constraint, constraint, context);
    }

    return false;
  }
}
