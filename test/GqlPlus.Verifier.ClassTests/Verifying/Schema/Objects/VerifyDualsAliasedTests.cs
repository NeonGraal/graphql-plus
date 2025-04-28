using GqlPlus.Abstractions.Schema;
using GqlPlus.Verification.Schema;

namespace GqlPlus.Verifying.Schema.Objects;

[TracePerTest]
public class VerifyDualsAliasedTests
  : AliasedVerifierBase<IGqlpDualObject>
{
  internal override GroupedVerifier<IGqlpDualObject> NewGroupedVerifier()
    => new VerifyDualsAliased(Definition, Merger, Logger);
}
