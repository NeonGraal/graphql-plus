using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Verifying.Schema.Objects;

[TracePerTest]
public class VerifyDualsAliasedTests
  : GroupedVerifierBase<IGqlpDualObject>
{
  internal override AliasedVerifier<IGqlpDualObject> NewAliasedVerifier(IVerify<IGqlpDualObject> definition)
    => new VerifyDualsAliased(definition, Merger, Logger);
}
