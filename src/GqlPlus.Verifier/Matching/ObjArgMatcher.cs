using GqlPlus.Abstractions.Schema;
using GqlPlus.Verifying.Schema;

namespace GqlPlus.Matching;

internal class ObjArgMatcher<TObjArg>(
    Matcher<IGqlpType>.D anyTypeMatcher
) : Matcher<TObjArg>.I
  where TObjArg : IGqlpObjArg
{
  private readonly Matcher<IGqlpType>.L _anyTypeMatcher = anyTypeMatcher;

  public virtual bool Matches(TObjArg arg, string constraint, UsageContext context)
  {
    if ("_Any".Equals(constraint, StringComparison.Ordinal)
        || arg.FullType.Equals(constraint, StringComparison.Ordinal)) {
      return true;
    }

    if (!context.GetTyped(arg.FullType, out IGqlpType? argType)) {
      // todo: Handle type params properly
      return arg.IsTypeParam;
    }

    if (argType.Label.Prefixed("_").Equals(constraint, StringComparison.Ordinal)) {
      return true;
    }

    return _anyTypeMatcher.Matches(argType, constraint, context);
  }
}
