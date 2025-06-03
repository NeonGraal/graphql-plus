namespace GqlPlus.Verifying.Schema.Globals;

[TracePerTest]
public class VerifyDirectiveAliasedTests
  : AliasedVerifierTestsBase<IGqlpSchemaDirective>
{
  internal override GroupedVerifier<IGqlpSchemaDirective> NewGroupedVerifier()
    => new VerifyDirectiveAliased(Definition, Merger, LoggerFactory);
}
