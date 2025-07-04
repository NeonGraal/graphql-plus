using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Matching;

internal class ObjectSameMatcher<TType>(
  ILoggerFactory logger
) : ParentSameMatcher<IGqlpObjBase, TType>(logger)
  where TType : IGqlpObject
{ }
