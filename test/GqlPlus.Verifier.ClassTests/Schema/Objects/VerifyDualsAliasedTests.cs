using GqlPlus.Abstractions.Schema;
using GqlPlus.Verification.Schema;
using GqlPlus.Verifying.Schema.Objects;

namespace GqlPlus.Schema.Objects;

[TracePerTest]
public class VerifyDualsAliasedTests
  : AliasedVerifierBase<IGqlpDualObject>
{
  internal override GroupedVerifier<IGqlpDualObject> NewGroupedVerifier()
    => new VerifyDualsAliased(Definition, Merger, Logger);
}
