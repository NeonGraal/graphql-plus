using GqlPlus.Verification.Schema;

namespace GqlPlus.Verifying.Schema.Objects;

[TracePerTest]
public class VerifyDualsAliasedTests
  : AliasedVerifierTestsBase<IGqlpDualObject>
{
  internal override GroupedVerifier<IGqlpDualObject> NewGroupedVerifier()
    => new VerifyDualsAliased(Definition, Merger, LoggerFactory);
}
