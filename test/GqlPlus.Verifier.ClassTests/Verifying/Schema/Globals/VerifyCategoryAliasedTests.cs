namespace GqlPlus.Verifying.Schema.Globals;

[TracePerTest]
public class VerifyCategoryAliasedTests
  : AliasedVerifierTestsBase<IAstSchemaCategory>
{
  internal override GroupedVerifier<IAstSchemaCategory> NewGroupedVerifier()
    => new VerifyCategoryAliased(VerifierRepo);
}
