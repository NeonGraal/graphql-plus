using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Matching;

internal class SimpleSameMatcher<TType>(
  ILoggerFactory logger
) : ParentSameMatcher<IGqlpTypeRef, TType>(logger)
  where TType : IGqlpSimple
{ }
