using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Verifying.Schema.Objects;

[TracePerTest]
public class VerifyInputsAliasedTests
  : GroupedVerifierBase<IGqlpInputObject>
{
  internal override AliasedVerifier<IGqlpInputObject> NewAliasedVerifier(IVerify<IGqlpInputObject> definition)
    => new VerifyInputsAliased(definition, Merger, Logger);
}
