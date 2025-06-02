namespace GqlPlus.Verifying.Schema.Globals;

[TracePerTest]
public class VerifyCategoryAliasedTests
  : AliasedVerifierTestsBase<IGqlpSchemaCategory>
{
  internal override GroupedVerifier<IGqlpSchemaCategory> NewGroupedVerifier()
    => new VerifyCategoryAliased(Definition, Merger, LoggerFactory);
}
