using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Verifying.Schema.Simple;

[TracePerTest]
public class VerifyEnumsAliasedTests
  : GroupedVerifierBase<IGqlpEnum>
{
  internal override AliasedVerifier<IGqlpEnum> NewAliasedVerifier(IVerify<IGqlpEnum> definition)
    => new VerifyEnumsAliased(definition, Merger, Logger);
}
