namespace GqlPlus.Verifying.Schema;

[TracePerTest]
public class VerifyAllTypesAliasedTests
  : GroupedVerifierTestsBase<IGqlpType>
{
  internal override GroupedVerifier<IGqlpType> NewGroupedVerifier()
    => new VerifyAllTypesAliased(Merger, LoggerFactory);
}
