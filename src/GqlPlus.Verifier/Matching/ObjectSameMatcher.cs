using GqlPlus.Abstractions.Schema;
using GqlPlus.Verifying.Schema;

namespace GqlPlus.Matching;

internal class ObjectSameMatcher<TType>(
  ILoggerFactory logger
) : ParentSameMatcher<IGqlpObjBase, TType>(logger)
  where TType : IGqlpObject
{
  protected override bool MatchParent(string? parent, string constraint, UsageContext context)
  {
    if (base.MatchParent(parent, constraint, context)) {
      return true;
    }

    return MatchDualParent(parent, constraint, context);
  }

  private static bool MatchDualParent(string? parent, string constraint, UsageContext context)
    => MatchName(parent, constraint)
      || context.GetTyped(parent, out IGqlpDualObject? typeParent)
        && MatchDualParent(typeParent.Parent?.Name, constraint, context);
}
