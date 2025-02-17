using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Verifying.Schema.Objects;

[TracePerTest]
public class VerifyOutputsAliasedTests
  : GroupedVerifierBase<IGqlpOutputObject>
{
  internal override AliasedVerifier<IGqlpOutputObject> NewAliasedVerifier(IVerify<IGqlpOutputObject> definition)
    => new VerifyOutputsAliased(definition, Merger, Logger);
}
