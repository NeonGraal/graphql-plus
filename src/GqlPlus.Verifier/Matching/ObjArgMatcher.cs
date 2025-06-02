using GqlPlus.Abstractions.Schema;
using GqlPlus.Verifying.Schema;

namespace GqlPlus.Matching;

internal class ObjArgMatcher<TObjArg>(
  ILoggerFactory logger,
  Matcher<IGqlpType>.D anyTypeMatcher
) : MatcherBase<TObjArg>(logger)
  where TObjArg : IGqlpObjArg
{
  private readonly Matcher<IGqlpType>.L _anyTypeMatcher = anyTypeMatcher;

  public override bool Matches(TObjArg arg, string constraint, EnumContext context)
  {
    Logger.TryingMatch(arg, constraint);

    if (arg.FullType.Equals(constraint, StringComparison.Ordinal)) {
      return true;
    }

    if (!context.GetTyped(arg.FullType, out IGqlpType? argType)) {
      // todo: Handle type params properly
      return arg.IsTypeParam;
    }

    return _anyTypeMatcher.Matches(argType, constraint, context);
  }
}
