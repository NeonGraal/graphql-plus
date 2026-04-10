namespace GqlPlus.Verifying.Schema.Simple;

[TracePerTest]
public class VerifyDomainsAliasedTests
  : AliasedVerifierTestsBase<IAstDomain>
{
  internal override GroupedVerifier<IAstDomain> NewGroupedVerifier()
    => new VerifyDomainsAliased(VerifierRepo);
}
