using GqlPlus.Abstractions.Schema;
using GqlPlus.Verifying.Schema;

namespace GqlPlus.Matching;

internal class MatchObjectSameDualBase<TType>(
  ILoggerFactory logger
) : ObjectSameMatcher<TType>(logger)
  where TType : IGqlpObject
{
  protected override bool MatchParent(IGqlpObjBase? parent, string constraint, UsageContext context)
  {
    if (base.MatchParent(parent, constraint, context)) {
      return true;
    }

    return MatchDualParent(parent, constraint, context);
  }

  private static bool MatchDualParent(IGqlpObjBase? parent, string constraint, UsageContext context)
    => MatchName(parent?.Name, constraint)
      || context.GetTyped(parent?.Name, out IGqlpDualObject? typeParent)
        && MatchDualParent(typeParent.Parent, constraint, context);
}
