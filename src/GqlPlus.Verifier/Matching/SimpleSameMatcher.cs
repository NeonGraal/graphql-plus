using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Matching;

internal class SimpleSameMatcher<TType>(
  ILoggerFactory logger
) : MatchParentSameBase<IGqlpTypeRef, TType>(logger)
  where TType : IGqlpSimple
{ }
