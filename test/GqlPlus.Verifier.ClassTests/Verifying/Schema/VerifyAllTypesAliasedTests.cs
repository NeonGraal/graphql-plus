using GqlPlus.Abstractions.Schema;
using GqlPlus.Verification.Schema;

namespace GqlPlus.Verifying.Schema;

[TracePerTest]
public class VerifyAllTypesAliasedTests
  : GroupedVerifierBase<IGqlpType>
{
  internal override GroupedVerifier<IGqlpType> NewGroupedVerifier()
    => new VerifyAllTypesAliased(Merger, LoggerFactory);
}
