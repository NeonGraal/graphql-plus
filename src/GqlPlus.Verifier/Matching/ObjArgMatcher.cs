using GqlPlus.Abstractions.Schema;
using GqlPlus.Verifying.Schema;

namespace GqlPlus.Matching;

internal class ObjArgMatcher<TObjArg>(
    Matcher<IGqlpType>.D anyTypeMatcher
) : Matcher<TObjArg>.I
  where TObjArg : IGqlpObjArg
{
  private readonly Matcher<IGqlpType>.L _anyTypeMatcher = anyTypeMatcher;

  public bool Matches(TObjArg type, string constraint, UsageContext context)
  {
    if ("_Any".Equals(constraint, StringComparison.Ordinal)
        || type.FullType.Equals(constraint, StringComparison.Ordinal)) {
      return true;
    }

    if (!context.GetTyped(type.FullType, out IGqlpType? argType)) {
      // todo: Handle type params properly
      return type.IsTypeParam;
    }

    if (argType.Label.Prefixed("_").Equals(constraint, StringComparison.Ordinal)) {
      return true;
    }

    return _anyTypeMatcher.Matches(argType, constraint, context);
  }
}
