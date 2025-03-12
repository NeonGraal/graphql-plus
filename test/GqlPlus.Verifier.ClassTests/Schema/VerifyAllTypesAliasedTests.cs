using GqlPlus.Abstractions.Schema;
using GqlPlus.Verification.Schema;
using GqlPlus.Verifying.Schema;

namespace GqlPlus.Schema;

[TracePerTest]
public class VerifyAllTypesAliasedTests
  : GroupedVerifierBase<IGqlpType>
{
  internal override GroupedVerifier<IGqlpType> NewGroupedVerifier()
    => new VerifyAllTypesAliased(Merger, Logger);
}
