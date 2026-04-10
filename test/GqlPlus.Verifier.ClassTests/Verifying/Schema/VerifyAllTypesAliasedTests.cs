namespace GqlPlus.Verifying.Schema;

[TracePerTest]
public class VerifyAllTypesAliasedTests
  : GroupedVerifierTestsBase<IAstType>
{
  internal override GroupedVerifier<IAstType> NewGroupedVerifier()
    => new VerifyAllTypesAliased(VerifierRepo);
}
