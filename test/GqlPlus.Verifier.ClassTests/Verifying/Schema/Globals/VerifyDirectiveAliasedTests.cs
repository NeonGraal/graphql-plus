namespace GqlPlus.Verifying.Schema.Globals;

[TracePerTest]
public class VerifyDirectiveAliasedTests
  : AliasedVerifierTestsBase<IAstSchemaDirective>
{
  internal override GroupedVerifier<IAstSchemaDirective> NewGroupedVerifier()
    => new VerifyDirectiveAliased(VerifierRepo);
}
