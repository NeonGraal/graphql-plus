using GqlPlus.Abstractions.Schema;

namespace GqlPlus.Verifying.Schema.Simple;

[TracePerTest]
public class VerifyDomainsAliasedTests
  : GroupedVerifierBase<IGqlpDomain>
{
  internal override AliasedVerifier<IGqlpDomain> NewAliasedVerifier(IVerify<IGqlpDomain> definition)
    => new VerifyDomainsAliased(definition, Merger, Logger);
}
