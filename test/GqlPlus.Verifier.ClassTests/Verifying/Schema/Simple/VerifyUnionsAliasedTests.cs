namespace GqlPlus.Verifying.Schema.Simple;

[TracePerTest]
public class VerifyUnionsAliasedTests
  : AliasedVerifierTestsBase<IAstUnion>
{
  internal override GroupedVerifier<IAstUnion> NewGroupedVerifier()
    => new VerifyUnionsAliased(VerifierRepo);
}
