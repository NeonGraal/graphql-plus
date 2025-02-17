using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Verifying.Schema.Simple;

[TracePerTest]
public class VerifyUnionsAliasedTests
  : GroupedVerifierBase<IGqlpUnion>
{
  internal override AliasedVerifier<IGqlpUnion> NewAliasedVerifier(IVerify<IGqlpUnion> definition)
    => new VerifyUnionsAliased(definition, Merger, Logger);
}
